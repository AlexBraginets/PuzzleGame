using System;

namespace Core
{
    public class BallData
    {
        public Track Track;
        public int Position;
        public int Color;
        public event Action<BallData, Track, Track> OnTrackChanged;

        public void ChangeTrack(Track track)
        {
            var previousTrack = Track;
            Track = track;
            OnTrackChanged?.Invoke(this, previousTrack, Track);
        }
    }
}