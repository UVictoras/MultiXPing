using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace MultiXPing
{
    class Render
    {
        /* ----------------------------------------------------- *\
        |                                                         |
        |                          Field                          |
        |                                                         |
        \* ----------------------------------------------------- */
        #region Field

        const int _width = Constants.WIDTH;
        const int _height = Constants.HEIGHT;

        char[,] _buffer = new char[_height, _width];

        public Dictionary<char, ConsoleColor> _colorDic = new Dictionary<char, ConsoleColor>();


        #endregion Field

        /* ----------------------------------------------------- *\
        |                                                         |
        |                        Property                         |
        |                                                         |
        \* ----------------------------------------------------- */
        #region Property
        public int Width
        {
            get => _width;
        }
        public int Heigth
        {
            get => _height;
        }

        public char[,] Buffer
        {
            get => _buffer;
            set => _buffer = value;
        }
        public Dictionary<char, ConsoleColor> ColorDic
        {
            get => _colorDic;
            set => _colorDic = value;
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

        public Render()
        {
            
        }
        public void InitDico()
        {
            ColorDic.Add('C', ConsoleColor.Cyan);
            ColorDic.Add('_', ConsoleColor.DarkGreen);
            ColorDic.Add('P', ConsoleColor.DarkRed);

        }

        public void InitBuffer()
        {
            for (int i = 0; i < _height; i++)
            {
                for (int j = 0; j < _width; j++)
                {
                    Buffer[i, j] = ' ';
                }
            }

            InitDico();
        }

        public void Draw(MapObject entity)
        {
            int x = entity.X;
            int y = entity.Y;
            int countX = x;
            if (x < 0 || x > Constants.WIDTH &&
               y < 0 || y > Constants.HEIGHT) return;
            foreach(char c in entity.Sprite) 
            {
                if(c == '\n')
                {
                    y++;
                    countX = x;
                }
                else
                {
                    Buffer[y, countX] = c;
                    countX++;
                }
            }
        }

        public void DrawMap(Map map)
        {
            int offsetX = 0;
            int offsetY = 0;

            for (int i = 0; i < _height; i++)
            {
                for (int j = 0; j < _width; j++)
                {
                    Buffer[i, j] = map.Tab[i+offsetX][j+offsetY];
                }
            }
        }

        public void ResetBuffer()
        {
            for (int i = 0; i < _height; i++)
            {
                for (int j = 0; j < _width; j++)
                {
                    Buffer[i, j] = ' ';
                }
            }
        }

        public void RenderBuffer()
        {
            for (int i = 0; i < _height - 1; i++)
            {
                for (int j = 0; j < _width - 1; j++)
                {
                    if (ColorDic.ContainsKey(Buffer[i,j]) == true)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ColorDic[Buffer[i, j]];
                        Console.Write(' ');
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.Write(Buffer[i, j]);
                    }
                }
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Write("\n");
            }

        }

        #endregion Methods
    }
}
