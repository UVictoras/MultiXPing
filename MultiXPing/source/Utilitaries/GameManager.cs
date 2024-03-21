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
        Maps _map;
        Maps _fight;
        InputManager _inputmanager;
        Render _renderTarget;

        Player _player;
        
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
        public int Height
        {
            get => _height;
        }
        
        public bool IsRunning
        {
            get => _isRunning;
            private set => _isRunning = value;
        }

        public Maps Map
        {
            get => _map;
            set => _map = value;
        }

        public InputManager Inputmanager
        {
            get => _inputmanager;
            set => _inputmanager = value;
        }

        public Render RenderTarget
        {
            get => _renderTarget;
            set => _renderTarget = value;
        }

        public Player Player
        {
            get => _player;
            set => _player = value;
        }
        internal Maps Fight { get => _fight; set => _fight = value; }

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

        #region Init

        public GameManager()
        {
            CurrentState = State.FIGHT;
            IsRunning = true;

            Map = new Maps("MultiXPing\\source\\Maps\\Map1.txt");
            Fight = new Maps("MultiXPing\\source\\Maps\\Fight.txt");

            Inputmanager = new InputManager();
            //Inputmanager.Initialize();

            RenderTarget = new Render();
            RenderTarget.InitBuffer();

            
            InitPlayer();

        }

        

        public void InitPlayer()
        {
            Player = new Player(Width/2, Height/2);
        }

        #endregion Init

        public void GameLoop()
        {
            while (IsRunning)
            {
                HandleInput();
                Update();
                while (Inputmanager.isAnyKeyPressed() == false)
                {
                }
            }
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
                    UpdateFight();
                    break;
                case State.PAUSE:
                    break;
            }

        }

        public void UpdateMap()
        {
            _player.Move(1,0);

            //Reset
            Console.Clear();
            RenderTarget.ResetBuffer();

            //Draw map
            RenderTarget.DrawMap(Map);

            //Draw items
            RenderTarget.Draw(Player);

            Render();
        }

        public void UpdateFight()
        {
            //Reset
            Console.Clear();
            RenderTarget.ResetBuffer();

            //Draw map
            RenderTarget.DrawFight(Fight);

            Render();
        }

        public void UpdatePause()
        { 
        
        }

        public void UpdateMenu()
        {

        }

        public void Render()
        {
           
            
            //Render
            RenderTarget.RenderBuffer();
        }

        public void HandleInput()
        {
            //Inputmanager.Update(); // à modifier

            if (Inputmanager.GetKeyState(ConsoleKey.D))
            {
                Player.Move(1, 0);
            }
        }

        #endregion Methods
    }
}


