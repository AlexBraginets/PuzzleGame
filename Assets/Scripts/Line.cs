using UnityEngine;

public class Line
{
   public Line(Vector3 a, Vector3 b)
   {
      this.a = a;
      this.b = b;
   }

   public float Length => Vector3.Distance(a, b);
   public readonly Vector3 a;
   public readonly Vector3 b;

   public Vector3 GetPoint(float distance)
   {
      return a + (b - a).normalized * distance;
   }
   public Vector3 ClosestPoint(Vector3 point, out float distance)
   {
      return ClosestPointOnLine(a, b, point, out distance);
   }

   public float Distance(Vector3 point) => Vector3.Distance(a, point);
   private  static Vector3 ClosestPointOnLine(Vector3 vA, Vector3 vB, Vector3 vPoint, out float distance)
   {
      var vVector1 = vPoint - vA;
      var vVector2 = (vB - vA).normalized;

      var d = Vector3.Distance(vA, vB);
      var t = Vector3.Dot(vVector2, vVector1);

      distance = Distance(vA, vB, vPoint);
      if (t <= 0)
         return vA;

      if (t >= d)
         return vB;
      var vVector3 = vVector2 * t;

      var vClosestPoint = vA + vVector3;

      return vClosestPoint;
   }

   private static float Distance(Vector3 vA, Vector3 vB, Vector3 vPoint)
   {
      Vector3 dir = (vA - vB).normalized;
      Vector3 along = vPoint - vA;
      float distance = Vector3.Cross(dir, along).magnitude;
      return distance;
   }
}
