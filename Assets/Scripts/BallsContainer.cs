using System.Collections.Generic;
using UnityEngine;

public class BallsContainer : MonoBehaviour
{
    public List<Ball> Balls { get; set; } = new List<Ball>();
    public void Remove(Ball ball) => Balls.Remove(ball);
    public void Add(Ball ball) => Balls.Add(ball);
    public void AddRange(Ball[] balls) => Balls.AddRange(balls);

    public void RemoveRange(Ball[] balls)
    {
        foreach (var ball in balls)
        {
            Balls.Remove(ball);
        }
    }
}
