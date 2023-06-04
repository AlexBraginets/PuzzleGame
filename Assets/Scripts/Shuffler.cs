using System;
using DG.Tweening;
using UnityEngine;

public class Shuffler : MonoBehaviour
{
    public event Action OnFinished;
    [SerializeField] private float _speed;
    [SerializeField] private float _duration;
    [SerializeField] private BallMover[] _ballMovers;
    [SerializeField] private TubeSwitcher _tubeSwitcher;
    [SerializeField] private int _shuffleCount = 10;
    [SerializeField] private float _springSpeed;
    [SerializeField] private float _shuffleTimeScale;
    private System.Random _rnd = new System.Random();

    private int WayToShuffleIndex => _tubeSwitcher.GetOpenWays().Random();


    public void Shuffle()
    {
        Time.timeScale = _shuffleTimeScale;
        float y = 0;
        int shuffleIndex = WayToShuffleIndex;
        float shiftAmount = ShiftAmount;
        float duration = shiftAmount / _speed;


        var ballMover = _ballMovers[shuffleIndex];
        ballMover.Begin();
        DOTween.To(() => 0f, x =>
        {
            ballMover.Move(x - y);
            y = x;
        }, shiftAmount, duration).onComplete += () =>
        {
            ballMover.OnFinilized += () =>
            {
                _tubeSwitcher.Switch();
                _shuffleCount--;
                if (_shuffleCount > 0)
                {
                    _tubeSwitcher.OnSwitched += Shuffle;
                    Debug.Log("_tubeSwitcher.OnSwitched += Shuffle;");
                }
                else
                {
                    Time.timeScale = 1f;
                    OnFinished?.Invoke();
                }
            };
            ballMover.DoFinalize();
        };
    }

    private float ShiftAmount => _duration * _speed * (float) _rnd.NextDouble();
}