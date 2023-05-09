using UnityEngine;

namespace Utils
{
    public class WaypointsMover : MonoBehaviour
    {
        [SerializeField] private WayDataInfoDisplay _display;
        [SerializeField] private Vector3 offset;
        [SerializeField] private Transform[] waypoints;
        private Transform waypointsParent;
        [SerializeField] private float maxDx = 1f;
        [SerializeField] private float stepsCount = 1000;

        [ContextMenu("ApplyOffset")]
        private void ApplyOffset()
        {
            transform.position = waypoints[0].position;
            AttachWaypoints();
            transform.position = offset;
            DetachWaypoints();
            _display.LogInfo();
        }

        [ContextMenu("Adjust")]
        private void Adjust()
        {
            var offsetCopy = offset;
            float dx = maxDx / stepsCount;
            float minLength = float.MaxValue;
            Vector3 minOffset = new Vector3();
            for (int i = 0; i < stepsCount; i++)
            {
                offset = offsetCopy + Vector3.right * Mathf.Lerp(0, maxDx, i / stepsCount);
                ApplyOffset();
                if ((_display.Length % 1.1f) < minLength)
                {
                    minOffset = offset;
                    minLength = _display.Length % 1.1f;
                }
            }

            Debug.Log($"min offset: {minOffset.ToString("N10")}, minLength: {minLength}");
            offset = offsetCopy;
        }

        private void AttachWaypoints()
        {
            waypointsParent = waypoints[0].parent;
            foreach (var waypoint in waypoints)
            {
                waypoint.parent = transform;
            }
        }

        private void DetachWaypoints()
        {
            foreach (var waypoint in waypoints)
            {
                waypoint.parent = waypointsParent;
            }
        }
    }
}