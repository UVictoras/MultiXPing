namespace MultiXPing
{
    public struct Attack
    {
        /* ----------------------------------------------------- *\
        |                                                         |
        |                          Field                          |
        |                                                         | 
        \* ----------------------------------------------------- */
        #region Field

        string _name;
        string _element;            // Defines the specificity of the attack
        float _accuracy;         // Precision of the attack
        int _damage;           // Amount of damage inflicted by the attack
        int _magicCost;          // Whether the attack has a magical type or not
        object _function;
        string _descriptor;
        string _class;

        #endregion Field

        /* ----------------------------------------------------- *\
        |                                                         |
        |                        Property                         |
        |                                                         |
        \* ----------------------------------------------------- */
        #region Property

        public string Element
        {
            get => _element;
            set => _element = value;
        }

        public float Accuracy
        {
            get => _accuracy;
            set => _accuracy = value;
        }

        public int Damage
        {
            get => _damage;
            set => _damage = value;
        }
        public int MagicCost { get => _magicCost; set => _magicCost = value; }
        public string Descriptor { get => _descriptor; set => _descriptor = value; }
        public string Class { get => _class; set => _class = value; }
        public string Name { get => _name; set => _name = value; }
        public object Function { get => _function; set => _function = value; }

        #endregion Property

        /* ----------------------------------------------------- *\
        |                                                         |
        |                          Event                          |
        |                                                         |
        \* ----------------------------------------------------- */
        #region Event

        #endregion Event

        /* ----------------------------------------------------- *\
        |                                                         |
        |                         Methods                         |
        |                                                         |
        \* ----------------------------------------------------- */
        #region Methods

        #endregion Methods
    }

    

}