using System;
using System.Collections.Generic;
using UnityEngine;

public class AllBallsProvider : MonoBehaviour
{
    public static AllBallsProvider Instance { get; private set; }

    public List<Ball> Balls { get; private set; } = new List<Ball>();
    [SerializeField] private BallsContainer[] _ballsContainers;
    private void Start()
    {
        Instance = this;
        Init();
    }

    private void Init()
    {
        foreach (BallsContainer ballsContainer in _ballsContainers)
        {
            Balls.AddRange(ballsContainer.Balls);
        }
    }
}
