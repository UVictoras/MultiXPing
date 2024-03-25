﻿using System;
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

        List<GameItem> _content = new List<GameItem>();           // Content of the chest

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

        public Chest(int x, int y) : base(x,y) 
        {
            Text = "Vous recevez ";
            if(Content != null) 
            {
                foreach (GameItem item in Content)
                {
                    Text += item.Name + ", ";
                }
            }
            else
            {
                Text = "Coffre vide";
            }
        }

        public override void Interact(Player player)
        {
            base.Interact(player);

            if (Content == null || Distance != 1)
            {
                return;
            }

            foreach (var item in _content)
            {
                player.Inventory.ListInventory.Add(item);
            }

            Content = null;
        }

        #endregion Methods
    }
}
