using System;
using System.Runtime.CompilerServices;

namespace MultiXPing
{
    public class Character : NodeObject
    {
        /* ----------------------------------------------------- *\
        |                                                         |
        |                          Field                          |
        |                                                         | 
        \* ----------------------------------------------------- */
        #region Field

        int _maximumHealth;         // Maximum amount of health a character can have
        int _health;                // Current amount of health of the character
        float _physicalDamage;        // Amount of physical damage inflicted by the character
        float _physicalDefense;       // Resistance of the character to physical damages
        float _magicalDamage;         // Amount of magical damage inflicted by the character
        float _magicalDefense;        // Resistance of the character to magical damages
        float _speed;                 // Attacking speed of the character
        float _accuracy;              // Precision of the character's attack
        int _maximumMana;           // Maximum amount of mana a character can have
        int _mana;                  // Current amount of mana of the character
        int _experience;            // Current experience obtained by the character
        int _level;                 // Current level of progression of the character
        bool _isAlive;               // Current state of the character, true if alive, false if dead
        Dictionary<int, Attack> _possibelAttacks;       // List of the attacks the character can learn
        CharactersAttacks _charactersAttacks;

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
            set => _maximumHealth = value;
        }

        public int Health
        {
            get => _health;
            protected set => _health = value;
        }

        public float PhysicalDamage
        {
            get => _physicalDamage;
            set => _physicalDamage = value;
        }

        public float PhysicalDefense
        {
            get => _physicalDefense;
            set => _physicalDefense = value;
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
            set => _speed = value;
        }
        public float Accuracy
        {
            get => _accuracy;
            set => _accuracy = value;
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

        public bool IsAlive
        {
            get => _isAlive;
            set => _isAlive = value;
        }
        Dictionary<int, Attack> PossibleAttacks
        {
            get => _possibelAttacks;
            set => _possibelAttacks = value;
        }
        internal CharactersAttacks CharactersAttacks { get => _charactersAttacks; set => _charactersAttacks = value; }

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
            CharactersAttacks = new CharactersAttacks();
        }

        public void InitializeCharacter(string name, string classe, AttackList attList)
        {
            Name = name;
            Level = 1;
            IsAlive = true;

            string type = " ";

            //Ennemies

            if(classe == "tank" || classe == "swordman" || classe == "magician" || classe == "support")
            {

            }
            else if(classe == "dog")
            {
                //Electric
                type = "electric";
            }
            else if (classe == "snake")
            {
                //Water
                type = "water";
            }
            else if (classe == "goblin")
            {
                //Plant
                type = "plant";
            }
            else if (classe == "salamender")
            {
                type = "fire";
            }
            else if (classe == "boss")
            {
                type = "fire";
            }
            else
            {
                throw new Exception("No valid classe argument");
            }

            List<Attack> attacks = new List<Attack>();
            attacks = SearchAttacks(attList.ListAttack, classe);
            foreach (Attack att in attacks)
            {
                NodeRef.InsertChild(att);
                CharactersAttacks.AddAttack((Attack)att);
            }

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

        public void TakeDamage(int damage)
        {
            Health -= damage;
            if (Health < 0) 
            {
                Health = 0;
            }
        }

        public virtual void Death() { }


        public List<Attack> SearchAttacks(List<Attack> listAtt, string classFilter = "", string typeFilter = "")
        {
            List<Attack> list = new();

            if(typeFilter == "")
            {
                for (int i = 0; i < listAtt.Count; i++)
                {
                    if (listAtt[i].Class == classFilter)
                    {
                        list.Add(listAtt[i]);
                    }
                }
            }else
            {
                if (classFilter == "") { throw new NullReferenceException("classFilter and typeFilter must both be non null "); }

                for (int i = 0; i < listAtt.Count; i++)
                {
                    if (listAtt[i].Element == typeFilter)
                    {
                        list.Add(listAtt[i]);
                    }
                }
            }

            return list;
        }

        #endregion Methods
    }
}