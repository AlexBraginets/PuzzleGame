using System;
using DG.Tweening;
using UnityEngine;

public class Shuffler : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _duration;
    [SerializeField] private BallMover[] _ballMovers;
    [SerializeField] private TubeSwitcher _tubeSwitcher;
    [SerializeField] private int _shuffleCount = 10;
    [SerializeField] private float _springSpeed;
    private System.Random _rnd = new System.Random();
    [SerializeField] private float _shuffleTimeScale;
    public event Action OnFinished;

    private int ShuffleIndex
    {
        get
        {
            switch (_tubeSwitcher.Position)
            {
                case 0: return _rnd.Next(0, 2);
                case 1: return 1;
                case 2: return 0;
                default:
                    throw new NotImplementedException();
            }
        }
    }


    public void Shuffle()
    {
        Time.timeScale = _shuffleTimeScale;
        float y = 0;
        int shuffleIndex = ShuffleIndex;
        float shiftAmount = ShiftAmount;
        float duration = ShiftAmount / _speed;
        DOTween.To(() => 0f, x =>
        {
            _ballMovers[shuffleIndex].Move(x - y);
            y = x;
        }, shiftAmount, duration).onComplete += () =>
        {
            StabilizeBalls(shiftAmount, shuffleIndex);
            DOVirtual.DelayedCall(1.1f / _springSpeed, () =>
            {
                _tubeSwitcher.Switch();
                _shuffleCount--;
                if (_shuffleCount > 0)
                {
                    DOVirtual.DelayedCall(.22f, Shuffle);
                }
                else
                {
                    Time.timeScale = 1f;
                    OnFinished?.Invoke();
                }
            });
        };
    }

    private float ShiftAmount => _duration * _speed * (float) _rnd.NextDouble();


    private void StabilizeBalls(float _deltaMoved, int shuffleIndex)
    {
        if (_deltaMoved == 0f) return;
        _deltaMoved %= 1.1f;
        if (_deltaMoved < 0) _deltaMoved += 1.1f;
        float dx;
        if (_deltaMoved < 1.1f / 2f)
        {
            dx = -_deltaMoved;
        }
        else
        {
            dx = 1.1f - _deltaMoved;
        }

        float y = 0;
        DOTween.To(() => 0f, x =>
        {
            _ballMovers[shuffleIndex].Move(x - y);
            y = x;
        }, dx, Mathf.Abs(dx / _springSpeed));
    }
}