using UnityEngine;

namespace Testers
{
    public class PipeBallsProviderTester : MonoBehaviour
    {
        [SerializeField] private PipeBallsProvider _pipeBallsProvider;

        [ContextMenu("Test")]
        private void Test()
        {
            var balls = _pipeBallsProvider.GetBalls();
            Color rndColor = Random.ColorHSV();
            foreach (var ball in balls)
            {
                ball.GetComponent<MeshRenderer>().material.color = rndColor;
            }
        }
    }
}
