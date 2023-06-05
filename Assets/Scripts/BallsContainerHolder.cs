using UnityEngine;

public class BallsContainerHolder : MonoBehaviour
{
    [SerializeField] private BallsContainer[] _ballsContainers;

    [SerializeField] private Pipe _pipe;
    private int _previousLocationIndex;

    private void Start()
    {
        Init(_pipe);
    }

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
