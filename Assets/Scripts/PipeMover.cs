using DG.Tweening;
using UnityEngine;

public class PipeMover : MonoBehaviour
{
    [SerializeField] private float _animationDuration = .2f;
    [SerializeField] private Transform[] _locations;
    [SerializeField] private BallsAttacher _ballsAttacher;
    [SerializeField] private Pipe _pipe;

    private void Start()
    {
        Init(_pipe);
    }


    public void Init(Pipe pipe)
    {
        _pipe = pipe;
        pipe.CurrentLocation.ListenUpdates(UpdateLocation);
    }

    private void UpdateLocation(int locationIndex)
    {
        UpdateLocation(locationIndex, _pipe.Balls);
    }

    private void UpdateLocation(int locationIndex, Ball[] balls)
    {
        Vector3 targetPosition = _locations[locationIndex].position;
        Vector3 targetRotation = _locations[locationIndex].eulerAngles;
        _ballsAttacher.Attach(balls);
        transform.DOMove(targetPosition, _animationDuration);
        transform.DORotate(targetRotation, _animationDuration).OnComplete(() =>
        {
            _ballsAttacher.Deattach();
            _pipe.LocationUpdated();
        });
    }
}