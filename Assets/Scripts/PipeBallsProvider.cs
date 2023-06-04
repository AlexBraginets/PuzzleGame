using System.Collections.Generic;
using UnityEngine;

public class PipeBallsProvider : MonoBehaviour
{
    [SerializeField] private BallLocator[] _ballLocators;
    private int _lastFrame = -1;
    private Ball[] _balls;
    public Ball[] GetBalls(out float[] distanceMap)
    {
        // Debug.Log($"GetBalls(); transform.position: {transform.position}", gameObject);
        // if (Time.frameCount == _lastFrame) return _balls;
        // _lastFrame = Time.frameCount;
        List<Ball> balls = new List<Ball>();
        List<float> distance = new List<float>();
        foreach (var ballLocator in _ballLocators)
        {
            balls.Add(ballLocator.GetBall(AllBallsProvider.Instance.Balls, out float d));
            distance.Add(d);
        }

        _balls = balls.ToArray();
        distanceMap = distance.ToArray();
        return _balls;
    }
}