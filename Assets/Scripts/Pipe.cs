using System;
using UnityEngine;
using ZergRush.ReactiveCore;

public class Pipe : MonoBehaviour
{
    [SerializeField] private PipeBallsProvider _ballsProvider;

    [Header("Subscribers")] [SerializeField]
    private BallsContainerHolder _ballsContainerHolder;

    [SerializeField] private PipeMover _pipeMover;
    [SerializeField] private BallsWayDataRefresher _ballsWayDataRefresher;
    public Ball[] Balls { get; private set; }
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
    }

    private void Start()
    {
        _pipeMover.Init(this);
        _ballsContainerHolder.Init(this);
        _ballsWayDataRefresher.Init(this);
    }

    public void Switch()
    {
        Balls = _ballsProvider.GetBalls();
        _indexConfig.Next();
    }
}