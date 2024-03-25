using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiXPing
{
    public class Meat : GameItem
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
        public Meat()
        {
            Id = 2;
            Description = "Ce morceau de viande augmente vos degat de 5% durant ce combat";
            Boost = 5.0f;
            NumberUse = 1;
            Name = "Meat";
        }
        public override void Use(ref Hunter hunter)
        {
            hunter.BoosterDamage(Boost);
            NumberUse -= 1;
        }
        #endregion Methods
    }
}
