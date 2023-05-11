using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class InputController : MonoBehaviour
{
    [SerializeField] private BallsContainer _ballsContainer;
    private List<Ball> Balls => _ballsContainer.Balls;

    private bool isDragging;
    private Vector3 _lastPosition;
    [SerializeField] private LayerMask _abortMask;

    [SerializeField] private float _moveDistance;

    [SerializeField] private float _moveSpeed;

    // Update is called once per frame
    private double _lastMoved;
    [field: SerializeField] private float _deltaMoved { get; set; }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DOTween.To(() => 0f, x => MoveBalls(-x), _moveDistance, _moveDistance / _moveSpeed)
                .OnComplete(() => _lastMoved = 0d);
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (Abort()) return;

            isDragging = true;
            _lastPosition = GetPosition();
            _deltaMoved = 0f;
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (!isDragging) return;
            isDragging = false;

            if (_deltaMoved == 0f) return;
            _deltaMoved %= 1.1f;
            if (_deltaMoved < 0) _deltaMoved += 1.1f;
            Debug.Log($"_deltaMoved: {_deltaMoved}");
            float dx;
            if (_deltaMoved < 1.1f / 2f)
            {
                dx = -_deltaMoved;
            }
            else
            {
                dx = 1.1f - _deltaMoved;
            }
            _lastMoved = 0f;
            DOTween.To(() => 0f, x => MoveBalls(x), dx, Mathf.Abs(dx / _moveSpeed))
                .OnComplete(() => _lastMoved = 0d);
        }

        if (!isDragging) return;
        var position = GetPosition();
        float dy = (position - _lastPosition).y < 0 ? 1f : -1f;
        foreach (var ball in Balls)
        {
            ball.Move((_lastPosition - position).magnitude * dy);
        }

        _deltaMoved += (_lastPosition - position).magnitude * dy;
        _lastPosition = position;
    }

    private void MoveBalls(double x)
    {
        float dMove = (float) x - (float) _lastMoved;
        _lastMoved = x;
        foreach (var ball in Balls)
        {
            ball.Move(dMove);
        }

    }

    private bool Abort()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, 100, _abortMask))
        {
            return true;
        }

        return false;
    }

    private Vector3 GetPosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Plane plane = new Plane(Vector3.forward, Vector3.zero);
        if (plane.Raycast(ray, out float enter))
        {
            var point = ray.GetPoint(enter);
            return point;
        }

        throw new NotImplementedException();
    }
}