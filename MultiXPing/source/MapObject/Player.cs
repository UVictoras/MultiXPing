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

        List<GameItem>      _inventory = new List<GameItem>();         // List of the items the player has in its inventory
        List<Hunter>        _team      = new List<Hunter>();           // List of hunters the player has in its team
        int _x = 0;
        int _y = 0;

        #endregion Field

        /* ----------------------------------------------------- *\
        |                                                         |
        |                        Property                         |
        |                                                         |
        \* ----------------------------------------------------- */
        #region Property

        public List<GameItem> Inventory
        {
            get => _inventory;
            private set => _inventory = value;
        }

        public List<Hunter> Team
        {
            get => _team;
            private set => _team = value;
        }

        public int X
        {
            get => _x;
            set => _x = value;
        }

        public int Y
        {
            get => _y;
            set => _y = value;
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
        public Player(int x, int y) : base()
        {
            X = x;
            Y = y;
        }

        public void Update(GameManager gm)
        {
            if (X < 0 || X > Constants.WIDTH &&
               Y < 0 || Y > Constants.HEIGHT) return;
            gm.Buffer[Y, X] = 'p';
        }

        #endregion Methods
    }
}
