namespace MultiXPing
{
	public struct Attack
	{
		/* --------------------------------------------------------
		|                                                         |
		|                          Field                          |
		|                                                         |
		-------------------------------------------------------- */
		#region Field

		public string	 _type;				// Defines the specificity of the attack
		public float	 _precision;        // Precision of the attack
		public float	 _criticalRate;     // Critical rate of the attack
		public int		 _damage;           // Amount of damage inflicted by the attack
		public bool		 _isMagic;			// Whether the attack has a magical type or not

		#endregion Field

		/* --------------------------------------------------------
        |                                                         |
        |                        Property                         |
        |                                                         |
        -------------------------------------------------------- */
		#region Property

		public string Type
		{
			get => _type; 
			set => _type = value;
		}

		public float Precision
		{
			get => _precision;
			set => _precision = value;
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

		#endregion Methods
	}
}