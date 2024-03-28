using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using MultiXPing.source.Characters.Attacks;

namespace MultiXPing
{

    public enum State
    {
        MENU = 0,
        MAP = 1,
        FIGHT = 2,
        PAUSE = 3,
    };

    public class GameManager
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
        MenuWindow _mainMenuWindow;
        Window _mainWindow;
        Fight _fight;

        Tree _mainMenu;
        Tree _fightMenu;

        List<Interactive> _listInteractives = new();

        Random _rand = new Random();

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
        internal MenuWindow MainMenuWindow
        {
            get => _mainMenuWindow;
            set => _mainMenuWindow = value;
        }
        public Tree MainMenu { get => _mainMenu; set => _mainMenu = value; }
        internal List<Interactive> ListInteractives { get => _listInteractives; set => _listInteractives = value; }
        internal Window MainWindow { get => _mainWindow; set => _mainWindow = value; }
        public Random Rand { get => _rand; set => _rand = value; }
        public Tree FightMenu { get => _fightMenu; set => _fightMenu = value; }
        internal Fight Fight { get => _fight; set => _fight = value; }

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

            InitPlayer();

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

            MainWindow = new Window();
            MainWindow.InitContent(new Vector2(0, 0), " ");
            
            MainMenuWindow = new MenuWindow(Player, MainMenu);
            MainMenuWindow.InitContent(new Vector2(0, 0), " ");

            Map.InitInteractive(ListInteractives, Player, MainWindow);

            CharacterStats Stats = new CharacterStats();
            Stats.InitializeCSVStats(Constants.PROJECTPATH + "MultiXPing\\source\\Data\\InitStats.csv", Constants.PROJECTPATH + "MultiXPing\\source\\Data\\LevelUpMultiplicator.csv");
            
            AttackList attackList = new AttackList();
            attackList.InitAttacks();
            EnemyList enemyList = new EnemyList();
            enemyList.InitEnemy();

            InitPlayerHeroes(attackList, Stats);

            Fight = new Fight(attackList,Player,FightMenu) ;
            Fight.InitFight(Player);
            Fight.GenerateEnemies(enemyList);
        }

        public void InitPlayerHeroes(AttackList attlist, CharacterStats charStats)
        {
            Hunter tank = new();
            Player.Team.AddCharacter(tank);
            tank.InitializeHunter("Rayan", "tank", attlist, charStats);

            Hunter swordman = new();
            Player.Team.AddCharacter(swordman);
            swordman.InitializeHunter("Link", "swordman", attlist, charStats);

            Hunter magician = new();
            Player.Team.AddCharacter(magician);
            magician.InitializeHunter("Harry crampté", "magician", attlist, charStats);

            Hunter support = new();
            Player.Team.AddCharacter(support);
            support.InitializeHunter("Sage", "support", attlist, charStats);
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
                HandleInput();
                Update();
                
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
            LaunchFight();
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
            MainMenuWindow.DrawWindow();
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
            Fight.WindowCombat.DrawWindow();
        }

        public void HandleInput()
        {
            Inputmanager.Update(); // à modifier

            if (Inputmanager.GetKeyState(ConsoleKey.D))
            {
                Player.Move(1, 0);
            }
            if (Inputmanager.GetKeyState(ConsoleKey.Q))
            {
                Player.Move(-1, 0);
            }
            if (Inputmanager.GetKeyState(ConsoleKey.Z))
            {
                Player.Move(0, -1);
            }
            if (Inputmanager.GetKeyState(ConsoleKey.S))
            {
                Player.Move(0, 1);
            }
            if (Inputmanager.GetKeyState(ConsoleKey.M))
            {
                MainMenuWindow.ResetNode();
                MainMenuWindow.Open();
            }
            if (Inputmanager.GetKeyState(ConsoleKey.P))
            {
                _currentState = State.FIGHT;
                Fight.WindowCombat.Open();
            }
            if (Inputmanager.GetKeyState(ConsoleKey.E))
            {
                if (MainWindow.IsOpen)
                {
                    MainWindow.Close();
                }
                else
                {
                    Player.OnUseWindow();
                }
            }
            if (Inputmanager.GetKeyState(ConsoleKey.UpArrow))
            {
                if (CurrentState == State.MAP)
                {
                    MainMenuWindow.UpdateChoice(-1);
                }
                if (CurrentState == State.FIGHT)
                {
                    Fight.WindowCombat.UpdateChoice(-1);
                }
            }
            if (Inputmanager.GetKeyState(ConsoleKey.DownArrow))
            {
                if (CurrentState == State.MAP)
                {
                    MainMenuWindow.UpdateChoice(1);
                }
                if (CurrentState == State.FIGHT)
                {
                    Fight.WindowCombat.UpdateChoice(1);
                }
            }
            if (Inputmanager.GetKeyState(ConsoleKey.Enter))
            {
                if (CurrentState == State.MAP)
                {
                    MainMenuWindow.Select();
                }
                if (CurrentState == State.FIGHT)
                {
                    Fight.WindowCombat.Select();
                }
            }
        }

        public void LaunchFight()
        {
            
            if (Map.Tab[Player.Position.Y][Player.Position.X] == 'H') //Si le joueur est dans une zone d'herbe
            {
                if (Rand.Next(100) <= 15) 
                {
                    CurrentState = State.FIGHT;
                    Fight.WindowCombat.Open();
                }
            }
        }

        #endregion Methods
    }
}


