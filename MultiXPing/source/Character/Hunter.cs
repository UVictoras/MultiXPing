using System.Security.Cryptography.X509Certificates;

namespace MultiXPing
{
    class Hunter : Character
    {
        /* ----------------------------------------------------- *\
        |                                                         |
        |                          Field                          |
        |                                                         |
        \* ----------------------------------------------------- */
        #region Field

        int     _experience;                // Amount of experience the hunter has
        int     _experienceRequired;        // Amount of experience required to level up

        #endregion Field

        /* ----------------------------------------------------- *\
        |                                                         |
        |                        Property                         |
        |                                                         |
        \* ----------------------------------------------------- */
        #region Property

        public int Experience
        {
            get => _experience;
            private set => _experience = value;
        }

        public int ExperienceRequired
        {
            get => _experienceRequired;
            private set => _experienceRequired = value;
        }

        #endregion Property

        /* ----------------------------------------------------- *\
        |                                                         |
        |                          Event                          |
        |                                                         |
        \* ----------------------------------------------------- */
        #region Event

        public override event Action OnDamage;
        public override event Action OnDeath;

        #endregion Event

        /* ----------------------------------------------------- *\
        |                                                         |
        |                         Methods                         |
        |                                                         |
        \* ----------------------------------------------------- */
        #region Methods

        public Hunter()
        {

        }

        public override void Initialize(string name, string element)
        {
            Experience = 0;
            base.Initialize(name, element);
        }

        public override void Death()
        {
            base.Death();
        }

        #endregion Methods
    }
}