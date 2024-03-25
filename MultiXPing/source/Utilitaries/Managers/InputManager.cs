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

        Dictionary<string, bool> _keysState = new Dictionary<string, bool>();

        HashSet<ConsoleKey> _pressedKeys = new HashSet<ConsoleKey>();

        #endregion Field

        /* ----------------------------------------------------- *\
        |                                                         |
        |                        Property                         |
        |                                                         |
        \* ----------------------------------------------------- */
        #region Property

        public Dictionary<string, bool> KeysState
        {
            get => _keysState;
            private set => _keysState = value;
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

        public void Update()
        {
            _pressedKeys.Clear();

            do
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(intercept: true);
                _pressedKeys.Add(keyInfo.Key);
            } while (Console.KeyAvailable);

            while (IsAnyKeyPressed() == false)
            {

            }

        }

        public bool GetKeyState(ConsoleKey key)
        {
            return _pressedKeys.Contains(key);
        }

        public bool IsAnyKeyPressed() { return _pressedKeys.Count() > 0; }

        #endregion Methods
    }
}
