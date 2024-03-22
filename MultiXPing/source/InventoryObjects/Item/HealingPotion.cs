using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiXPing
{
    class HealingPotion : GameItem
    {
        /* ----------------------------------------------------- *\
        |                                                         |
        |                          Field                          |
        |                                                         |
        \* ----------------------------------------------------- */
        #region Field
        int _heal;          // Amount of HP the potion give to the character
        #endregion Field

        /* ----------------------------------------------------- *\
        |                                                         |
        |                        Property                         |
        |                                                         |
        \* ----------------------------------------------------- */
        #region Property
        public int Heal { get => _heal; private set => _heal = value; }
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
        public HealingPotion()
        {
            Id = 0;
            Description = "Cette potion soigne 20 PV";
            Heal = 20;
            NumberUse = 1;
        }
        public override void Use(ref Hunter hunter)
        {
            hunter.Healing(Heal);
            NumberUse -= 1;
        }
        #endregion Methods
    }
}
