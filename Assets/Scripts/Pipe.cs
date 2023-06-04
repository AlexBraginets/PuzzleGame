using System;
using UnityEngine;
using ZergRush.ReactiveCore;

public class Pipe : MonoBehaviour
{
    [SerializeField] private PipeGetBallsLog _log;
    [SerializeField] private PipeBallsProvider _ballsProvider;

    public Ball[] Balls
    {
        get
        {
            var balls = _ballsProvider.GetBalls();
            _log.Log(balls);
            return balls;
        }
        
    }
    
    [SerializeField] private IndexConfig _indexConfig;
    [HideInInspector] public Cell<int> CurrentLocation = new Cell<int>();
    public event Action OnLocationUpdated;

    public void LocationUpdated()
    {
        OnLocationUpdated?.Invoke();
    }

    private void Awake()
    {
        _indexConfig.Init(CurrentLocation);
        _log.Clear();
    }

    public void Switch()
    {
        _indexConfig.Next();
    }
}