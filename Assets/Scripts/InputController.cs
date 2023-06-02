using System;
using UnityEngine;

public class InputController : BaseInputController
{
    [SerializeField] private PlaneRaycaster _planeRaycaster;
    [SerializeField] private BallMover _ballMover;
    private bool _isDragging;
    private Vector3 _previousMousePosition;


    [Header("Abort")]
    [SerializeField] private AbortConfig _abortConfig;
    [SerializeField] private MouseLayerMask _mouseAbort;

    private void Update()
    {
        if (_abortConfig.Abort()) return;

        if (MouseDown)
        {
            if (_mouseAbort.Abort()) return;

            BeginDrag();
        }

        if (!_isDragging) return;

        if (MouseUp)
        {
            EndDrag();
            return;
        }

        Vector3 mousePosition = _planeRaycaster.GetMousePosition();
        UpdateBalls(mousePosition);
        _previousMousePosition = mousePosition;
    }

    private void BeginDrag()
    {
        _isDragging = true;
        _previousMousePosition = _planeRaycaster.GetMousePosition();
        _ballMover.Begin();
    }

    private void EndDrag()
    {
        _isDragging = false;
        _ballMover.DoFinalize();
    }

    private void UpdateBalls(Vector3 mousePosition)
    {
        float yDir = -Mathf.Sign((mousePosition - _previousMousePosition).y);
        float dx = yDir * (mousePosition - _previousMousePosition).magnitude;
        _ballMover.Move(dx);
    }

    [Serializable]
    private class AbortConfig
    {
        public TubeSwitcher TubeSwitcher;
        public bool[] MoveMask;
        public bool Abort() => !MoveMask[TubeSwitcher.Position];
    }
}