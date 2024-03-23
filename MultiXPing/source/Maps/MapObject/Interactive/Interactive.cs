using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiXPing
{
    internal class Interactive : MapObject
    {
        /* ----------------------------------------------------- *\
        |                                                         |
        |                          Field                          |
        |                                                         |
        \* ----------------------------------------------------- */
        #region Field

        private Window _window;

        #endregion Field

        /* ----------------------------------------------------- *\
        |                                                         |
        |                        Property                         |
        |                                                         |
        \* ----------------------------------------------------- */
        #region Property

        protected Window Window
        {
            get => _window;
            set => _window = value;
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

        public Interactive(int x,int y, string message) : base(x, y) 
        {
            _window = new Window();
            _window.InitContent(_pos,message);
        }


        public virtual void Interact(Player player)
        {
            int xP = player.Position.X;
            int yP = player.Position.Y;
            int xO = Position.X;
            int yO = Position.Y;

            int distance = Math.Abs((xO - xP)+(yO - yP));

            if( distance != 1) 
            {
                return;
            }
        }

        #endregion Methods
    }
}
