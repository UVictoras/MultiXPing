using static System.Net.Mime.MediaTypeNames;

namespace MultiXPing
{
    public struct PlayerSprite
    {
        string _sprite;
        int _width = 0;
        int _height = 0;

        public string Sprite
        {
            get => _sprite; 
            set => _sprite = value;
        }
        public int Width { get => _width; set => _width = value; }
        public int Height { get => _height; set => _height = value; }

        public PlayerSprite()
        {
            //_sprite = " S \n" +
            //          "TTT\n" +
            //          "STS\n" +
            //          " O\n" +
            //          " O\n";

            _sprite = "O";

            Width = WidthSprite();
            Height = HeightSprite();

        }

        public int WidthSprite()
        {
            return (_sprite.IndexOf("\n"));
        }

        public int HeightSprite()
        {
            int count = 0;
            foreach (char c in _sprite)
            {
                if (c == '\n')
                {
                    count++;
                }
            }
            return count + 1;
        }

    }

}
