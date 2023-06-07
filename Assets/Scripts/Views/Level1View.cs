using Core;
using UnityEngine;

namespace Views
{
    public class Level1View : MonoBehaviour
    {
        [SerializeField] private TrackView _trackViewPrefab;
        [SerializeField] private WayDataHandler[] _wayDataHandlers;

        private Level1 _level;
        private TrackView _track1View;
        private TrackView _track2View;

        private void Awake() => Init();

        public TrackView GetTrackView(Track track)
        {
            if (track == _level.Track1) return _track1View;
            if (track == _level.Track2) return _track2View;
            return null;
        }

        [ContextMenu("Switch")]
        private void Switch()
        {
            _level.Switch();
            UpdateView();
        }

        private void UpdateView()
        {
            _track1View.UpdateView();
            _track2View.UpdateView();
        }

        private void Init()
        {
            _level = new Level1();
            _level.Init();
            _track1View = Instantiate(_trackViewPrefab);
            _track1View.Init(this, _level.Track1);
            _track1View.name = "Track1";
            _track1View.transform.parent = transform;
            _track2View = Instantiate(_trackViewPrefab);
            _track2View.Init(this, _level.Track2);
            _track2View.name = "Track2";
            _track2View.transform.parent = transform;
        }

        public Vector3 GetPosition(int trackID, int position)
        {
            var dataHandler = _wayDataHandlers[trackID - 1];
            return dataHandler.GetPosition(position);
        }
    }
}