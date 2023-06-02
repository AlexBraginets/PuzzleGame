using System;
using DG.Tweening;
using UnityEngine;

public class PipeMover : MonoBehaviour
{
    [SerializeField] private float _animationDuration = .2f;
    [SerializeField] private Transform[] _locations;
    public event Action OnLocationUpdated;
    public void UpdateLocation(int locationIndex)
    {
        Vector3 targetPosition = _locations[locationIndex].position;
        Vector3 targetRotation = _locations[locationIndex].eulerAngles;
        transform.DOMove(targetPosition, _animationDuration);
        transform.DORotate(targetRotation, _animationDuration).OnComplete(() =>
        {
            OnLocationUpdated?.Invoke();
            OnLocationUpdated = null;
        });
    }
}