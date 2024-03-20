using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace MultiXPing.source.Character
{
    class Magician: Hunter
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

        public Magician(string name)
        {
            MaximumHealth = 70;
            Health = MaximumHealth;
            MaximumMana = 120;
            Mana = MaximumMana;

            PhysicalDamage = 35.0f;
            PhysicalDefense = 25.0f;

            MagicalDamage = 75.0f;
            MagicalDefense = 35.0f;

            Speed = 50.0f;

            InitializeCharacter(name);
        }

        public override void LevelUp()
        {
            base.LevelUp();

            MaximumHealth += (int)Math.Round(4 * Math.Log(Level));
            Health += (int)Math.Round(4 * Math.Log(Level));
            MaximumMana += (int)Math.Round(4 * Math.Log(Level));
            Mana += (int)Math.Round(4 * Math.Log(Level));

            PhysicalDamage += (float)(2 * Math.Log(Level));
            PhysicalDefense += (float)(2 * Math.Log(Level));

            MagicalDamage += (float)(3 * Math.Log(Level));
            MagicalDefense += (float)(2.5f * Math.Log(Level));

            Speed += (float)(2.5f * Math.Log(Level));
        }
        #endregion Method
    }
}
