using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiXPing.source.Character
{
    class Tank : Hunter
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

        public Tank(string name)
        {
            MaximumHealth = 120;
            Health = MaximumHealth;
            MaximumMana = 70;
            Mana = MaximumMana;

            PhysicalDamage = 45.0f;
            PhysicalDefense = 75.0f;

            MagicalDamage = 35.0f;
            MagicalDefense = 55.0f;

            Speed = 25.0f;

            InitializeCharacter(name);
        }

        public override void LevelUp()
        {
            base.LevelUp();

            MaximumHealth += (int)Math.Round(5 * Math.Log(Level));
            Health += (int)Math.Round(5 * Math.Log(Level));
            MaximumMana += (int)Math.Round(3 * Math.Log(Level));
            Mana += (int)Math.Round(3 * Math.Log(Level));

            PhysicalDamage += (float)(2 * Math.Log(Level));
            PhysicalDefense += (float)(3 * Math.Log(Level));

            MagicalDamage += (float)(2 * Math.Log(Level));
            MagicalDefense += (float)(2.5f * Math.Log(Level));

            Speed += (float)(2 * Math.Log(Level));
        }

        #endregion Methods
    }
}
