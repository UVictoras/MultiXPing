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

        float       _x;          // X axis 
        float       _y;          // Y axis

        #endregion Field

        /* ----------------------------------------------------- *\
        |                                                         |
        |                        Property                         |
        |                                                         |
        \* ----------------------------------------------------- */
        #region Property

        public float X
        {
            get => _x; 
            private set => _x = value;
        }

        public float Y
        {
            get => _y; 
            private set => _y = value;
        }
        #endregion Property
    }
}