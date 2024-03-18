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

        public int _maximumHealth;
        public int _health;
        public int _damage;
        public int _defense;
        public int _speed;
        public int _precision;
        public int _maximumMana;
        public int _mana;
        public int _experience;
        public int _level;

        public string _name;

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