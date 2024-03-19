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

        int      _maximumHealth;     // Maximum amount of health a character can have
        int      _health;            // Current amount of health of the character
        int      _damage;            // Amount of damage inflicted by the character
        int      _defense;           // Resistance of the character to damages
        int      _speed;             // Attacking speed of the character
        int      _precision;         // Precision of the character's attack
        int      _maximumMana;       // Maximum amount of mana a character can have
        int      _mana;              // Current amount of mana of the character
        int      _experience;        // Current experience obtained by the character
        int      _level;             // Current level of progression of the character
        Attack[] _attacks;           // List of the possible attacks

        string   _name;              // Name of the character

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
            private set => _maximumHealth = value;
        }

        public int Health
        {
            get => _health;
            private set => _health = value;
        }

        public int Damage
        {
            get => _damage;
            private set => _damage = value;
        }

        public int Defense
        {
            get => _defense;
            private set => _defense = value;
        }

        public int Speed
        {
            get => _speed;
            private set => _speed = value;
        }

        public int Precision
        {
            get => _precision;
            private set => _precision = value;
        }

        public int MaximumMana
        {
            get => _maximumMana;
            private set => _maximumMana = value;
        }

        public int Mana
        {
            get => _mana;
            private set => _mana = value;
        }

        public int Experience
        {
            get => _experience;
            private set => _experience = value;
        }

        public int Level
        {
            get => _level;
            private set => _level = value;
        }

        public Attack[] Attacks
        {
            get => _attacks;
            private set => _attacks = value;
        }

        public string Name
        {
            get => _name;
            private set => _name = value;
        }

        #endregion Property

        /* ----------------------------------------------------- *\
        |                                                         |
        |                          Event                          |
        |                                                         |
        \* ----------------------------------------------------- */
        #region Event

        public event Action OnDamage;

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
            this.Name = name;
        }

        #endregion Methods
    }
}