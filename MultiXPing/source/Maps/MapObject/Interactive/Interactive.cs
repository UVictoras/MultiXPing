using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiXPing
{
    public class Interactive : MapObject
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
        public string Text { get => text; set => text = value; }
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
            int xP = player.Position.X; // Doit etre 52
            int yP = player.Position.Y; // Doit etre 15
            int xO = Position.X;
            int yO = Position.Y;

            double oue = Math.Sqrt(Math.Pow((xO - xP), 2) + Math.Pow((yO - yP), 2));

            Distance = (int)Math.Sqrt(Math.Pow((xO - xP),2) + Math.Pow((yO - yP),2));

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
