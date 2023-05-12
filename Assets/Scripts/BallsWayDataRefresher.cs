using UnityEngine;

public class BallsWayDataRefresher : MonoBehaviour
{
    [SerializeField] private PipePosDataProvider[] _pipePosDataProviders;

    public void Refresh(int wayIndex, Ball[] balls)
    {
        GetWayData(wayIndex, out WayData[] data);
        for (int i = 0; i < balls.Length; i++)
        {
            var ball = balls[i];
            ball.UpdateWayData(data[i]);
        }
    }

    private void GetWayData(int wayIndex, out WayData[] data)
    {
        var posDataProvider = _pipePosDataProviders[wayIndex];
        data = posDataProvider.WayDatas;
    }
}