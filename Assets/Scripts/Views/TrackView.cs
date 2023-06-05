using Core;
using UnityEngine;

public class TrackView : MonoBehaviour
{
    [SerializeField] private BallDataView _ballViewPrefab;
    private Track _track;

    public void Init(Track track)
    {
        _track = track;
        foreach (var ball in track.Balls)
        {
            var ballView = Instantiate(_ballViewPrefab);
            ballView.Init(ball);
            ballView.name = $"ball: color: {ball.Color}; id: {ball.Position}";
            ballView.transform.parent = transform;
        }
    }
}