using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MultiXPing
{
    public class Attack : NodeObject
    {
        /* ----------------------------------------------------- *\
        |                                                         |
        |                          Field                          |
        |                                                         | 
        \* ----------------------------------------------------- */
        #region Field

        string _element;            // Defines the specificity of the attack
        float _accuracy;         // Precision of the attack
        int _damage;           // Amount of damage inflicted by the attack
        int _magicCost;          // Whether the attack has a magical type or not
        object _function;
        string _descriptor;
        string _class;
        bool _alliesTarget;

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
        public bool AlliesTarget { get => _alliesTarget; set => _alliesTarget = value; }

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
        public Attack()
        {
            Name = "Charge";
            Damage = 10;
            Accuracy = 10;
        }
        public void UseAttack(Character attacker, Character target)
        {
            int damage = 0;
            if (MagicCost != 0)
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