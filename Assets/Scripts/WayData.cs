using System.Collections.Generic;
using UnityEngine;

public class WayData : MonoBehaviour
{
    [SerializeField] private Transform[] _waypoints;

    public Line[] Lines
    {
        get
        {
            List<Line> lines = new List<Line>();
            for (int i = 0; i < _waypoints.Length; i++)
            {
                int j = (i + 1) % _waypoints.Length;
                Vector3 a = _waypoints[i].position;
                Vector3 b = _waypoints[j].position;
                Line line = new Line(a, b);
                lines.Add(line);
            }

            return lines.ToArray();
        }
    }

}
