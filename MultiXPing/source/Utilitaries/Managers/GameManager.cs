using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using MultiXPing;     

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
        InputManager _inputmanager;
        Render _renderTarget;

        Player _player;
        MenuWindow _mainWindow;

        Tree _mainMenu;

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
        internal MenuWindow MainWindow
        {
            get => _mainWindow;
            set => _mainWindow = value;
        }
        public Tree MainMenu { get => _mainMenu; set => _mainMenu = value; }

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
            CurrentState = State.MAP;
            IsRunning = true;

            Map = new Maps();

            Inputmanager = new InputManager();
            //Inputmanager.Initialize();

            RenderTarget = new Render();
            RenderTarget.InitBuffer();

            
            InitPlayer();

            MainMenu = new Tree();
            MainMenu.AddNode(Player.Inventory);
            MainMenu.AddNode(Player.Team);

            Player.Inventory.AddItem(new Egg());
            Player.Inventory.AddItem(new Coffee());
            Player.Inventory.AddItem(new Glasses());

            MainWindow = new MenuWindow(Player, MainMenu);
            MainWindow.InitContent(new Vector2(0, 0), "MENU");


        }



        public void InitPlayer()
        {
            Player = new Player(Width / 2, Height / 2);
        }

        #endregion Init

        public void GameLoop()
        {
            while (IsRunning)
            {
                Update();
                HandleInput();

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
                    break;
                case State.PAUSE:
                    break;
            }

        }

        public void UpdateMap()
        {
            Render();
            //MainMenu.PrintTree();
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

        public void Render()
        {
            //Reset
            //Console.Clear();
            Console.SetCursorPosition(0, 0);
            RenderTarget.ResetBuffer();

            //Draw map
            RenderTarget.DrawMap(Map, Player);

            //Draw items
            RenderTarget.DrawPlayer(Player);

            //Render
            RenderTarget.RenderBuffer();

            //Draw la window
            MainWindow.DrawWindow();
        }

        public void HandleInput()
        {
            Inputmanager.Update(); // à modifier

            if (Inputmanager.GetKeyState(ConsoleKey.D))
            {
                Player.Move(4, 0);
            }
            if (Inputmanager.GetKeyState(ConsoleKey.Q))
            {
                Player.Move(-4, 0);
            }
            if (Inputmanager.GetKeyState(ConsoleKey.Z))
            {
                Player.Move(0, -4);
            }
            if (Inputmanager.GetKeyState(ConsoleKey.S))
            {
                Player.Move(0, 4);
            }
            if (Inputmanager.GetKeyState(ConsoleKey.T))
            {
                MainWindow.Open();
            }
            if (Inputmanager.GetKeyState(ConsoleKey.E))
            {
                Player.OnUseWindow();
            }
            if (Inputmanager.GetKeyState(ConsoleKey.UpArrow))
            {
                MainWindow.UpdateChoice(-1);
            }
            if (Inputmanager.GetKeyState(ConsoleKey.DownArrow))
            {
                MainWindow.UpdateChoice(1);
            }
            if (Inputmanager.GetKeyState(ConsoleKey.Enter))
            {
                MainWindow.Select();
            }

        }

        #endregion Methods
    }
}


