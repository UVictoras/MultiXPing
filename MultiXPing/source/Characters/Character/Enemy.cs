using MultiXPing.source.Characters.Attacks;


namespace MultiXPing
{
    public class Enemy : Character
    {
        /* ----------------------------------------------------- *\
        |                                                         |
        |                          Field                          |
        |                                                         |
        \* ----------------------------------------------------- */
        #region Field

        List<GameItem> _loot = new();              // Item dropped by the enemy
        int _droppedExperience;          // Amount of experience the enemy gives
        string _element;
        int _spawnProba;

        #endregion Field

        /* ----------------------------------------------------- *\
        |                                                         |
        |                        Property                         |
        |                                                         |
        \* ----------------------------------------------------- */
        #region Property

        public List<GameItem> Loot
        {
            get => _loot;
            private set => _loot = value;
        }

        public int DroppedExperience
        {
            get => _droppedExperience;
            private set => _droppedExperience = value;
        }
        public string Element { get => _element; set => _element = value; }
        public int SpawnProba { get => _spawnProba; set => _spawnProba = value; }

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
        public Enemy() : base()
        {
        }

        public void InitEnemy(Enemy type)
        {
            Name = type.Name;
            MaximumHealth = type.MaximumHealth;
            Health = type.Health;
            MaximumMana = type.MaximumMana;
            Mana = type.Mana;
            PhysicalDamage = type.PhysicalDamage;
            PhysicalDefense = type.PhysicalDefense;
            MagicalDamage = type.MagicalDamage;
            MagicalDefense = type.MagicalDefense;
            Speed = type.Speed;
            Element = type.Element;
            Attacks = type.Attacks;
            CharacterSprite = type.CharacterSprite;
            CharacterSprite = CharacterSprite.Replace("\r\n", Environment.NewLine);
            CharacterSprite = CharacterSprite.Replace("Q", "\r\n");
        }

        public void DropItems(ref Player player)
        {
            for (int i = 0; i < _loot.Count; i++)
            {
                player.Inventory.ListInventory.Add(_loot[i]);
            }
        }

        public void Initialize(string name, AttackList attList)
        {
            _droppedExperience = 0;
            InitializeCharacter(name, "enemy", attList);
        }

        public override void Death()
        {
            OnDeath?.Invoke();
        }

        #endregion Methods
    }
}