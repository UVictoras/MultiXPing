using System;
using System.Runtime.CompilerServices;

namespace MultiXPing
{
    public class Character
    {
        /* ----------------------------------------------------- *\
        |                                                         |
        |                          Field                          |
        |                                                         | 
        \* ----------------------------------------------------- */
        #region Field

        int _maximumHealth;     // Maximum amount of health a character can have
        int _health;            // Current amount of health of the character
        float _physicalDamage;  // Amount of physical damage inflicted by the character
        float _physicalDefense; // Resistance of the character to physical damages
        float _magicalDamage;  // Amount of magical damage inflicted by the character
        float _magicalDefense; // Resistance of the character to magical damages
        float _speed;             // Attacking speed of the character
        float _accuracy;          // Precision of the character's attack
        int _maximumMana;       // Maximum amount of mana a character can have
        int _mana;              // Current amount of mana of the character
        int _experience;        // Current experience obtained by the character
        int _level;             // Current level of progression of the character
        bool _isAlive;          // Current state of the character, true if alive, false if dead
        Attack[] _attacks;      // List of the learned attacks
        Dictionary<int,Attack> _possibelAttacks;  // List of the attacks the character can learn

        string _name;              // Name of the character

        #endregion Field

        /* ----------------------------------------------------- *\
        |                                                         |
        |                        Property                         |
        |                                                         |
        \* ----------------------------------------------------- */
        #region Property

        public int MaximumHealth
        {
            get => _maximumHealth;
            protected set => _maximumHealth = value;
        }

        public int Health
        {
            get => _health;
            protected set => _health = value;
        }

        public float PhysicalDamage
        {
            get => _physicalDamage;
            protected set => _physicalDamage = value;
        }

        public float PhysicalDefense
        {
            get => _physicalDefense;
            protected set => _physicalDefense = value;
        }

        public float MagicalDamage
        {
            get => _magicalDamage;
            protected set => _magicalDamage = value;
        }

        public float MagicalDefense
        {
            get => _magicalDefense;
            protected set => _magicalDefense = value;
        }

        public float Speed
        {
            get => _speed;
            protected set => _speed = value;
        }
        public float Accuracy {
            get => _accuracy;
            protected set => _accuracy = value;
        }

        public int MaximumMana
        {
            get => _maximumMana;
            protected set => _maximumMana = value;
        }

        public int Mana
        {
            get => _mana;
            protected set => _mana = value;
        }

        public int Experience
        {
            get => _experience;
            private set => _experience = value;
        }

        public int Level
        {
            get => _level;
            set => _level = value;
        }

        public Attack[] Attacks
        {
            get => _attacks;
            private set => _attacks = value;
        }

        public bool IsAlive
        {
            get => _isAlive;
            set => _isAlive = value;
        }

        public string Name
        {
            get => _name;
            set => _name = value;
        }
        public Dictionary<int,Attack> PossibleAttacks
        {
            get => _possibelAttacks;
            private set => _possibelAttacks = value;
        }

        #endregion Property

        /* ----------------------------------------------------- *\
        |                                                         |
        |                          Event                          |
        |                                                         |
        \* ----------------------------------------------------- */
        #region Event

        public virtual event Action OnDamage;
        public virtual event Action OnDeath;

        #endregion Event

        /* ----------------------------------------------------- *\
        |                                                         |
        |                         Methods                         |
        |                                                         |
        \* ----------------------------------------------------- */
        #region Methods

        public Character()
        {
        }

        public void InitializeCharacter(string name)
        {
            Name = name;
            Level = 1;
            IsAlive = true;
        }

        public void Healing(int heal)
        {
            Health += heal;
            if (Health > MaximumHealth)
            {
                MaximumHealth = Health;
            }
        }
        public void ManaRegeneration(int mana)
        {
            Mana += mana;
            if (Mana > MaximumMana)
            {
                Mana = MaximumMana;
            }
        }
        public virtual void Death(){}

        #endregion Methods
    }
}