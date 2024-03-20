using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiXPing.source.Character
{
    class Support: Hunter
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

        public Support(string name)
        {
            MaximumHealth = 70;
            Health = MaximumHealth;
            MaximumMana = 100;
            Mana = MaximumMana;

            PhysicalDamage = 20.0f;
            PhysicalDefense = 35.0f;

            MagicalDamage = 35.0f;
            MagicalDefense = 35.0f;

            Speed = 60.0f;

            InitializeCharacter(name);
        }

        public override void LevelUp()
        {
            base.LevelUp();

            MaximumHealth += (int)Math.Round(4 * Math.Log(Level));
            Health += (int)Math.Round(4 * Math.Log(Level));
            MaximumMana += (int)Math.Round(5 * Math.Log(Level));
            Mana += (int)Math.Round(5 * Math.Log(Level));

            PhysicalDamage += (float)(2 * Math.Log(Level));
            PhysicalDefense += (float)(2 * Math.Log(Level));

            MagicalDamage += (float)(2 * Math.Log(Level));
            MagicalDefense += (float)(2.5f * Math.Log(Level));

            Speed += (float)(2.5f * Math.Log(Level));
        }
        #endregion Method
    }
}
