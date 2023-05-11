using UnityEngine;
using Random = UnityEngine.Random;

public class RandomColor : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<MeshRenderer>().material.color = Random.ColorHSV();
    }
}
