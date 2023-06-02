using UnityEngine;

public class MouseInfo : MonoBehaviour
{
    [SerializeField] private Vector2 _mousePosition;
    private void Update()
    {
        _mousePosition = Input.mousePosition;
    }
}
