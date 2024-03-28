using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiXPing
{
    public class ManaPotion : GameItem
    {
        /* ----------------------------------------------------- *\
        |                                                         |
        |                          Field                          |
        |                                                         |
        \* ----------------------------------------------------- */
        #region Field
        int _mana;          // Amount of mana the potion give to the character
        #endregion Field

        /* ----------------------------------------------------- *\
        |                                                         |
        |                        Property                         |
        |                                                         |
        \* ----------------------------------------------------- */
        #region Property
        public int Mana { get => _mana; private set => _mana = value; }
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
        public ManaPotion()
        {
            Id = 1;
            Description = "Cette potion vous rend 20 PM";
            Mana = 20;
            NumberUse = 1;
            Name = "Mana Potion";
            IsDestroyable = true;
            IsUsableOnTarget = true;
        }
        public override bool Use(Hunter hunter)
        {
            hunter.ManaRegeneration(Mana);
            NumberUse -= 1;
            return true;
        }
        #endregion Methods
    }
}
