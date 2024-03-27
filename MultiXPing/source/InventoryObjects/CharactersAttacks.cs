using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultiXPing.source.Characters.Attacks;

namespace MultiXPing
{
    public class CharactersAttacks : NodeObject
    {
        /* ----------------------------------------------------- *\
        |                                                         |
        |                          Field                          |
        |                                                         |
        \* ----------------------------------------------------- */
        #region Field

        List<Attack> _attacks = new List<Attack>();// List of Attack the character has

        #endregion Field

        /* ----------------------------------------------------- *\
        |                                                         |
        |                        Property                         |
        |                                                         |
        \* ----------------------------------------------------- */
        #region Property
        public List<Attack> Attacks { get => _attacks; set => _attacks = value; }

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

        public CharactersAttacks()
        {
            Name = "Attacks";
        }
        public void AddAttack(Attack attack)
        {
            _attacks.Add(attack);
            NodeRef.InsertChild(attack);
        }

        #endregion Methods
    }
}
