public struct GameItem { }
public struct Player 
{ 
    List<GameItem> _inventory = new(); 

    public List<GameItem> Inventory
    {
        get => _inventory;
        set => _inventory = value;
    }
    public Player() { } 
}


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

        public override void Death()
        {
            
        }

        #endregion Methods
    }
}