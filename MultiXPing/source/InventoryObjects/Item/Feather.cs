using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiXPing
{
    public class Feather : GameItem
    {
        /* ----------------------------------------------------- *\
        |                                                         |
        |                          Field                          |
        |                                                         |
        \* ----------------------------------------------------- */
        #region Field
        #endregion Field

        /* ----------------------------------------------------- *\
        |                                                         |
        |                        Property                         |
        |                                                         |
        \* ----------------------------------------------------- */
        #region Property
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
        public Feather()
        {
            Id = 6;
            Description = "Cette plume permet de réanimer un allié avec la moitier de ses PV";
            NumberUse = 1;
            Name = "Feather";
            IsDestroyable = true;
            IsUsableOnTarget = true;
        }
        public override bool Use(ref Hunter hunter)
        {
            hunter.Reanimate();
            NumberUse -= 1;
            return true;
        }
        #endregion Methods
    }
}
