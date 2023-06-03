using UnityEngine;

public class BallsWayDataRefresher : MonoBehaviour
{
    [SerializeField] private PipeWayDataProvider[] _pipeWayDataProviders;
    [SerializeField] private bool[] refreshMap;

    private Pipe _pipe;

    public void Init(Pipe pipe)
    {
        _pipe = pipe;
        pipe.OnLocationUpdated += Refresh;
    }

    private void Refresh()
    {
        Refresh(_pipe.CurrentLocation.value, _pipe.Balls);
    }

    private void Refresh(int wayIndex, Ball[] balls)
    {
        if (!refreshMap[wayIndex]) return;
        GetWayData(wayIndex, out WayData[] data);
        InjectWayData(balls, data);
    }

    private void InjectWayData(Ball[] balls, WayData[] data)
    {
        for (int i = 0; i < balls.Length; i++)
        {
            var ball = balls[i];
            var wayData = data[i];
            ball.UpdateWayData(wayData);
        }
    }

    private void GetWayData(int wayIndex, out WayData[] data)
    {
        var wayDataProvider = _pipeWayDataProviders[wayIndex];
        data = wayDataProvider.WayDatas;
    }
}