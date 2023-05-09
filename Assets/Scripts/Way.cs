using System.Linq;
using UnityEngine;

public class Way : MonoBehaviour
{
    [SerializeField] private WayData _wayData;
    private Vector3 _point;
    [SerializeField] private Transform _pointMarker;
    private void Awake()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Plane plane = new Plane(Vector3.forward, Vector3.zero);
        if (plane.Raycast(ray, out float enter))
        {
            var point = ray.GetPoint(enter);

            Line[] lines = _wayData.Lines;
            float distance;
            float minDistance = float.MaxValue;
            Vector3 minPoint = _point;
            foreach (var line in lines)
            {
                _point = line.ClosestPoint(point, out distance);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    minPoint = _point;
                }
            }

            _point = minPoint;
            _pointMarker.position = _point;
            

        }
        
    }

    private void Update()
    {
        Awake();
    }

    
}