using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _winAudio;
    [SerializeField] private BallsContainer[] _containersToCompleted;
    [SerializeField] private TubeSwitcher _tubeSwitcher;
    public static bool IsPaused = false;
    private bool _hasWon;
    private void Start()
    {
        _tubeSwitcher.OnSwitchedStatic += CheckWin;
        Application.targetFrameRate = 60;
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