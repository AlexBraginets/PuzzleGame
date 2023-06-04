using System;
using UnityEngine;

public class TubeSwitcher : MonoBehaviour
{
    [SerializeField] private LayerMask _tubeMask;
    [SerializeField] private Pipe[] _pipes;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _switchAudio;
    [field: SerializeField] public int Position { get; private set; }
    public event Action OnSwitched;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            TrySwitch();
        }
    }

    private void TrySwitch()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (!Physics.Raycast(ray, out RaycastHit hit, 20, _tubeMask)) return;
        var tube = hit.transform.GetComponent<Pipe>();
        if (!tube)
        {
            Debug.LogError("No Pipe present.", hit.transform);
            throw new NotImplementedException("No Pipe present.");
        }

        Switch();
    }

    public void Switch()
    {
        PlayAudio();
        foreach (var pipe in _pipes)
        {
            pipe.OnLocationUpdated += CheckHasSwitched;
            pipe.Switch();
        }

        UpdatePosition();
    }

    private int _pipeLocationUpdatedCount;

    private void CheckHasSwitched()
    {
        _pipeLocationUpdatedCount++;
        if (_pipeLocationUpdatedCount != _pipes.Length) return;
        _pipeLocationUpdatedCount = 0;
        HasSwitched();
    }

    public void HasSwitched()
    {
        OnSwitched?.Invoke();
        OnSwitched = null;
    }

    private void PlayAudio()
    {
        _audioSource.PlayOneShot(_switchAudio);
    }

    private void UpdatePosition()
    {
        Position++;
        if (Position == 3) Position = 0;
    }
}