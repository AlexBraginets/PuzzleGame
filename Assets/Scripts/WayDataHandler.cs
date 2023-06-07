using UnityEngine;

public class WayDataHandler : MonoBehaviour
{
    [SerializeField] private WayDataHolder _dataHolder;
    [SerializeField] private int lineIndex;
    [SerializeField] private float localLength;

    public Vector3 GetPosition(int position)
    {
        Line[] lines = _dataHolder.Lines;
        var wayData = new WayData()
        {
            Lines = lines,
            LineIndex = lineIndex,
            LocalLength = localLength
        };
        wayData.LocalLength += position * 1.1f;
        return wayData.WorldPosiiton;
    }
}