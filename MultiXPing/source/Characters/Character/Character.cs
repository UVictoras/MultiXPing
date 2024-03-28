using System;
using System.Runtime.CompilerServices;
using MultiXPing.source.Characters.Attacks;

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
        List<Attack>  _attacks;


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
            set => _health = value;
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
            set => _magicalDamage = value;
        }

        public float MagicalDefense
        {
            get => _magicalDefense;
            set => _magicalDefense = value;
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
        public List<Attack> Attacks { get => _attacks; set => _attacks = value; }

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
            Attacks = new List<Attack>();
        }

        public void InitializeCharacter(string name, string classe, AttackList attList)
        {
            Name = name;
            Level = 1;
            IsAlive = true;

            string type = " ";

            if (classe == "enemy")
            {
                classe = name;
            }

            //Ennemies

            if (classe == "tank" || classe == "swordman" || classe == "magician" || classe == "support")
            {

            }
            else if(classe == "flashmcqueen")
            {
                //Electric
                type = "electric";
            }
            else if (classe == "nayar")
            {
                //Water
                type = "water";
            }
            else if (classe == "gobriel")
            {
                //Plant
                type = "plant";
            }
            else if (classe == "danycayou")
            {
                //Fire
                type = "fire";
            }
            else if (classe == "enderdragon")
            {
                type = "physical";
            }
            else
            {
                throw new Exception("No valid classe argument");
            }

            Attacks = SearchAttacks(4,attList.ListAttack, classe) ;
            foreach (Attack att in Attacks)
            {
                NodeRef.InsertChild(att);
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


        public List<Attack> SearchAttacks(int limit, List<Attack> listAtt, string classFilter = "", string typeFilter = "")
        {
            List<Attack> list = new();

            if (typeFilter == "")
            {
                for (int i = 0; i < listAtt.Count; i++)
                {
                    if (listAtt[i].Class == classFilter)
                    {
                        list.Add(listAtt[i]);
                        if(list.Count == limit)
                        {
                            return list;
                        }
                    }
                }
            }
            else
            {
                if (classFilter == "") { throw new NullReferenceException("classFilter and typeFilter must both be non null "); }

                for (int i = 0; i < listAtt.Count; i++)
                {
                    if (listAtt[i].Element == typeFilter)
                    {
                        list.Add(listAtt[i]);
                        if (list.Count == limit)
                        {
                            return list;
                        }
                    }
                }
            }

            return list;
        }

        #endregion Methods
    }
}