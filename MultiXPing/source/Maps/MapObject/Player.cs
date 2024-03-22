using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiXPing
{
    class Player : MapObject
    {
        /* ----------------------------------------------------- *\
        |                                                         |
        |                          Field                          |
        |                                                         |
        \* ----------------------------------------------------- */
        #region Field

        Inventory _inventory = new Inventory();
        Team _team = new Team();          

        Window _menu = new Window();

        #endregion Field

        /* ----------------------------------------------------- *\
        |                                                         |
        |                        Property                         |
        |                                                         |
        \* ----------------------------------------------------- */
        #region Property

        
        internal Team Team { get => _team; set => _team = value; }
        internal Inventory Inventory { get => _inventory; set => _inventory = value; }

        #endregion Property

        /* ----------------------------------------------------- *\
        |                                                         |
        |                          Event                          |
        |                                                         |
        \* ----------------------------------------------------- */
        #region Event

        public event Action<Vector2> onUse;

        #endregion Event

        /* ----------------------------------------------------- *\
        |                                                         |
        |                         Methods                         |
        |                                                         |
        \* ----------------------------------------------------- */
        #region Methods
        public Player(int x, int y) : base()
        {
            Position = new Vector2(x, y);
            Sprite = new PlayerSprite();
        }

        public void Update(GameManager gm)
        {

        }

        public void OnUseWindow()
        {
            onUse(Position);
        }

        #endregion Methods
    }
}
