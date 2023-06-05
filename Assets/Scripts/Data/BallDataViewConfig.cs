using System.Linq;
using Core;
using UnityEngine;

namespace Data
{
    [CreateAssetMenu]
    public class BallDataViewConfig : ScriptableObject
    {
        [SerializeField] private Config[] _configs;

        public Color GetColor(BallData data) => GetConfig(data).Color;

        private Config GetConfig(BallData data) => _configs.First(x => x.ColorID == data.Color);

        [System.Serializable]
        private class Config
        {
            public int ColorID;
            public Color Color;
        }
    }
}