using System;
using DG.Tweening;
using UnityEngine;

public class Shuffler : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _duration;
    [SerializeField] private BallsContainer[] _ballsContainers;
    [SerializeField] private TubeSwitcher _tubeSwitcher;
    [SerializeField] private int _shuffleCount = 10;
    [SerializeField] private float _springSpeed;
    private System.Random _rnd = new System.Random();
    [SerializeField] private float _shuffleTimeScale;
    private int _shuffleIndex
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

    private void Start()
    {
        Time.timeScale = _shuffleTimeScale;
        Shuffle();
    }

    private void Shuffle()
    {
        float y = 0;
        int shuffleIndex = this._shuffleIndex;
        DOTween.To(() => 0f, x =>
        {
            MoveBalls(x - y, _ballsContainers[shuffleIndex]);
            y = x;
        }, _speed * _duration, _duration).onComplete += () =>
        {
           StabilizeBalls(_speed*_duration, shuffleIndex);
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
               }
           });
        };
    }

    private void MoveBalls(float dx, BallsContainer ballsContainer)
    {
        foreach (var ball in ballsContainer.Balls)
        {
            ball.Move(dx);
        }
    }

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
            MoveBalls(x - y, _ballsContainers[shuffleIndex]);
            y = x;
        }, dx, Mathf.Abs(dx / _springSpeed));
    }
}