using UnityEngine;

public class BallsAttacher : MonoBehaviour
{
    private Transform _ballsParent;
    private Ball[] _balls;

    public void Attach(Ball[] balls)
    {
        _balls = balls;
        _ballsParent = balls[0].Parent;
        foreach (var ball in _balls)
        {
            ball.Parent = transform;
        }
    }

    public void Deattach()
    {
        foreach (var ball in _balls)
        {
            ball.Parent = _ballsParent;
        }
    }
}