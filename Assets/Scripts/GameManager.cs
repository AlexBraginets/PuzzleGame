using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _winAudio;
    [SerializeField] private BallsContainer[] _containersToCompleted;
    private bool _hasWon;
    private void Start()
    {
        foreach (var container in _containersToCompleted)
        {
            container.OnCompleted += CheckWin;
        }
    }

    private void CheckWin()
    {
        foreach (var container in _containersToCompleted)
        {
            if (!container.IsCompleted()) return;
        }
        Win();
    }

    [ContextMenu("Win")]
    public void Win()
    {
        if (_hasWon) return;
        _hasWon = true;
        PlayAudio();
    }

    private void PlayAudio()
    {
        _audioSource.PlayOneShot(_winAudio);
    }
}