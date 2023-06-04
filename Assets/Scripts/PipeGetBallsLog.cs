using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class PipeGetBallsLog : ScriptableObject
{
    public List<string> logs = new List<string>();
    public void Clear()
    {
        logs = new List<string>();
    }

    public void Log(Ball[] balls)
    {
        foreach (var ball in balls)
        {
            logs.Add(ball.ToString());
        }
    }
}
