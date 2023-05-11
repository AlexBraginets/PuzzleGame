using UnityEngine;
using Utils;

[System.Serializable]
public class WayData
{
    public Line[] Lines;

    private int _lineIndex;

    public int LineIndex
    {
        get => _lineIndex;
        set
        {
            int linesCount = Lines.Length;
            _lineIndex = value;
            if (_lineIndex < 0) _lineIndex += linesCount;
            else if (_lineIndex >= linesCount) _lineIndex -= linesCount;
        }
    }

    private float _localLength;

    public float LocalLength
    {
        get => _localLength;
        set
        {
            _localLength = value;
            this.Simplify();
        }
    }

    public void HardSet(int lineIndex, float localLength)
    {
        _lineIndex = lineIndex;
        _localLength = localLength;
    }

    public Line CurrentLine => Lines[_lineIndex];
    public Vector3 WorldPosiiton => CurrentLine.GetPoint(LocalLength);
}