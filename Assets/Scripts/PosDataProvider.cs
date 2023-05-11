using UnityEngine;

public class PosDataProvider : MonoBehaviour
{
    [field: SerializeField] public WayDataHolder WayDataHolder { get; private set; }
    public int wayIndex;
    public float localLength;

    [ContextMenu("Inject")]
    private void Inject()
    {
        var pos = transform.position;
        pos.z = 0f;
        GetPosData(pos, out wayIndex, out localLength);
    }

    public PosData GetPosData() => new PosData() {LineIndex = wayIndex, LocalLength = localLength};

    private void GetPosData(Vector3 pos, out int wayIndex, out float localLength)
    {
        Line[] lines = WayDataHolder.Lines;
        float distance;
        float minDistance = float.MaxValue;
        Vector3 minPoint = pos;
        wayIndex = -1;
        int i = 0;
        foreach (var line in lines)
        {
            Vector3 point = line.ClosestPoint(pos, out distance);
            if (distance < minDistance)
            {
                minDistance = distance;
                minPoint = point;
                wayIndex = i;
            }

            i++;
        }

        localLength = lines[wayIndex].Distance(minPoint);
    }
}