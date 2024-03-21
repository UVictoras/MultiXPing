using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiXPing
{
    class Window
    {
        /* ----------------------------------------------------- *\
        |                                                         |
        |                          Field                          |
        |                                                         |
        \* ----------------------------------------------------- */
        #region Field

        string _content = String.Empty;

        int _width = Constants.WIDTH/2;
        int _height = Constants.HEIGHT / 3;

        int _x = 10;
        int _y = Constants.WIDTH* (2 / 3);


        #endregion Field

        /* ----------------------------------------------------- *\
        |                                                         |
        |                        Property                         |
        |                                                         |
        \* ----------------------------------------------------- */
        #region Property

        string Content
        {
            get => _content;
            set => _content = value;
        }

        public int Width
        {
            get => _width;
            set => _width = value;
        }

        public int Height 
        {
            get => _height;
            set => _height = value;
        }

        public int X
        {
            get => _x; 
            set => _x = value; 
        }

        public int Y
        {
            get => _y; 
            set => _y = value;
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

        public void DrawWindow()
        {
            if (_content == String.Empty)
            {
                return;
            }

            for(int i = 0; i < _height; i++) { 
            }
        }

        #endregion Methods
    }
}
