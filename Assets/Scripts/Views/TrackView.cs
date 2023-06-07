using System.Collections.Generic;
using Core;
using UnityEngine;
using Views;

public class TrackView : MonoBehaviour
{
    [SerializeField] private BallDataView _ballViewPrefab;
    private Track _track;
    private Level1View _levelView;
    [SerializeField] private List<BallDataView> _ballViews;

    public void Init(Level1View levelView, Track track)
    {
        _ballViews = new List<BallDataView>();
        _levelView = levelView;
        _track = track;
        foreach (var ball in track.Balls)
        {
            var ballView = Instantiate(_ballViewPrefab);
            ballView.Init(this, ball);
            ballView.name = $"ball: color: {ball.Color}; id: {ball.Position}";
            ballView.transform.parent = transform;
            _ballViews.Add(ballView);
            ball.OnTrackChanged += (b, t1, t2) => OnTrackChanged(ballView, t1, t2);
        }
    }

    private void OnTrackChanged(BallDataView ballView, Track arg1, Track arg2)
    {
        _levelView.GetTrackView(arg1)?._ballViews.Remove(ballView);
        _levelView.GetTrackView(arg2)?._ballViews.Add(ballView);
        ballView._trackView = _levelView.GetTrackView(arg2);
    }

    public void UpdateView()
    {
        foreach (var ballView in _ballViews)
        {
            ballView.UpdateView();
        }
    }

    public Vector3 GetPosition(BallData ballData)
    {
        int trackID = _track.ID;
        int position = ballData.Position;
        return _levelView.GetPosition(trackID, position);
    }
}