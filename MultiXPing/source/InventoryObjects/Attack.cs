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

        string   _element;		    // Defines the specificity of the attack
		float	 _accuracy;         // Precision of the attack
		float	 _criticalRate;     // Critical rate of the attack
		int		 _damage;           // Amount of damage inflicted by the attack
		bool	 _isMagic;          // Whether the attack has a magical type or not

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
			set => _accuracy  = value;
		}

		public float CriticalRate
		{
			get => _criticalRate;
			set => _criticalRate = value;
		}

		public int Damage
		{
			get => _damage; 
			set => _damage = value;
		}

		public bool IsMagic
		{
			get => _isMagic; 
			set => _isMagic = value;
		}

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