using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiXPing
{
    public class Player : MapObject
    {
        /* ----------------------------------------------------- *\
        |                                                         |
        |                          Field                          |
        |                                                         |
        \* ----------------------------------------------------- */
        #region Field

        Inventory _inventory = new Inventory();
        Team _team = new Team();

        Window _menu;

        #endregion Field

        /* ----------------------------------------------------- *\
        |                                                         |
        |                        Property                         |
        |                                                         |
        \* ----------------------------------------------------- */
        #region Property

        
        public Team Team { get => _team; set => _team = value; }
        public Inventory Inventory { get => _inventory; set => _inventory = value; }

        #endregion Property

        /* ----------------------------------------------------- *\
        |                                                         |
        |                          Event                          |
        |                                                         |
        \* ----------------------------------------------------- */
        #region Event

        public event Action<Player> onUse = null;

        #endregion Event

        /* ----------------------------------------------------- *\
        |                                                         |
        |                         Methods                         |
        |                                                         |
        \* ----------------------------------------------------- */
        #region Methods
        public Player(int x, int y) : base(x,y)
        {
            Position = new Vector2(x, y);
            Sprite = new PlayerSprite();
            _menu = new Window();
        }

        public void Update(GameManager gm)
        {

        }

        public void OnUseWindow() => onUse?.Invoke(this);

        public int GetAverageLevel()
        {
            if(Team.ListTeam.Count == 0)
            {
                return 0;
            }

            int result = 0;

            for(int i = 0; i < Team.ListTeam.Count; i++) 
            {
                result += Team.ListTeam[i].Level;
            }

            result /= Team.ListTeam.Count;

            return result;

        }

        public int GetIndexItem(GameItem item)
        {
            if(Inventory.ListInventory.Count == 0) { return -1; }
            for(int i = 0; i < Inventory.ListInventory.Count; i++)
            {
                if (Inventory[i] == item ) return i;
            }

            return -1;
        }
        
        #endregion Methods
    }
}
