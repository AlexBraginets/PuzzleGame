using System.Collections.Generic;
using System.Linq;

namespace Core
{
    public class Track
    {
        public BallData this[int position] => Balls.First(b => b.Position == position);
        public List<BallData> Balls = new List<BallData>();
        public int ID;
        public int Length;

        public void AddBall(BallData data)
        {
            Balls.Add(data);
            data.Track = this;
            data.OnTrackChanged += OnTrackChanged;
        }

        private void OnTrackChanged(BallData ball, Track arg1, Track arg2)
        {
            arg1?.Balls.Remove(ball);
            arg2.Balls.Add(ball);
        }
    }
}