using System;
using UnityEngine;

public class PlaneRaycaster : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private Vector3 _inPoint = Vector3.zero;
    [SerializeField] private Vector3 _normal = Vector3.forward;

    public Vector3 GetMousePosition()
    {
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
        Plane plane = new Plane(_normal, _inPoint);
        if (plane.Raycast(ray, out float enter))
        {
            return ray.GetPoint(enter);
        }

        throw new Exception("Ray not hitting a plane.");
    }
}
