using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PipeGetBallsLog : ScriptableObject
{
    public List<BallLog> logs = new List<BallLog>();

    public void Clear()
    {
        logs = new List<BallLog>();
    }

    public void Log(string prefix, Ball[] balls, float[] distanceMap)
    {
        int i = 0;
        foreach (var ball in balls)
        {
            float distance = distanceMap[i];
            logs.Add(new BallLog(ball, prefix)
            {
                Name = logs.Count.ToString(),
                Distance = distance
            });
           
            i++;
        }
        if (logs.Count == 24)
        {
            // Debug.Break();
        }
    }

    [System.Serializable]
    public class BallLog
    {
        public BallLog(Ball ball, string prefix = "")
        {
            FullID = $"[{ball.ContainerIndex}:{ball.id}]";
            Position = ball.transform.position;
            Prefix = prefix;
        }

        public string Name;
        public string Prefix;
        public string FullID;
        public Vector3 Position;
        public float Distance;
    }
}