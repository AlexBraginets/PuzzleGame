using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BallLocator : MonoBehaviour
{
    public Ball GetBall(List<Ball> balls, out float distance)
    {
        var ball = balls.OrderBy(x=>Vector3.Distance(transform.position, x.transform.position)).First();
        distance = Vector3.Distance(transform.position, ball.transform.position);
        var bs12 = balls.Where(b => Vector3.Distance(transform.position, b.transform.position) < .91f).ToList(); 
        if (bs12.Count > 1)
        {
            Debug.LogError("several balls with distance less than .91 to a locator");
            foreach (var b in bs12)
            {
                Debug.LogError($"ball in proximity: {b}", b.gameObject);
            }

            var b0 = bs12[0];
            var b1 = bs12[1];
            Debug.Log($"id: {Ball.index++} bs12[0]: {b0.transform.position}", b0.gameObject);
            Debug.Log($"id: {Ball.index++} bs12[1]: {b1.transform.position}", b1.gameObject);
            // Debug.Break();
        }
        return ball;
    }
}
