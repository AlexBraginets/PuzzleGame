using UnityEngine;
using ZergRush.ReactiveCore;

[CreateAssetMenu]
public class IndexConfig : ScriptableObject
{
    [SerializeField] private int _initIndex;
    private Cell<int> _cell;

    public void Init(Cell<int> cell)
    {
        _cell = cell;
        cell.value = _initIndex;
    }

    public void Next()
    {
        int index = _cell.value;
        index++;
        index %= 3;
        _cell.value = index;
    }
}