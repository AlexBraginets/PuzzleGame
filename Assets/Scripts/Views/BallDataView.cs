using Core;
using Data;
using UnityEngine;

public class BallDataView : MonoBehaviour
{
    [SerializeField] private BallDataViewConfig _config;
    private BallData _ballData;
    public TrackView _trackView;
    

    public void Init(TrackView trackView, BallData ballData)
    {
        _ballData = ballData;
        _trackView = trackView;
        SetColor(_config.GetColor(ballData));
        UpdateView();
    }

    public void UpdateView()
    {
        transform.position = _trackView.GetPosition(_ballData);
    }

    private void SetColor(Color color)
    {
        GetComponent<MeshRenderer>().material.color = color;
    }
}