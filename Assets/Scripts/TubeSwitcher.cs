using System;
using UnityEngine;

public class TubeSwitcher : MonoBehaviour
{
    [SerializeField] private LayerMask _tubeMask;
    [SerializeField] private Pipe[] _pipes;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Switch();
        }
    }

    private void Switch()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (!Physics.Raycast(ray, out RaycastHit hit, 20, _tubeMask)) return;
        var tube = hit.transform.GetComponent<Pipe>();
        if (!tube)
        {
            Debug.LogError("No Pipe present.", hit.transform);
            throw new NotImplementedException("No Pipe present.");
        }

        foreach (var pipe in _pipes)
        {
            pipe.Switch();
        }
    }
}
