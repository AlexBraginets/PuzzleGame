using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BallsContainer : MonoBehaviour
{
    [SerializeField] private int _fullAmount = 24;
    public event Action OnCompleted;
    [field: SerializeField] public List<Ball> Balls { get; set; } = new List<Ball>();
    public void Remove(Ball ball) => Balls.Remove(ball);

    public void Add(Ball ball)
    {
        Balls.Add(ball);
        if(IsCompleted()) OnCompleted?.Invoke();
    }

    public void AddRange(Ball[] balls)
    {
        Balls.AddRange(balls);  
        if(IsCompleted()) OnCompleted?.Invoke();
    } 

    public void RemoveRange(Ball[] balls)
    {
        foreach (var ball in balls)
        {
            Balls.Remove(ball);
        }
    }

    public bool IsCompleted()
    {
        if (Balls.Count != _fullAmount) return false;
        int id = Balls.First().ContainerIndex;
        foreach (var ball in Balls)
        {
            if (ball.ContainerIndex != id) return false;
        }

        return true;
    }
}