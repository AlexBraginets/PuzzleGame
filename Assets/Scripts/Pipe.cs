using UnityEngine;

public class Pipe : MonoBehaviour
{
    [SerializeField] private PipeBallsProvider _ballsProvider;
    [SerializeField] private BallsContainer[] _ballsContainers;
    [SerializeField] private BallsWayDataRefresher _ballsWayDataRefresher;
    [SerializeField] private PipeMover _pipeMover;
    [SerializeField] private BallsAttacher _ballsAttacher;
    [SerializeField] private BallsHighlighter _ballsHighlighter;
    [SerializeField] private bool[] refreshMap;
    private Ball[] _balls;
    private int _currentLocation;
    private BallsContainer CurrentBallContainer => _ballsContainers[_currentLocation];

    public void Switch()
    {
        var balls = _ballsProvider.GetBalls();
        _balls = balls;
        SwapLocation(out int previousLocation);
        UpdateBallContainers(previousLocation);
        if (refreshMap[_currentLocation])
            RefreshBallsWayData();
    }

    private void RefreshBallsWayData() => _ballsWayDataRefresher.Refresh(_currentLocation, _balls);

    private void UpdateBallContainers(int previousLocation)
    {
        _ballsContainers[previousLocation].RemoveRange(_balls);
        CurrentBallContainer.AddRange(_balls);
    }


    private void AttachBalls(Ball[] balls) => _ballsAttacher.Attach(balls);

    private void DeattachBalls() => _ballsAttacher.Deattach();


    private void SwapLocation(out int previousLocation)
    {
        previousLocation = _currentLocation;
        SwapCurrentLocationIndex();
        AttachBalls(_balls);
        UpdateLocation();
        DeattachBalls();
    }

    private void UpdateLocation() => _pipeMover.UpdateLocation(_currentLocation);

    private void SwapCurrentLocationIndex()
    {
        _currentLocation++;
        _currentLocation %= 2;
    }
}