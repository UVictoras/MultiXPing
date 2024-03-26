using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MultiXPing
{
	class Attack: NodeObject
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
        public Attack(){}
        public void UseAttack(Character attacker, Character target)
        {
            int damage = 0;
            if (IsMagic)
            {
                damage = (int)(Damage * (attacker.MagicalDamage / target.MagicalDefense));
            }
            else
            {
                damage = (int)(Damage * (attacker.PhysicalDamage / target.PhysicalDefense));
            }
            target.TakeDamage(damage);
        }
        #endregion Methods
    }
}