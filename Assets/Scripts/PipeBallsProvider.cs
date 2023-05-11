using System.Collections.Generic;
using UnityEngine;

public class PipeBallsProvider : MonoBehaviour
{
    [SerializeField] private BallLocator[] _ballLocators;

    public Ball[] GetBalls()
    {
        List<Ball> balls = new List<Ball>();
        foreach (var ballLocator in _ballLocators)
        {
            balls.Add(ballLocator.GetBall());
        }

        return balls.ToArray();
    }
}