using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using MultiXPing;

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
            ColorDic.Add('T', ConsoleColor.Cyan);
            ColorDic.Add('_', ConsoleColor.DarkGreen);
            ColorDic.Add('B', ConsoleColor.DarkRed);
            ColorDic.Add('F', ConsoleColor.Green);
            ColorDic.Add('P', ConsoleColor.DarkMagenta);
            ColorDic.Add('M', ConsoleColor.Magenta);
            ColorDic.Add('O', ConsoleColor.DarkBlue);
            ColorDic.Add('U', ConsoleColor.Blue);
            ColorDic.Add('G', ConsoleColor.DarkGray);
            ColorDic.Add('D', ConsoleColor.Red);
            ColorDic.Add('S', ConsoleColor.Yellow);
            ColorDic.Add(' ', ConsoleColor.Black);
            ColorDic.Add('C', ConsoleColor.Red);

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
            int x = entity.Position.X;
            int y = entity.Position.Y;
            int countX = x;
            
            foreach(char c in entity.Sprite.Sprite) 
            {
                if (countX < 0 || countX >= Constants.WIDTH ||
                    y < 0 || y >= Constants.HEIGHT)
                {
                    countX++;
                }
                else if (c == '\n')
                {
                    y++;
                    countX = x;
                }
                else if (c == ' '){
                    Buffer[y, countX] = Buffer[y, countX];
                    countX++;
                }
                else
                {
                    Buffer[y, countX] = c;
                    countX++;
                }
            }
        }
        
        public void DrawPlayer(MapObject entity)
        {
            int x = Constants.WIDTH/2 - entity.Sprite.Width;
            int y = Constants.HEIGHT/2 - entity.Sprite.Height;
            int countX = x;
            
            foreach(char c in entity.Sprite.Sprite) 
            {
                if (c == '\n')
                {
                    y++;
                    countX = x;
                }
                else if (c == ' '){
                    Buffer[y, countX] = Buffer[y, countX];
                    countX++;
                }
                else
                {
                    Buffer[y, countX] = c;
                    countX++;
                }
            }
        }
        
        

        public void DrawMap(Maps map, Player player)
        {
            int offsetX = player.Position.Y - _height/2;
            int offsetY = player.Position.X - _width/2;

            for (int i = 0; i < _height && i < map.Height; i++)
            {
                for (int j = 0; j < _width && j < map.Width; j++)
                {
                    if(i + offsetX < 0 || i + offsetX > map.Height ||
                       j + offsetY < 0 || j + offsetY > map.Width)
                    {
                        Buffer[i, j] = ' ';
                    }
                    else
                    {
                        Buffer[i, j] = map.Tab[i+offsetX][j+offsetY];
                    }
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
                        Console.Write("  ");
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
