using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiXPing
{
    internal class Chest : Interactive
    {
        /* ----------------------------------------------------- *\
        |                                                         |
        |                          Field                          |
        |                                                         |
        \* ----------------------------------------------------- */
        #region Field

        List<GameItem> _content;           // Content of the chest

        #endregion Field

        /* ----------------------------------------------------- *\
        |                                                         |
        |                        Property                         |
        |                                                         |
        \* ----------------------------------------------------- */
        #region Property
        public List<GameItem> Content
        {
            get => _content;
            private set => _content = value;
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

        public Chest(int x, int y, string message) : base(x,y,message) { }

        public override void Interact(Player player)
        {
            base.Interact(player);

            foreach (var item in _content)
            {
                player.Inventory.ListInventory.Add(item);
            }

            Window.DrawWindow();
        }

        #endregion Methods
    }
}
