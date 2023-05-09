using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    [SerializeField] private int _ballsCount;
    private Ball[] _balls;
    [SerializeField] private Transform[] _locations;
    private int _currentLocation;
    [SerializeField] private BallLocator[] _ballLocators;

    public void AttachBalls(Ball[] balls)
    {
        _balls = balls;
        foreach (var ball in _balls)
        {
            ball.transform.parent = transform;
        }
    }

    private Ball[] GetBalls()
    {
        List<Ball> balls = new List<Ball>();
        foreach (var ballLocator in _ballLocators)
        {
            balls.Add(ballLocator.GetBall());
        }

        return balls.ToArray();
    }

    private void OnMouseDown()
    {
        var balls = GetBalls();
        AttachBalls(balls);
        SwapLocation();
    }

    private void SwapLocation()
    {
        _currentLocation++;
        _currentLocation %= 2;
        transform.position = _locations[_currentLocation].position;
        transform.rotation = _locations[_currentLocation].rotation;
    }
}