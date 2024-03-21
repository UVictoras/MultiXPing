using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
        int _y = (int)(Constants.WIDTH * (2f / 3f));


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

        public Window(string content)
        {
            Content = content;
        }

        public void DrawWindow()
        {
            if (_content == String.Empty)
            {
                return;
            }

            int count = 0;
            bool isEndLine = false;

            Console.SetCursorPosition(X, Y);

            for (int i = 0; i < _width; i++)
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.Write(" ");
            }

            Console.SetCursorPosition(X, Y);

            for (int i = 0; i < _height; i++) { 
                for(int j = 0; j < _width; j++)
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.Write("  ");
                }
                //Console.BackgroundColor = ConsoleColor.White;
                Console.Write('\n');
                Console.SetCursorPosition(X, Y + i);
            }

            Console.SetCursorPosition(X + 1, Y + 1);
            int countLine = 1;

            foreach (char c in Content)
            {
                Console.Write(c);
                if(c == '\n')
                {
                    countLine++;
                    Console.SetCursorPosition(X + 1, Y + countLine);
                }
            }
        }

        #endregion Methods
    }
}
