using System;
using UnityEngine;
using ZergRush.ReactiveCore;

public class Pipe : MonoBehaviour
{
    [SerializeField] private PipeBallsProvider _ballsProvider;
    public Ball[] Balls => _ballsProvider.GetBalls();
    
    [SerializeField] private IndexConfig _indexConfig;
    [HideInInspector] public Cell<int> CurrentLocation = new Cell<int>();
    public event Action OnLocationUpdated;
    public void LocationUpdated() => OnLocationUpdated?.Invoke();

    private void Awake() => _indexConfig.Init(CurrentLocation);

    public void Switch()
    {
        _indexConfig.Next();
    }
}