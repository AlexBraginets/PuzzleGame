using System.Collections.Generic;
using UnityEngine;

public class PipeBallsProvider : MonoBehaviour
{
    [SerializeField] private BallLocator[] _ballLocators;
    private int _lastFrame = -1;
    private Ball[] _balls;
    public Ball[] GetBalls()
    {
        Debug.Log($"GetBalls(); transform.position: {transform.position}", gameObject);
        // if (Time.frameCount == _lastFrame) return _balls;
        // _lastFrame = Time.frameCount;
        List<Ball> balls = new List<Ball>();
        foreach (var ballLocator in _ballLocators)
        {
            balls.Add(ballLocator.GetBall());
        }

        _balls = balls.ToArray();
        return _balls;
    }
}