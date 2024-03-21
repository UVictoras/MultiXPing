namespace MultiXPing
{
    public struct Vector2
    {
        /* ----------------------------------------------------- *\
        |                                                         |
        |                          Field                          |
        |                                                         | 
        \* ----------------------------------------------------- */
        #region Field

        int _x;          // X axis 
        int _y;          // Y axis

        #endregion Field

        /* ----------------------------------------------------- *\
        |                                                         |
        |                        Property                         |
        |                                                         |
        \* ----------------------------------------------------- */
        #region Property

        public int X
        {
            get => _x;
            set => _x = value;
        }

        public int Y
        {
            get => _y;
            set => _y = value;
        }
        #endregion Property

        #region Constructeur

        public Vector2(int x, int y) {
            _x = x;
            _y = y;
        }
        

        #endregion Constructeur 

    }
}