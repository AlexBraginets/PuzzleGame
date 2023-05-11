using UnityEngine;

public class PipeMover : MonoBehaviour
{
    [SerializeField] private Transform[] _locations;

    public void UpdateLocation(int locationIndex)
    {
        transform.position = _locations[locationIndex].position;
        transform.rotation = _locations[locationIndex].rotation;
    }
}