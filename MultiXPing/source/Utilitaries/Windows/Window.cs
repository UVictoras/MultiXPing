using Pastel;
using System;
using System.Collections.Generic;
using System.Drawing;
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

        string _content = string.Empty;

        int _width = Constants.WIDTH / 2;
        int _height = Constants.HEIGHT / 3 - 2;//-2 pour afficher les bordures blanches en haut et en bas

        int _x = 5;
        int _y = (int)(Constants.HEIGHT * (2f / 3f));

        bool _isOpen = false;

        Vector2 _posEntity = new();

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
        public bool IsOpen { get => _isOpen; set => _isOpen = value; }

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

        public Window()
        {
        }

        public void InitContent(Vector2 posEntity, string content)
        {
            Content = content;
        }

        public void Open()
        {
            if (IsOpen) { IsOpen = false; Content = " "; }
            else { IsOpen = true; }
        }

        public void Close()
        {
            IsOpen = false;
        }

        public void DrawWindowInteractive(string text)
        {
            IsOpen = true;
            Content = text;
            DrawWindow();
        }

         public void DrawWindow()
        {
            if (IsOpen == false)
            {
                return;
            }

            DrawFrame();
            DrawContent(); 
        }

        public virtual void DrawContent()
        {
            //Fonction qui dessine le contenu de la fenetre

            if (Content == string.Empty)
            {
                return;
            }

            Console.BackgroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(X + 1, Y + 1);
            int countLine = 1;

            foreach (char c in Content)
            {
                if (c == '\n')
                {
                    countLine++;
                    Console.SetCursorPosition(X + 1, Y + countLine);
                }
                else
                {
                    Console.Write(c);
                }
            }
        }

        public void DrawFrame()
        {

            //Fonction qui dessine la window en elle meme

            Console.SetCursorPosition(X, Y);

            for (int i = 0; i < _width; i++)
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.Write("  ");
            }

            Console.SetCursorPosition(X, Y + 1);

            for (int i = 0; i < _height; i++)
            {
                for (int j = 0; j < _width; j++)
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.Write("  ");
                }
                //Console.BackgroundColor = ConsoleColor.White;
                Console.Write('\n');
                Console.SetCursorPosition(X, Y + 2 + i);
            }

            Console.SetCursorPosition(X, Y + _height + 1);

            for (int i = 0; i < _width; i++)
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.Write("  ");
            }
        }

        #endregion Methods
    }
}
