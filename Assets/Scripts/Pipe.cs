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
    private Transform _ballsParent;
    public void AttachBalls(Ball[] balls)
    {
        _ballsParent = balls[0].transform.parent;
        _balls = balls;
        foreach (var ball in _balls)
        {
            ball.transform.parent = transform;
        }
    }
    public void DeattachBalls()
    {
        foreach (var ball in _balls)
        {
            ball.transform.parent = _ballsParent;
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
        DeattachBalls();
    }

    private void SwapLocation()
    {
        _currentLocation++;
        _currentLocation %= 2;
        transform.position = _locations[_currentLocation].position;
        transform.rotation = _locations[_currentLocation].rotation;
    }
}