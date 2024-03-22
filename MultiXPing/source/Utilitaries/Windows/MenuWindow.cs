using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultiXPing;

namespace MultiXPing
{
    class MenuWindow : Window
    {
        /* ----------------------------------------------------- *\
        |                                                         |
        |                          Field                          |
        |                                                         |
        \* ----------------------------------------------------- */
        #region Field

        Player _mainPlayer;

        int _currentChoice;
        //List<List<>> _choices;

        #endregion Field

        /* ----------------------------------------------------- *\
        |                                                         |
        |                        Property                         |
        |                                                         |
        \* ----------------------------------------------------- */
        #region Property

        public Player MainPlayer
        {
            get => _mainPlayer; 
            set => _mainPlayer = value;
        }
        public int CurrentChoixe { get => _currentChoice; set => _currentChoice = value; }

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

        MenuWindow(Player mainPlayer)
        {
            _mainPlayer = mainPlayer;
        }

        new public void DrawContent()
        {

        }

        #endregion Methods
    }
}
