using UnityEngine;
using Utils;

public class Ball : MonoBehaviour
{
    [SerializeField] private WayData _wayData = new WayData();

    public Transform Parent
    {
        get => transform.parent;
        set => transform.parent = value;
    }

    private int _lineIndex;

    private int LineIndex
    {
        get => _lineIndex;
        set
        {
            int linesCount = _wayData.Lines.Length;
            _lineIndex = value;
            if (_lineIndex < 0) _lineIndex += linesCount;
            else if (_lineIndex >= linesCount) _lineIndex -= linesCount;
            _wayData.LineIndex = LineIndex;
            Debug.Log($"LineIndex:{value}->{_lineIndex}");
        }
    }

    public void UpdateLines(Line[] lines) => _wayData.Lines = lines;

    public void UpdatePosData(PosData data)
    {
        _wayData.LineIndex = data.LineIndex;
        _wayData.LocalLength = data.LocalLength;
    }

    public void SetDistance(float distance) => _wayData.LocalLength = distance;
    public void SetLineIndex(int lineIndex) => LineIndex = lineIndex;

    public void Move(float distance)
    {
        if (distance == 0) return;
        MovePositive(distance);
    }

    private void MovePositive(float distance)
    {
        _wayData.LocalLength += distance;
        _wayData.Simplify();
        Line[] lines = _wayData.Lines;
        LineIndex = _wayData.LineIndex;
        Line line = lines[LineIndex];
        var position = line.GetPoint(_wayData.LocalLength);
        Move(position);
    }

    // private void MoveNegative(float distance)
    // {
    //     Line[] lines = wayDataHolder.Lines;
    //     Line line = lines[LineIndex];
    //     _localLength -= distance;
    //     if (_localLength <= 0)
    //     {
    //         LineIndex--;
    //         if (LineIndex < 0) LineIndex = lines.Length - 1;
    //         line = lines[LineIndex];
    //         float lineLength = line.Length;
    //         _localLength += lineLength;
    //     }
    //
    //     var position = line.GetPoint(_localLength);
    //     Move(position);
    // }


    private void Move(Vector3 position)
    {
        transform.position = position;
    }
}