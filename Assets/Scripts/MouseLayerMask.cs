using UnityEngine;

public class MouseLayerMask : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private LayerMask _abortMask;

    public bool Abort()
    {
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
        return Physics.Raycast(ray, 100, _abortMask);
    }
}
