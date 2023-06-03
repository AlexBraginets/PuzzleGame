using System;
using UnityEngine;
using ZergRush.ReactiveCore;

public class Pipe : MonoBehaviour
{
    [SerializeField] private PipeBallsProvider _ballsProvider;
    [SerializeField] private BallsContainerHolder _ballsContainerHolder;
    [SerializeField] private PipeMover _pipeMover;
    [SerializeField] private BallsWayDataRefresher _ballsWayDataRefresher;
    private Ball[] _balls;
    public Ball[] Balls => _balls;
    [SerializeField] private int _currentLocation;
    public Cell<int> CurrentLocation;
    public event Action OnLocationUpdated;

    public void LocationUpdated()
    {
        OnLocationUpdated?.Invoke();
    }
    private void Awake()
    {
        CurrentLocation = new Cell<int>(_currentLocation);
    }

    private void Start()
    {
        _pipeMover.Init(this);
        _ballsContainerHolder.Init(this);
        _ballsWayDataRefresher.Init(this);
    }

    public void Switch()
    {
        _balls = _ballsProvider.GetBalls();
        SwapCurrentLocationIndex();
    }
    private void SwapCurrentLocationIndex()
    {
        _currentLocation++;
        _currentLocation %= 3;
        CurrentLocation.value = _currentLocation;
    }
}