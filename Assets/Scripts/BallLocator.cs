using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BallLocator : MonoBehaviour
{
    public Ball GetBall(List<Ball> balls)
    {
        return balls.OrderBy(x=>Vector3.Distance(transform.position, x.transform.position)).First();
    }
}
