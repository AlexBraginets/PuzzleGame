using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BallsInitializer : MonoBehaviour
{
    [SerializeField] private WayData _wayData;
    [SerializeField] private int _ballsCount;
    [SerializeField] private Ball _ballPrefab;
    [SerializeField] private int _spawnLineIndex;
    [SerializeField] private Transform _startPosition;
    void Awake()
    {
        Init();
    }

    private void Init()
    {
        Line[] lines = _wayData.Lines;
        float distance = GetStartDistance();
        float dx = 1.1f;
        Line spawnLine = lines[_spawnLineIndex];
        
        for (int i = 0; i < _ballsCount; i++)
        {
            Vector3 position = spawnLine.GetPoint(distance);
            Ball ball = Instantiate(_ballPrefab, transform);
            ball.transform.position = position;
            ball.SetDistance(distance);
            ball.SetWayData(_wayData);
            ball.SetLineIndex(_spawnLineIndex);
            distance += dx;
        }
    }

    private float GetStartDistance()
    {
        Line[] lines = _wayData.Lines;
        Line spawnLine = lines[_spawnLineIndex];
        Vector3 startPosition = _startPosition.position;
        var closestPoint = spawnLine.ClosestPoint(startPosition, out float distance);
        float startDistance = (closestPoint - spawnLine.a).magnitude;
        return startDistance;
    }
}
