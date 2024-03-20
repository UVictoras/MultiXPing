using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiXPing
{
    internal class InputManager
    {
        /* ----------------------------------------------------- *\
        |                                                         |
        |                          Field                          |
        |                                                         |
        \* ----------------------------------------------------- */
        #region Field

        Dictionary<ConsoleKeyInfo, bool> _keyState = new Dictionary<ConsoleKeyInfo, bool>();

        #endregion Field

        /* ----------------------------------------------------- *\
        |                                                         |
        |                        Property                         |
        |                                                         |
        \* ----------------------------------------------------- */
        #region Property

        public Dictionary<ConsoleKeyInfo, bool> KeyState 
        { 
            get => _keyState; 
            private set => _keyState = value;
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

        public void Initialize()
        {
            foreach (ConsoleKeyInfo key in Enum.GetValues(typeof(ConsoleKeyInfo))) 
            {
                KeyState.Add(key, false);
            }
        }

        public void Update()
        {
            foreach (ConsoleKeyInfo key in KeyState.Keys.ToList())
            {
                KeyState[key] = (Console.ReadKey().Key == key.Key);
            }
        }
        #endregion Methods
    }
}
