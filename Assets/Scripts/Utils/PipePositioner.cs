using UnityEngine;

namespace Utils
{
    public class PipePositioner : MonoBehaviour
    {
        [SerializeField] private Transform[] _waypoints;

        [SerializeField] private bool deactivate;

        private void Awake()
        {
            Allign();
            if (deactivate) gameObject.SetActive(false);
        }

        [ContextMenu("Allign")]
        private void Allign()
        {
            if (_waypoints.Length != 2)
            {
                Debug.LogError("_waypoints.Length != 2");
                return;
            }

            var a = _waypoints[0];
            var b = _waypoints[1];
            UpdateLocation(a.position, b.position);
        }

        private void UpdateLocation(Vector3 a, Vector3 b)
        {
            UpdatePosition(a, b);
            UpdateRotation(a, b);
        }

        private void UpdatePosition(Vector3 a, Vector3 b)
        {
            transform.position = (a + b) * .5f;
        }

        private void UpdateRotation(Vector3 a, Vector3 b)
        {
            transform.rotation = Quaternion.LookRotation(Vector3.forward, (b - a));
        }
    }
}