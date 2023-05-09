using System.Linq;
using UnityEngine;

namespace Utils
{
    public class WayDataInfoDisplay : MonoBehaviour
    {
        [SerializeField] private WayData _wayData;

        [ContextMenu("Log info")]
        public void LogInfo()
        {
            LogInfo(Length);
        }

        public void LogInfo(float length)
        {
            Debug.Log($"WayData length: {length}");
            Debug.Log($"WayData length % 1.1f: {length % 1.1f}");
        }

        public float Length
        {
            get
            {
                Line[] lines = _wayData.Lines;
                float length = lines.Sum(line => line.Length);
                return length;
            }
        }
    }
}