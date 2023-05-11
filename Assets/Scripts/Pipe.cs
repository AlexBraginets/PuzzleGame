using System.Linq;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    [SerializeField] private BallsInitializer[] _ballsInitializers;
    [SerializeField] private WayDataHolder[] _wayDatas;
    [SerializeField] private Transform[] _locations;
    [SerializeField] private BallLocator[] _ballLocators;
    [SerializeField] private PipeBallsProvider _ballsProvider;
    private Transform _ballsParent;
    private Ball[] _balls;
    private int _currentLocation;
    public void Switch()
    {
        var balls = _ballsProvider.GetBalls();
        AttachBalls(balls);
        SwapLocation();
        DeattachBalls();
        GetPosData(_currentLocation, out int[] wayIndex, out float[] localLength);
        for (int i = 0; i < balls.Length; i++)
        {
            var ball = balls[i];
            Debug.Log($"i: {i}");
            ball.UpdatePosData(wayIndex[i], localLength[i]);
            ball.UpdateWayData(_wayDatas[_currentLocation]);
        }
    }

    private void AttachBalls(Ball[] balls)
    {
        _ballsParent = balls[0].transform.parent;
        _balls = balls;
        foreach (var ball in _balls)
        {
            ball.transform.parent = transform;
            _ballsInitializers[_currentLocation].Balls.Remove(ball);
        }
    }

    private void DeattachBalls()
    {
        foreach (var ball in _balls)
        {
            ball.transform.parent = _ballsParent;
            _ballsInitializers[_currentLocation].Balls.Add(ball);
        }
    }

    

   

    private void GetPosData(int locationIndex, out int[] wayIndex, out float[] distance)
    {
        var ballLocators = _locations[locationIndex].GetComponent<Pipe>()._ballLocators;
        var posData = ballLocators.Select(bl => bl.GetComponent<PosData>());
        wayIndex = posData.Select(x => x.wayIndex).ToArray();
        distance = posData.Select(x => x.localLength).ToArray();
    }

    private void SwapLocation()
    {
        _currentLocation++;
        _currentLocation %= 2;
        transform.position = _locations[_currentLocation].position;
        transform.rotation = _locations[_currentLocation].rotation;
    }
}