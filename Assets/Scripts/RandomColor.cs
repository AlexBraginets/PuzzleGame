using UnityEngine;
using Random = UnityEngine.Random;

public class RandomColor : MonoBehaviour
{
    [SerializeField] private MeshRenderer _meshRenderer;

    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        SetRandomColor();
    }

    private void SetRandomColor()
    {
        var rndColor = Random.ColorHSV();
        SetColor(rndColor);
    }

    public void SetColor(Color color) => _meshRenderer.material.color = color;
}