using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;

namespace Utils
{
    public class WayDataInfoDisplay : MonoBehaviour
    {
        [FormerlySerializedAs("_wayData")] [SerializeField] private WayDataHolder wayDataHolder;

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
                Line[] lines = wayDataHolder.Lines;
                float length = lines.Sum(line => line.Length);
                return length;
            }
        }
    }
}