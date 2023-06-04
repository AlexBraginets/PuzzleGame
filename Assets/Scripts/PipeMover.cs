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
        var tween1 =transform.DOMove(targetPosition, _animationDuration);
        var tween2 = transform.DORotate(targetRotation, _animationDuration);
        tween2.onComplete += ()=>
        {
            _ballsAttacher.Deattach();
            // Debug.Log($"id: {Ball.index++} pipe mover position: {transform.position}", this);
            Debug.Log($"{name} transform.position: {transform.position}");
            _pipe.LocationUpdated();
            tween1.Kill();
            tween2.Kill();
        };
    }
}