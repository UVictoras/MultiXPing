using MultiXPing.source.Character;
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

        int _experience;                // Amount of experience the hunter has
        int _experienceRequired;        // Amount of experience required to level up
        float _damageBoost;
        float _defenseBoost;
        float _speedBoost;
        float _accuracyBoost;

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
        public float DamageBoost
        {
            get=> _damageBoost;
            private set => _damageBoost = value;
        }
        public float DefenseBoost
        {
            get => _defenseBoost;
            private set => _defenseBoost = value;
        }
        public float SpeedBoost
        {
            get => _speedBoost; 
            private set => _speedBoost = value;
        }
        public float AccuracyBoost
        {
            get => _accuracyBoost;
            private set => _accuracyBoost = value;
        }

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

        public Hunter()
        {
            Experience = 0;
            ExperienceRequired = 10;
            DefenseBoost = 1.0f;
            DamageBoost = 1.0f;
            SpeedBoost = 1.0f;
            AccuracyBoost = 1.0f;
        }

        public override void Death()
        {
            base.Death();
        }

        public void BoosterDamage(float damage)
        {
            DamageBoost *= damage;
        }

        public void BoosterDefense(float defense) {
            DefenseBoost *= defense;
        }
        public void BoosterSpeed(float speed)
        {
            SpeedBoost *= speed;
        }
        public void BoosterAccuracy(float accuracy)
        {
            AccuracyBoost *= accuracy;
        }

        public void ResetBoost()
        {
            DamageBoost = 1.0f;
            DefenseBoost = 1.0f;
            SpeedBoost = 1.0f;
            AccuracyBoost = 1.0f;
        }
        #endregion Methods
    }
}