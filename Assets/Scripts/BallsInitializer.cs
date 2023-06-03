using UnityEngine;

public class BallsInitializer : MonoBehaviour
{
    [SerializeField] private int _containerIndex;
    [SerializeField] private int _ballsCount;
    [SerializeField] private WayDataHolder wayDataHolder;
    [SerializeField] private BallsContainer _ballsContainer;

    [Header("Start spawn config")] [SerializeField]
    private int _spawnLineIndex;

    [SerializeField] private Transform _startPosition;

    [Header("Ball prefabs")] [SerializeField]
    private Ball _ballPrefab;

    [SerializeField] private Ball _specialBallPrefab;


    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        Line[] lines = wayDataHolder.Lines;
        float distance = GetStartDistance(lines);
        float dx = 1.1f;
        WayData wayData = new WayData()
        {
            Lines = lines,
            LineIndex = _spawnLineIndex,
            LocalLength = distance
        };
        for (int i = 0; i < _ballsCount; i++)
        {
            Ball ball = Instantiate(GetBallPrefab(i), transform);
            ball.ContainerIndex = _containerIndex;
            _ballsContainer.Add(ball);
            ball.UpdateWayData(wayData);
            wayData.LocalLength += dx;
        }
    }

    private Ball GetBallPrefab(int index) => index == _ballsCount - 1 ? _specialBallPrefab : _ballPrefab;

    private float GetStartDistance(Line[] lines)
    {
        Line spawnLine = lines[_spawnLineIndex];
        Vector3 startPosition = _startPosition.position;
        var closestPoint = spawnLine.ClosestPoint(startPosition, out float distance);
        float startDistance = (closestPoint - spawnLine.a).magnitude;
        return startDistance;
    }
}