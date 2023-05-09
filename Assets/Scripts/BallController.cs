using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] private Ball _ball;
    [SerializeField] private float _speed;
    private void Update()
    {
        float dX = Time.deltaTime * _speed;
        _ball.Move(dX);
    }
}
