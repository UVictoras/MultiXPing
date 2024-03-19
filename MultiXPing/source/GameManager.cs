using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MultiXPing
{

    public enum State
    {
        MENU = 0,
        MAP = 1,
        FIGHT = 2,
        PAUSE = 3,
    };

    class GameManager
    {
        /* ----------------------------------------------------- *\
        |                                                         |
        |                          Field                          |
        |                                                         |
        \* ----------------------------------------------------- */
        #region Field

        State _currentState;

        const int _width = Constants.WIDTH;
        const int _height = Constants.HEIGHT;
        bool _isRunning;
        Map _map;

        char[ , ] _buffer = new char[_height,_width];

        public Dictionary<char, ConsoleColor> _colorDic = new Dictionary<char, ConsoleColor>();

        #endregion Field

        /* ----------------------------------------------------- *\
        |                                                         |
        |                        Property                         |
        |                                                         |
        \* ----------------------------------------------------- */
        #region Property

        public State CurrentState 
        {
            get => _currentState;
            private set => _currentState = value;
        }
        public int Width
        {
            get => _width;
        }
        public int Heigth
        {
            get => _height;
        }
        
        public bool IsRunning
        {
            get => _isRunning;
            private set => _isRunning = value;
        }

        public Map Map
        {
            get => _map;
            set => _map = value;
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

        public GameManager()
        {
            CurrentState = State.MAP;
            IsRunning = true;
            Map = new Map();
            InitDico();
            InitBuffer();

        }

        public void InitDico()
        {
            ColorDic.Add('C', ConsoleColor.Red);
            ColorDic.Add('_', ConsoleColor.DarkGreen);
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
        }

        public void GameLoop()
        {
            
            Update();
            
        }

        public void Update()
        {
            switch (_currentState)
            {
                case State.MENU:
                    break;
                case State.MAP:
                    UpdateMap();
                    break;
                case State.FIGHT:
                    break;
                case State.PAUSE:
                    break;
            }

        }

        public void UpdateMap()
        {
            Render();
        }

        public void UpdateFight()
        {

        }

        public void UpdatePause()
        { 
        
        }

        public void UpdateMenu()
        {

        }

        public void RenderBuffer()
        {
            //for (int i = 0; i < Map.Tab.Count || i < _height; i++)
            //{
            //    for (int j = 0; j < Map.Tab[i].Count || j < _width; j++)
            //    {
            //        Console.BackgroundColor = ColorDic[Map.Tab[i][j]];
            //        Console.Write(Buffer[i, j]);
            //        Console.ResetColor();
            //    }
            //    Console.Write("\n");
            //}
            Console.WriteLine(Map.Tab[0][100]);
        }

        public void Render()
        {
            Console.Clear();
            RenderBuffer();
            
            
        }

        #endregion Methods
    }
}


