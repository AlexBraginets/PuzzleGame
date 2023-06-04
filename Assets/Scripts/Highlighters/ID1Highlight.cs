using UnityEngine;

public class ID1Highlight : MonoBehaviour
{
    public int containerId;
    public int id;
    [SerializeField] private Color _color;
    private void Start()
    {
        var ball = GetComponent<Ball>();
        if (ball.ContainerIndex == containerId && ball.id == id)
        {
            ball.GetComponent<MeshRenderer>().material.color = _color;
        }
    }
}
