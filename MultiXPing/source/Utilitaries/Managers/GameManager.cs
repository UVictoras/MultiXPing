using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using MultiXPing;
using MultiXPing.source.Utilitaries.Managers;

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
        FightWindow _fight;

        Tree _mainMenu;
        Tree _fightMenu;

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
        internal FightWindow Fight { get => _fight; set => _fight = value; }
        public Tree FightMenu { get => _fightMenu; set => _fightMenu = value; }

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

            FightMenu = new Tree();
            FightMenu.AddNode(Player.Inventory);

            MainMenu = new Tree();
            MainMenu.AddNode(Player.Inventory);
            MainMenu.AddNode(Player.Team);

            Player.Inventory.AddItem(new Egg());
            Player.Inventory.AddItem(new Coffee());
            Player.Inventory.AddItem(new Glasses());

            MainWindow = new MenuWindow(Player, MainMenu);
            MainWindow.InitContent(new Vector2(0, 0), "MENU");

            Enemy mechant = new Enemy();
            mechant.InitializeCharacter("Mechant");
            mechant.Speed = 25;

            CharacterStats Stats = new CharacterStats();
            Stats.InitializeCSVStats(Constants.PROJECTPATH + "MultiXPing\\source\\Data\\InitStats.csv", Constants.PROJECTPATH + "MultiXPing\\source\\Data\\LevelUpMultiplicator.csv");
            Hunter Romain = new Hunter();
            Romain.InitializeHunter("Romain", Stats.Support, Stats.SupportMultiplicator);

            Player.Team.ListTeam.Add(Romain);

            Fight = new FightWindow(Player, FightMenu, mechant);
            Fight.InitContent(new Vector2(0, 0), "FIGHT");
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
                    UpdateFight();
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
            Fight.UpdateFight();
            RenderFight();
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
            Console.CursorVisible = false;
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

        public void RenderFight() 
        {
            //Reset
            //Console.Clear();
            Console.SetCursorPosition(0, 0);
            Console.CursorVisible = false;
            RenderTarget.ResetBuffer();

            //Draw map
            //RenderTarget.DrawMap(Map, Player);

            //Draw items
            //RenderTarget.DrawPlayer(Player);

            //Render
            RenderTarget.RenderBuffer();

            //Draw la window
            Fight.DrawWindow();
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
            if (Inputmanager.GetKeyState(ConsoleKey.P))
            {
                _currentState = State.FIGHT;
                Fight.Open();
            }
            if (Inputmanager.GetKeyState(ConsoleKey.E))
            {
                Player.OnUseWindow();
            }
            if (Inputmanager.GetKeyState(ConsoleKey.UpArrow))
            {
                if (MainWindow.IsOpen)
                {
                    MainWindow.UpdateChoice(-1);
                }
                if (Fight.IsOpen)
                {
                    Fight.UpdateChoice(-1);
                }
            }
            if (Inputmanager.GetKeyState(ConsoleKey.DownArrow))
            {
                if (MainWindow.IsOpen)
                {
                    MainWindow.UpdateChoice(1);
                }
                if (Fight.IsOpen)
                {
                    Fight.UpdateChoice(1);
                }
            }
            if (Inputmanager.GetKeyState(ConsoleKey.Enter))
            {
                if (MainWindow.IsOpen)
                {
                    MainWindow.Select();
                }
                if (Fight.IsOpen)
                {
                    Fight.Select();
                }
            }

        }

        #endregion Methods
    }
}


