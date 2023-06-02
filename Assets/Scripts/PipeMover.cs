using System;
using DG.Tweening;
using UnityEngine;

public class PipeMover : MonoBehaviour
{
    [SerializeField] private float _animationDuration = .2f;
    [SerializeField] private Transform[] _locations;
    [SerializeField] private BallsAttacher _ballsAttacher;
    public event Action OnLocationUpdated;
    public void UpdateLocation(int locationIndex, Ball[] balls)
    {
        Vector3 targetPosition = _locations[locationIndex].position;
        Vector3 targetRotation = _locations[locationIndex].eulerAngles;
        _ballsAttacher.Attach(balls);
        transform.DOMove(targetPosition, _animationDuration);
        transform.DORotate(targetRotation, _animationDuration).OnComplete(() =>
        {
            _ballsAttacher.Deattach();
            OnLocationUpdated?.Invoke();
            OnLocationUpdated = null;
        });
    }
}