using UnityEngine;

public class BallsWayDataRefresher : MonoBehaviour
{
    [SerializeField] private WayDataHolder[] _wayDataHolders;
    [SerializeField] private PipePosDataProvider[] _pipePosDataProviders;
    public void Refresh(int wayIndex, Ball[] balls)
    {
        GetPosData(wayIndex, out PosData[] data);
        for (int i = 0; i < balls.Length; i++)
        {
            var ball = balls[i];
            ball.UpdateLines(_wayDataHolders[wayIndex].Lines);
            ball.UpdatePosData(data[i]);
        }
    }
    private void GetPosData(int wayIndex, out PosData[] data)
    {
        var posDataProvider = _pipePosDataProviders[wayIndex];
        data = posDataProvider.PosDatas;
    }
}
