using System;
using UnityEngine;

public class BallMover : MonoBehaviour
{
    [SerializeField] private BallsContainer _ballsContainer;
    [SerializeField] private MoveBallFinalizer _finalizer;
    private float _deltaMoved;
    public event Action OnFinilized;

    public void Begin()
    {
        _deltaMoved = 0f;
    }

    public void DoFinalize()
    {
        if (_deltaMoved == 0f) return;
        _finalizer.Finalize(_deltaMoved, this);
        _finalizer.OnFinilized += () =>
        {
            OnFinilized?.Invoke();
            OnFinilized = null;
        };
    }

    public void Move(float dx)
    {
        foreach (var ball in _ballsContainer.Balls)
        {
            ball.Move(dx);
        }

        _deltaMoved += dx;
    }
}