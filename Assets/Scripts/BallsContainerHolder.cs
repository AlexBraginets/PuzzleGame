using UnityEngine;

public class BallsContainerHolder : MonoBehaviour
{
    [SerializeField] private BallsContainer[] _ballsContainers;

    private Pipe _pipe;
    private int _previousLocationIndex;
    public void Init(Pipe pipe)
    {
        _pipe = pipe;
        _previousLocationIndex = pipe.CurrentLocation.value;
        pipe.CurrentLocation.ListenUpdates(UpdateContainers);
    }

    private void UpdateContainers(int locationIndex)
    {
        _ballsContainers[_previousLocationIndex].RemoveRange(_pipe.Balls);
        _ballsContainers[locationIndex].AddRange(_pipe.Balls);
        _previousLocationIndex = locationIndex;
    }
}
