using DG.Tweening;
using UnityEngine;

public class MoveBallFinalizer : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    private BallMover _ballMover;
    private float _lastMoved;
    private float _deltaMoved;

    public void Finalize(float deltaMoved, BallMover ballMover)
    {
        _deltaMoved = deltaMoved;
        _ballMover = ballMover;
        float dx = GetFinalDX();
        _lastMoved = 0f;
        DOTween.To(() => 0f, MoveBalls, dx, Mathf.Abs(dx / _moveSpeed));
    }

    private float GetFinalDX()
    {
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

        return dx;
    }
    private void MoveBalls(float x)
    {
        float dMove =  x -  _lastMoved;
        _lastMoved = x;
        _ballMover.Move(dMove);
    }
}