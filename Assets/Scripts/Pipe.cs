using System.Linq;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    [SerializeField] private PipeBallsProvider _ballsProvider;
    [SerializeField] private BallsContainer[] _ballsContainers;
    [SerializeField] private WayDataHolder[] _wayDatas;
    [SerializeField] private Transform[] _locations;
    [SerializeField] private BallLocator[] _ballLocators;
    [SerializeField] private BallsAttacher _ballsAttacher;
    private Transform _ballsParent;
    private Ball[] _balls;
    private int _currentLocation;
    private BallsContainer _currentBallContainer => _ballsContainers[_currentLocation];

    public void Switch()
    {
        var balls = _ballsProvider.GetBalls();
        _balls = balls;
        AttachBalls(balls);
        int previousLocation =SwapLocation();
        DeattachBalls();
        RefreshBallsWayData();
        UpdateBallContainers(previousLocation);
    }

    private void UpdateBallContainers(int previousLocation)
    {
        _ballsContainers[previousLocation].RemoveRange(_balls);
        _currentBallContainer.AddRange(_balls);
    }

    private void RefreshBallsWayData()
    {
        GetPosData(_currentLocation, out PosData[] data);
        for (int i = 0; i < _balls.Length; i++)
        {
            var ball = _balls[i];
            ball.UpdatePosData(data[i]);
            ball.UpdateWayData(_wayDatas[_currentLocation]);
        }
    }

    private void AttachBalls(Ball[] balls) => _ballsAttacher.Attach(balls);

    private void DeattachBalls() => _ballsAttacher.Deattach();

    private void GetPosData(int locationIndex, out PosData[] data)
    {
        var ballLocators = _locations[locationIndex].GetComponent<Pipe>()._ballLocators;
        var posData = ballLocators.Select(bl => bl.GetComponent<PosDataProvider>());
        data = posData.Select(x => x.GetPosData()).ToArray();
    }

    private int SwapLocation()
    {
        int previousLocation = _currentLocation;
        SwapCurrentLocationIndex();
        UpdateLocation();
        return previousLocation;
    }

    private void SwapCurrentLocationIndex()
    {
        _currentLocation++;
        _currentLocation %= 2;
    }

    private void UpdateLocation()
    {
        transform.position = _locations[_currentLocation].position;
        transform.rotation = _locations[_currentLocation].rotation;
    }
}