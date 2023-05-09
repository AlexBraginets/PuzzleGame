using System;
using UnityEngine;

public class BallLocator : MonoBehaviour
{
    [SerializeField] private LayerMask _ballLayerMask;
    public Ball GetBall()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        if (Physics.Raycast(ray, out var hit, 1, _ballLayerMask))
        {
            return hit.transform.GetComponent<Ball>();
        }

        throw new NotImplementedException();
    }
}
