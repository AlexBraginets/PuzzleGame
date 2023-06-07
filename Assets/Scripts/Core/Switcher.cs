namespace Core
{
    public class Switcher
    {
        public Track Track1;
        public Track Track2;

        private int _position = 0;

        public void Switch()
        {
            switch (_position)
            {
                case 0:
                    var ball0 = Track1[0];
                    var ball1 = Track1[1];
                    ball0.ChangeTrack(Track2);
                    ball1.ChangeTrack(Track2);
                    break;
            }

            _position++;
        }
    }
}