using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private WayData _wayData = new WayData();

    public Transform Parent
    {
        get => transform.parent;
        set => transform.parent = value;
    }

    public void UpdateLines(Line[] lines) => _wayData.Lines = lines;

    public void UpdatePosData(PosData data)
    {
        _wayData.LineIndex = data.LineIndex;
        _wayData.LocalLength = data.LocalLength;
    }

    public void SetDistance(float distance) => _wayData.LocalLength = distance;
    public void SetLineIndex(int lineIndex) => _wayData.LineIndex = lineIndex;

    public void Move(float distance)
    {
        if (distance == 0) return;
        _wayData.LocalLength += distance;
        Move(_wayData.WorldPosiiton);
    }

    private void Move(Vector3 position)
    {
        transform.position = position;
    }
}