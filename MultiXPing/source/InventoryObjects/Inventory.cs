using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiXPing
{
    class Inventory : NodeObject
    {

        /* ----------------------------------------------------- *\
        |                                                         |
        |                          Field                          |
        |                                                         |
        \* ----------------------------------------------------- */
        #region Field

        List<GameItem> _listInventory = new List<GameItem>();// List of hunters the player has in its team

        #endregion Field

        /* ----------------------------------------------------- *\
        |                                                         |
        |                        Property                         |
        |                                                         |
        \* ----------------------------------------------------- */
        #region Property

        public List<GameItem> ListInventory
        {
            get => _listInventory;
            private set => _listInventory = value;
        }

        public GameItem this[int index]
        {
            get
            {
                return _listInventory[index];
            }
            set
            {
                _listInventory[index] = value;
            }
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

        public Inventory()
        {
            Name = "Inventory";
        }

        public void AddItem(GameItem obj)
        {
            _listInventory.Add(obj);
            NodeRef.InsertChild(obj);
        }

        #endregion Methods

    }
}
