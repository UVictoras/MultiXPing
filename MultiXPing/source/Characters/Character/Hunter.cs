using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;
using MultiXPing.source.Characters.Attacks;

namespace MultiXPing
{
    public class Hunter : Character
    {
        /* ----------------------------------------------------- *\
        |                                                         |
        |                          Field                          |
        |                                                         |
        \* ----------------------------------------------------- */
        #region Field

        int _experience;                // Amount of experience the hunter has
        int _experienceRequired;        // Amount of experience required to level up
        float _damageBoost;             // Percentage of damage the character has
        float _defenseBoost;            // Percentage of defense the character has
        float _speedBoost;              // Percentage of speed the character has
        float _accuracyBoost;           // Percentage of accuracy the character has
        List<float> _characterMultiplicator;

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
            get => _damageBoost;
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
        public List<float> CharacterMultiplicator { get => _characterMultiplicator; set => _characterMultiplicator = value; }

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

        public void InitializeHunter(string name, string classe, AttackList list, CharacterStats stats)
        {
            InitializeCharacter(name, classe, list);
            CharacterMultiplicator = stats.DicMultiplicator[classe + "multiplicator"];

            List<string> statsList = stats.DicStats[classe];

            MaximumHealth = int.Parse(statsList[0]);
            Health = MaximumHealth;
            MaximumMana = int.Parse(statsList[1]);
            Mana = MaximumMana;
            PhysicalDamage = float.Parse(statsList[2]);
            PhysicalDefense = float.Parse(statsList[3]);
            MagicalDamage = float.Parse(statsList[4]);
            MagicalDefense = float.Parse(statsList[5]);
            Speed = float.Parse(statsList[6]);
            CharacterSprite = statsList[7];
            CharacterSprite = CharacterSprite.Replace("Q", "\r\n");
        }

        public override void Death()
        {
            base.Death();
            if (IsAlive)
            {
                IsAlive = false;
                Health = 0;
            }
        }

        public void Reanimate()
        {
            if (IsAlive == false)
            {
                IsAlive = true;
                Health = MaximumHealth / 2;
            }
        }

        public void BoosterDamage(float damage)
        {
            DamageBoost *= damage;
        }

        public void BoosterDefense(float defense)
        {
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

        public void GainExp(int experience)
        {
            Experience += experience;
            Console.WriteLine("Tu as: " + Experience + " exp");
            if (Experience >= ExperienceRequired)
            {
                LevelUp();
            }
        }

        public void LevelUp()
        {
            Experience = Experience - ExperienceRequired;
            Level += 1;
            ExperienceRequired = (int)Math.Round(35.0 / 36.0 * Math.Pow(Level, 2) + 125.0 / 12.0 * Level - 25.0 / 18.0); // The function f(x)= 35/36 x² + 125/12 x - 25/18, where x is the level, calculate the new amount of exp required

            // Increase Statistics
            MaximumHealth += (int)Math.Round(CharacterMultiplicator[0] * Math.Log(Level));
            Health += (int)Math.Round(CharacterMultiplicator[0] * Math.Log(Level));
            MaximumMana += (int)Math.Round(CharacterMultiplicator[1] * Math.Log(Level));
            PhysicalDamage += (int)Math.Round(CharacterMultiplicator[2] * Math.Log(Level));
            PhysicalDefense += (int)Math.Round(CharacterMultiplicator[3] * Math.Log(Level));
            MagicalDamage += (int)Math.Round(CharacterMultiplicator[4] * Math.Log(Level));
            MagicalDefense += (int)Math.Round(CharacterMultiplicator[5] * Math.Log(Level));
            Speed += (int)Math.Round(CharacterMultiplicator[6] * Math.Log(Level));

            //if (PossibleAttacks.ContainsKey(Level))
            //{
            //      //------------------------//
            //     //  Apprendre une attaque //
            //    //------------------------//
            //}

            Console.WriteLine("Bravo tu est niveau" + Level);
            Console.WriteLine("Bravo tu a lvlUp, il te faut " + ExperienceRequired + " exp pour lvlUp");
            Console.WriteLine("Tu as " + Experience + " experience");
        }



        #endregion Methods
    }
}