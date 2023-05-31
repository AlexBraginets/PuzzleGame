using UnityEngine;
using Random = UnityEngine.Random;

public class RandomColor : MonoBehaviour
{
    [SerializeField] private MeshRenderer _meshRenderer;
    [SerializeField] private Color _color;
    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        SetRandomColor();
    }

    private void SetRandomColor()
    {
        var rndColor = Random.ColorHSV();
        rndColor = _color;
        SetColor(rndColor);
    }

    public void SetColor(Color color) => _meshRenderer.material.color = color;
}