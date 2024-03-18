using System;
using System.Runtime.CompilerServices;

namespace MultiXPing
{
    public class Character
    {
        /* --------------------------------------------------------
        |                                                         |
        |                          Field                          |
        |                                                         |
        -------------------------------------------------------- */
        #region Field

        public int      _maximumHealth;     // Maximum amount of health a character can have
        public int      _health;            // Current amount of health of the character
        public int      _damage;            // Amount of damage inflicted by the character
        public int      _defense;           // Resistance of the character to damages
        public int      _speed;             // Attacking speed of the character
        public int      _precision;         // Precision of the character's attack
        public int      _maximumMana;       // Maximum amount of mana a character can have
        public int      _mana;              // Current amount of mana of the character
        public int      _experience;        // Current experience obtained by the character
        public int      _level;             // Current level of progression of the character
        public Attack[] _attacks;           // List of the possible attacks

        public string   _name;              // Name of the character

        #endregion Field

        /* --------------------------------------------------------
        |                                                         |
        |                        Property                         |
        |                                                         |
        -------------------------------------------------------- */
        #region Property

        public int MaximumHealth
        {
            get => _maximumHealth;
            set => _maximumHealth = value;
        }

        public int Health
        {
            get => _health;
            set => _health = value;
        }

        public int Damage
        {
            get => _damage;
            set => _damage = value;
        }

        public int Defense
        {
            get => _defense;
            set => _defense = value;
        }

        public int Speed
        {
            get => _speed;
            set => _speed = value;
        }

        public int Precision
        {
            get => _precision;
            set => _precision = value;
        }

        public int MaximumMana
        {
            get => _maximumMana;
            set => _maximumMana = value;
        }

        public int Mana
        {
            get => _mana;
            set => _mana = value;
        }

        public int Experience
        {
            get => _experience;
            set => _experience = value;
        }

        public int Level
        {
            get => _level;
            set => _level = value;
        }

        public Attack[] Attacks
        {
            get => _attacks;
            set => _attacks = value;
        }

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        #endregion Property

        /* --------------------------------------------------------
        |                                                         |
        |                          Event                          |
        |                                                         |
        -------------------------------------------------------- */
        #region Event

        public event Action OnDamage;

        #endregion Event

        /* --------------------------------------------------------
        |                                                         |
        |                         Methods                         |
        |                                                         |
        -------------------------------------------------------- */
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