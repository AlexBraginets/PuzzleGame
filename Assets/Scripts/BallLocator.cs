using System;
using UnityEngine;

public class BallLocator : MonoBehaviour
{
    [SerializeField] private Ball _targetBall;
    [SerializeField] private LayerMask _ballLayerMask;
    public Ball GetBall()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        if (Physics.Raycast(ray, out var hit))
        {
            return hit.transform.GetComponent<Ball>();
        }
        else
        {
            Debug.Log($"Ball locator has not hit a ball. transform.position: {transform.position}", gameObject);
            Debug.Log($"targetBall.position: {_targetBall.transform.position}");
            Debug.Break();
        }

        throw new NotImplementedException();
    }

    [SerializeField] private Ball _refBall;

    [ContextMenu("Get ref ball")]
    private void GetRefBall()
    {
        _refBall = GetBall();
    }
}
