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

        private string text = "Vous avez utilisé cet objet";

        private int distance = 0;

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
        protected string Text { get => text; set => text = value; }
        protected int Distance { get => distance; set => distance = value; }

        #endregion Property

        /* ----------------------------------------------------- *\
        |                                                         |
        |                          Event                          |
        |                                                         |
        \* ----------------------------------------------------- */
        #region Event

        public event Action<string> PrintText;

        #endregion Event

        /* ----------------------------------------------------- *\
        |                                                         |
        |                         Methods                         |
        |                                                         |
        \* ----------------------------------------------------- */
        #region Methods

        public Interactive(int x,int y, string message = "default") : base(x, y) 
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

            int Distance = Math.Abs((xO - xP)+(yO - yP));

            if (Distance != 1)
            {
                return;
            }

            SendText();
        }

        public virtual void SendText()
        {

            PrintText?.Invoke(Text);
        }

        #endregion Methods
    }
}
