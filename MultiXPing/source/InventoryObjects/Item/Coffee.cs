using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultiXPing.source.Characters.Character;

namespace MultiXPing
{
    public class Coffee : GameItem
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
        public Coffee()
        {
            Id = 5;
            Description = "Ce café augmente votre vitesse de 5% durant ce combat";
            Boost = 5.0f;
            NumberUse = 1;
            Name = "Coffee";
            IsDestroyable = true;
            IsUsableOnTarget = true;
        }
        public override bool Use(ref Hunter hunter)
        {
            hunter.BoosterSpeed(Boost);
            NumberUse -= 1;
            return true;
        }
        #endregion Methods
    }
}
