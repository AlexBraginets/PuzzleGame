using UnityEngine;

public class BaseInputController : MonoBehaviour
{
   protected bool MouseDown => Input.GetMouseButtonDown(0);
   protected bool MouseUp => Input.GetMouseButtonUp(0);
}
