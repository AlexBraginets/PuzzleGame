using Core;
using Data;
using UnityEngine;

public class BallDataView : MonoBehaviour
{
    [SerializeField] private BallDataViewConfig _config;
    private BallData _ballData;

    public void Init(BallData ballData)
    {
        _ballData = ballData;
        SetColor(_config.GetColor(ballData));
    }

    private void SetColor(Color color)
    {
        GetComponent<MeshRenderer>().material.color = color;
    }
}