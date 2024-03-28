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