using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiXPing.source.Character
{
    class Swordsman: Hunter
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

        public Swordsman(string name)
        {
            MaximumHealth = 80;
            Health = MaximumHealth;
            MaximumMana = 80;
            Mana = MaximumMana;

            PhysicalDamage = 75.0f;
            PhysicalDefense = 45.0f;

            MagicalDamage = 25.0f;
            MagicalDefense = 25.0f;

            Speed = 40.0f;

            InitializeCharacter(name);
        }

        public override void LevelUp()
        {
            base.LevelUp();

            MaximumHealth += (int)Math.Round(4 * Math.Log(Level));
            Health += (int)Math.Round(4 * Math.Log(Level));
            MaximumMana += (int)Math.Round(3 * Math.Log(Level));
            Mana += (int)Math.Round(3 * Math.Log(Level));

            PhysicalDamage += (float)(4 * Math.Log(Level));
            PhysicalDefense += (float)(2.5f * Math.Log(Level));

            MagicalDamage += (float)(2 * Math.Log(Level));
            MagicalDefense += (float)(2 * Math.Log(Level));

            Speed += (float)(2.5f * Math.Log(Level));
        }
        #endregion Method
    }
}
