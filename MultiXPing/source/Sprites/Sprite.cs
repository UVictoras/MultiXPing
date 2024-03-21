namespace MultiXPing
{
    public struct PlayerSpirte
    {
        string _sprite;

        public string Sprite
        {
            get => _sprite; 
            set => _sprite = value;
        }

        public PlayerSpirte()
        {
            _sprite = " P \n" +
                      "PPP\n" +
                      " P\n" +
                      " P\n";
        }
    }
}
