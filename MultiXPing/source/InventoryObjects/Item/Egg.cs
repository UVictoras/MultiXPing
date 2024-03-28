using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiXPing
{
    public class Egg : GameItem
    {
        /* ----------------------------------------------------- *\
        |                                                         |
        |                          Field                          |
        |                                                         |
        \* ----------------------------------------------------- */
        #region Field
        float _boost;       // Percentage of boost given by the item
        
        #endregion Field

        /* ----------------------------------------------------- *\
        |                                                         |
        |                        Property                         |
        |                                                         |
        \* ----------------------------------------------------- */
        #region Property
        public float Boost { get => _boost; private set => _boost = value; }
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
        public Egg()
        {
            Id = 3;
            Description = "Cet oeuf augmente votre defence de 5% durant ce combat";
            Boost = 5.0f;
            NumberUse = 1;
            Name = "Egg";
            IsDestroyable = true;
            IsUsableOnTarget = true;
        }
        public override bool Use(Hunter hunter)
        {
            hunter.BoosterDefense(Boost);
            NumberUse -= 1;
            return true;
        }

        #endregion Methods
    }
}
