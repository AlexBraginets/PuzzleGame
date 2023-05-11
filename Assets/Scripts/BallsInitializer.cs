using System.Collections.Generic;
using UnityEngine;
using Utils;

public class BallsInitializer : MonoBehaviour
{
    [SerializeField] private WayDataHolder wayDataHolder;
    [SerializeField] private int _ballsCount;
    [SerializeField] private Ball _ballPrefab;
    [SerializeField] private int _spawnLineIndex;
    [SerializeField] private Transform _startPosition;
    public List<Ball> Balls { get; private set; }
    void Awake()
    {
        Init();
    }

    private void Init()
    {
        Balls = new List<Ball>();
        Line[] lines = wayDataHolder.Lines;
        float distance = GetStartDistance();
        float dx = 1.1f;
        Line spawnLine = lines[_spawnLineIndex];
        WayData wayData = new WayData()
        {
            Lines = lines,
            LineIndex = _spawnLineIndex,
            LocalLength = distance
        };   
        for (int i = 0; i < _ballsCount; i++)
        {
            spawnLine = lines[wayData.LineIndex];
            Vector3 position = spawnLine.GetPoint(wayData.LocalLength);
            Ball ball = Instantiate(_ballPrefab, transform);
            Balls.Add(ball);
            ball.transform.position = position;
            wayData.Simplify();
            ball.SetDistance(wayData.LocalLength);
            ball.SetWayData(wayDataHolder);
            ball.SetLineIndex(wayData.LineIndex);
            wayData.LocalLength += dx;
        }
    }

    private float GetStartDistance()
    {
        Line[] lines = wayDataHolder.Lines;
        Line spawnLine = lines[_spawnLineIndex];
        Vector3 startPosition = _startPosition.position;
        var closestPoint = spawnLine.ClosestPoint(startPosition, out float distance);
        float startDistance = (closestPoint - spawnLine.a).magnitude;
        return startDistance;
    }
}
