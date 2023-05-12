using DG.Tweening;
using UnityEngine;

public class BallsHighlighter : MonoBehaviour
{
    [SerializeField] private float highlightDuration;
    [SerializeField] private Color defaultColor;
    [SerializeField] private Color highlightColor;

    public void Highlight(Ball[] balls)
    {
        foreach (var ball in balls)
        {
            var rndColor = ball.GetComponent<RandomColor>();
            rndColor.SetColor(highlightColor);
            DOVirtual.DelayedCall(highlightDuration, () => rndColor.SetColor(defaultColor));
        }
    }
}