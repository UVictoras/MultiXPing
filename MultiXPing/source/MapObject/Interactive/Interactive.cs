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

        string      _message;               // Message printed when Interacting with the object
        bool        _isOpened;              // To check whether we're interacting with the item or not

        #endregion Field

        /* ----------------------------------------------------- *\
        |                                                         |
        |                        Property                         |
        |                                                         |
        \* ----------------------------------------------------- */
        #region Property
        public string Message 
        { 
            get => _message; 
            private set => _message = value; 
        }
        public bool IsOpened 
        { 
            get => _isOpened; 
            private set => _isOpened = value; 
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

        public Interactive(string message) : base() { Message = message; IsOpened = false; }


        public virtual void Interact(Player player) 
        {
            Console.WriteLine(Message);
        }

        #endregion Methods
    }
}
