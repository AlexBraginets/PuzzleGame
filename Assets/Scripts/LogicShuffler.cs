using UnityEngine;

public class LogicShuffler : MonoBehaviour
{
    [SerializeField] private BallsContainer[] _ballsContainers;

    [SerializeField] private int _containerIndex;
    private System.Random _rnd = new System.Random();
    private void Start()
    {
        Shuffle();
    }

    [ContextMenu("Shuffle")]
    private void Shuffle()
    {
        var balls = _ballsContainers[_containerIndex].Balls;
        foreach (var ball in balls)
        {
            ball.Move(1.1f*_rnd.Next(100));
        }
    }
}