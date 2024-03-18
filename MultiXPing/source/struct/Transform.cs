namespace MultiXPing
{
    public struct Vector2
    {
        public float    x; 
        public float    y;
    }
    public struct Transform
    {
        /* --------------------------------------------------------
        |                                                         |
        |                          Field                          |
        |                                                         |
        -------------------------------------------------------- */
        #region Field

        public Vector2      _pos;           // Position of the entity on the map
        public Vector2      _dir;           // Direction of the entity

        #endregion Field

        /* --------------------------------------------------------
        |                                                         |
        |                        Property                         |
        |                                                         |
        -------------------------------------------------------- */
        #region Property

        public Vector2 Position
        {
            get => _pos; 
            set => _pos = value;
        }

        public Vector2 Direction
        {
            get => _dir;
            set => _dir = value;
        }

        #endregion Property

        /* --------------------------------------------------------
        |                                                         |
        |                          Event                          |
        |                                                         |
        -------------------------------------------------------- */
        #region Event

        #endregion Event

        /* --------------------------------------------------------
        |                                                         |
        |                         Methods                         |
        |                                                         |
        -------------------------------------------------------- */
        #region Methods

        public void Move(Vector2 dir, float deltaTime) 
        {
            _pos.x = dir.x * deltaTime;
            _pos.y = dir.y * deltaTime;
        }

        public void Rotate(int dir)
        {
            switch (dir)
            {
                case 0: //Turn left
                    _dir.x = -1;
                    _dir.y = 0;
                    break;
                case 1: //Turn top
                    _dir.x = 0; 
                    _dir.y = 1;
                    break;
                case 2: // Turn right
                    _dir.x = 1;
                    _dir.y = 0;
                    break;
                case 3: //Turn down
                    _dir.x = 0;
                    _dir.y = -1;
                    break;
            }
        }

        #endregion Methods
    }
}