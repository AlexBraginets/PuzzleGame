using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private WayData _wayData;
    [SerializeField]private int _lineIndex;
    private float _lineDistance;
    private float _distance;
    [SerializeField] private float deltaMoved;
    public void SetDistance(float distance)
    {
        _distance = distance;
    }

    public void SetWayData(WayData wayData)
    {
        _wayData = wayData;
    }

    public void SetLineIndex(int lineIndex)
    {
        _lineIndex = lineIndex;
    }

    public void Move(float distance)
    {
        deltaMoved += distance;
        if (distance > 0)
        {
            MovePositive(distance);
            return;
        }

        MoveNegative(-distance);
    }

    private void MoveNegative(float distance)
    {
        Line[] lines = _wayData.Lines;
        Line line = lines[_lineIndex];
        _distance -= distance;
        if (_distance <= 0)
        {
            _lineIndex--;
            Debug.Log($"distance < 0, _lineIndex: {_lineIndex}", gameObject);
            if (_lineIndex < 0) _lineIndex = lines.Length - 1;
            line = lines[_lineIndex];
            float lineLength = line.Length;
            _distance += lineLength;
           
        }

        var position = line.GetPoint(_distance);
        Move(position);
    }

    private void MovePositive(float distance)
    {
        Line[] lines = _wayData.Lines;
        Line line = lines[_lineIndex];
        float lineLength = line.Length;
        _distance += distance;
        if (_distance >= lineLength)
        {
            _distance -= lineLength;
            _lineIndex++;
            Debug.Log($"_lineIndex++: {_lineIndex}",gameObject);
            _lineIndex %= lines.Length;
            line = lines[_lineIndex];
        }

        var position = line.GetPoint(_distance);
        Move(position);
    }

    private void Move(Vector3 position)
    {
        transform.position = position;
    }
}