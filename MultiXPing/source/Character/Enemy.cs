public struct GameItem { }

namespace MultiXPing
{
    class Enemy : Character
    {
        /* ----------------------------------------------------- *\
        |                                                         |
        |                          Field                          |
        |                                                         |
        \* ----------------------------------------------------- */
        #region Field

        List<GameItem>        _loot = new ();              // Item dropped by the enemy
        int                   _droppedExperience;          // Amount of experience the enemy gives

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
        public Enemy() 
        {
        }

        public void DropItems(ref Player player)
        {
            for (int i = 0; i < _loot.Count; i++)
            {
                player.Inventory.Add(_loot[i]);
            }
        }

        public override void Initialize(string name, string element)
        {
            _droppedExperience = 0; 
            base.Initialize(name, element);
        }

        public override void Death()
        {
            OnDeath?.Invoke();
        }

        #endregion Methods
    }
}