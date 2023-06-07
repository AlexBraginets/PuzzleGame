using System.Collections.Generic;

namespace Core
{
    public class Level1
    {
        public Track Track1;
        public Track Track2;
        public Switcher Switcher;

        public void Init()
        {
            InitTrack1();
            InitTrack2();
            InitSwitcher();
        }

        private void InitSwitcher()
        {
            Switcher = new Switcher()
            {
                Track1 = Track1,
                Track2 = Track2
            };
        }

        private void InitTrack1()
        {
            Track1 = new Track();
            Track1.ID = 1;
            Track1.Length = 24;
            for (int i = 0; i < Track1.Length; i++)
            {
                Track1.AddBall(new BallData()
                {
                    Color = Track1.ID,
                    Position = i,
                    Track = Track1
                });
            }
        }

        private void InitTrack2()
        {
            Track2 = new Track();
            Track2.ID = 2;
            Track2.Length = 24;
            for (int i = 0; i < Track2.Length; i++)
            {
                Track2.AddBall(new BallData()
                {
                    Color = Track2.ID,
                    Position = i,
                    Track = Track2
                });
            }
        }

        public void Switch()
        {
            Switcher.Switch();
        }
    }
}