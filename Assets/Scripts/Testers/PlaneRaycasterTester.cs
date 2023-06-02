using UnityEngine;

namespace Testers
{
    public class PlaneRaycasterTester : MonoBehaviour
    {
        [SerializeField] private PlaneRaycaster _planeRaycaster;
        [SerializeField] private Transform _target;

        private void Update()
        {
            _target.transform.position = _planeRaycaster.GetMousePosition();
        }
    }
}
