using System.Linq;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    [SerializeField] private PipeBallsProvider _ballsProvider;
    [SerializeField] private BallsContainer[] _ballsContainers;
    [SerializeField] private WayDataHolder[] _wayDatas;
    [SerializeField] private PipeMover _pipeMover;
    [SerializeField] private BallsAttacher _ballsAttacher;
    [SerializeField] private BallsWayDataRefresher _ballsWayDataRefresher;
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

    private void RefreshBallsWayData() => _ballsWayDataRefresher.Refresh(_currentLocation, _balls);

    private void UpdateBallContainers(int previousLocation)
    {
        _ballsContainers[previousLocation].RemoveRange(_balls);
        _currentBallContainer.AddRange(_balls);
    }


    private void AttachBalls(Ball[] balls) => _ballsAttacher.Attach(balls);

    private void DeattachBalls() => _ballsAttacher.Deattach();

   

    private int SwapLocation()
    {
        int previousLocation = _currentLocation;
        SwapCurrentLocationIndex();
        UpdateLocation();
        return previousLocation;
    }

    private void UpdateLocation() => _pipeMover.UpdateLocation(_currentLocation);

    private void SwapCurrentLocationIndex()
    {
        _currentLocation++;
        _currentLocation %= 2;
    }

   
}