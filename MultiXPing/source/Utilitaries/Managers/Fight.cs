using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using MultiXPing.source.Characters.Attacks;

namespace MultiXPing
{
    class Fight
    {
        public enum FightState
        {
            START = 0,
            FIGHTING = 1,
            END = 2,
            FLEE = 3,
        };

        /* ----------------------------------------------------- *\
       |                                                         |
       |                          Field                          |
       |                                                         |
       \* ----------------------------------------------------- */
        #region Field
        AttackList _listAttack;
        Random _rand = new Random();
        EnemyList _enemyList;

        int _turn;

        List<Character> _actionOrder = new();
        Character _characterTurn;
        Player _mainPlayer;
        Team _characterTeam = new Team();
        Attack _selectedAttack;
        List<Enemy> _enemies = new();
        FightState _state;
        int _totalExp;
        bool _inFight;

        FightWindow _windowCombat;
        Window _window;

        string[] _nameMobs = { "nayar", "flashmcqueen", "gobriel", "danycayou" };

        #endregion Field

        /* ----------------------------------------------------- *\
        |                                                         |
        |                        Property                         |
        |                                                         |
        \* ----------------------------------------------------- */
        #region Property
        public int Turn { get => _turn; set => _turn = value; }
        public List<Character> ActionOrder { get => _actionOrder; set => _actionOrder = value; }
        public Character CharacterTurn { get => _characterTurn; set => _characterTurn = value; }
        public Player MainPlayer
        {
            get => _mainPlayer;
            set => _mainPlayer = value;
        }
        internal Team CharacterTeam { get => _characterTeam; set => _characterTeam = value; }
        public Attack SelectedAttack { get => _selectedAttack; set => _selectedAttack = value; }
        public string[] NameMobs { get => _nameMobs; set => _nameMobs = value; }
        public AttackList ListAttack { get => _listAttack; set => _listAttack = value; }
        public Random Rand { get => _rand; set => _rand = value; }
        internal FightState State { get => _state; set => _state = value; }
        internal FightWindow WindowCombat { get => _windowCombat; set => _windowCombat = value; }
        public List<Enemy> Enemies { get => _enemies; set => _enemies = value; }
        public Character CurrentFighter { get => ActionOrder[Turn]; }
        public Window Window { get => _window; set => _window = value; }
        public int TotalExp { get => _totalExp; set => _totalExp = value; }
        public EnemyList EnemyList { get => _enemyList; set => _enemyList = value; }
        public bool InFight { get => _inFight; set => _inFight = value; }

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
        public Fight(AttackList listAtt, Player player, Tree arbre)
        {
            ListAttack = listAtt;
            WindowCombat = new FightWindow(player, arbre);
            Window = new Window();
            MainPlayer= player;
            TotalExp = 0;
            InFight = false;
            
        }

        public void InitFight(Player player, EnemyList enemyList)
        {
            InitEnnemies(player, enemyList);
            EnemyList = enemyList;
            DetermineOrder();
            InitOrderList();
            WindowCombat.Init(Enemies, this);
            Window.InitContent("");
            for (int i = 0; i < Enemies.Count; i++)
            {
                TotalExp += Enemies[i].DroppedExperience * Enemies[i].Level;
            }
        }
        public void ResetFight()
        {
            TotalExp = 0;
            ActionOrder.Clear();
            InitEnnemies(MainPlayer,EnemyList);
            InitOrderList();
            DetermineOrder();
            WindowCombat.Reset(Enemies, this);
            Window.InitContent("");
            for (int i = 0; i < Enemies.Count; i++)
            {
                TotalExp += Enemies[i].DroppedExperience * Enemies[i].Level;
            }
        }
        public void InitFightRender()
        {
            Console.Clear();
        }

        public void DetermineOrder()
        {
            ActionOrder = ActionOrder.OrderByDescending(x => x.Speed).ToList();
        }

        public void InitEnnemies(Player player, EnemyList enemyList)
        {
            int averageLevel = player.GetAverageLevel();
            GenerateEnemies(enemyList);

            for(int i = 0; i < 4; i++)
            {
                if (averageLevel - 3 > 0)
                {
                    Enemies[i].Level = Rand.Next(averageLevel - 3, averageLevel + 3);
                }
                else
                {
                    Enemies[i].Level = Rand.Next(1, averageLevel + 3);
                }
            }
        }

        public void InitOrderList()
        {
            foreach(Hunter hero in MainPlayer.Team.ListTeam)
            {
                if (hero.Health > 0)
                {
                    ActionOrder.Add(hero);
                }
            }

            if(Enemies.Count == 0) { throw new Exception("Enemy List must be non null"); }

            foreach(Enemy enemy in Enemies)
            {
                ActionOrder.Add(enemy);
            }

        }

        public void UpdateFight()
        {
            switch (State)
            {
                case FightState.START:
                    State = FightState.FIGHTING;
                    InFight = true;
                    //InitFightRender();
                    // RESET
                    if (Enemies.Count == 0)
                    {
                        ResetFight();
                    }
                    
                    break;
                case FightState.FIGHTING:
                    DetermineOrder();
                    Update();
                    RenderFight();
                    break;
                case FightState.END:
                    RenderFight();
                    break;
                case FightState.FLEE:
                    break;
                default:
                    break;
            }
        }

        public void RenderFight()
        {
            //Reset
            Console.Clear();
            Console.SetCursorPosition(0, 0);
            Console.CursorVisible = false;

            RenderBattleField();//Pour afficher les combattants et les barres de vies


            WindowCombat.DrawWindow();
            Window.DrawWindow();

        }

        public void Update()
        {
            if (Enemies.Count == 0)
            {
                GainExp();
                State = FightState.END;
                return;
            }
            if (MainPlayer.Team.ListTeam.Contains(CurrentFighter))
            {
                //Draw la window associée au combattant
                Window.Close();
                WindowCombat.Open();
                
            }
            else
            {
                //
                //Mettre à jour la fenetre qui affiche du text; mettre en content le monstre qui attack
                //
                string spellUsed = EnnemyAttack();

                Window.InitContent(CurrentFighter.Name + " utilise " + spellUsed);
                UpdateCurrentTurn();
                WindowCombat.Close();
                Window.Open();

            }
        }

        public void GainExp()
        {
            for (int i = 0; i < MainPlayer.Team.ListTeam.Count; i++)
            {
                if (MainPlayer.Team.ListTeam[i].Health > 0)
                {
                    MainPlayer.Team.ListTeam[i].GainExp(TotalExp);
                }
            }
        }
        public void UpdateCurrentTurn()
        {
            if(ActionOrder.Count == 0) { return; }
            Turn = (Turn + 1) % ActionOrder.Count;
            if (Turn < 0) Turn += ActionOrder.Count;
        }

        public void GenerateEnemies(EnemyList enemyList) 
        {
            Random randomEnemy = new Random();
            int rand = 0;
            int spawnGobriel = enemyList.GetEnemyByName("gobriel").SpawnProba;
            int spawnDanycayou = enemyList.GetEnemyByName("danycayou").SpawnProba;
            int spawnFlashmcqueen = enemyList.GetEnemyByName("flashmcqueen").SpawnProba;
            int spawnNayar = enemyList.GetEnemyByName("nayar").SpawnProba;

            for (int i = 0; i < 4; i++) 
            {
                Enemy temp = new Enemy();
                rand = randomEnemy.Next(1,100);
                if (rand <= spawnGobriel)
                {
                    temp.InitEnemy(enemyList.GetEnemyByName("gobriel"));
                    Enemies.Add(temp);
                }
                else if (rand > spawnGobriel && rand <= spawnGobriel + spawnDanycayou)
                {
                    temp.InitEnemy(enemyList.GetEnemyByName("danycayou"));
                    Enemies.Add(temp);
                }
                else if (rand > spawnGobriel + spawnDanycayou && rand <= spawnGobriel + spawnDanycayou + spawnFlashmcqueen)
                {
                    temp.InitEnemy(enemyList.GetEnemyByName("flashmcqueen"));
                    Enemies.Add(temp);
                }
                else if (rand > spawnGobriel + spawnDanycayou + spawnFlashmcqueen)
                {
                    temp.InitEnemy(enemyList.GetEnemyByName("nayar"));
                    Enemies.Add(temp);
                }

            }
        }

        public void RenderBattleField()
        {
            for (int i = 0; i < MainPlayer.Team.ListTeam.Count; ++i)
            {
                if (MainPlayer.Team.ListTeam[i].Health > 0)
                {
                    Console.SetCursorPosition(3, 2 + 5 * i);
                    Console.WriteLine(MainPlayer.Team.ListTeam[i].Name);
                    Console.SetCursorPosition(4, 3 + 5 * i);
                    DrawHealtBar(MainPlayer.Team.ListTeam[i], i);
                    Console.SetCursorPosition(4, 4 + 5 * i);
                    DrawManaBar(MainPlayer.Team.ListTeam[i], i);
                    Console.SetCursorPosition(25, 3 + 5 * i);
                    MainPlayer.Team.ListTeam[i].DrawSprite(25, 3 + 5 * i);
                }
            }

            for (int i = 0; i < Enemies.Count; ++i)
            {
                if (Enemies[i].Health > 0)
                {
                    Console.SetCursorPosition(Constants.WIDTH - 25, 2 + 5 * i);
                    Console.WriteLine(Enemies[i].Name);
                    Console.SetCursorPosition(Constants.WIDTH - 25, 3 + 5 * i);
                    DrawHealtBar(Enemies[i], i);
                    Console.SetCursorPosition(Constants.WIDTH - 35, 3 + 5 * i);
                    Enemies[i].DrawSprite(Constants.WIDTH - 35, 3 + 5 * i); ;

                }
            }
        }
        public void DrawHealtBar(Character character, int cursorY)
        {

            Console.Write("Health: ");
            for (int i = 0; i < (((character.Health * 100) / character.MaximumHealth) / 10) + 1; i++)
            {
                Console.Write("■");
            }
        }
        public void DrawManaBar(Character character, int cursorY)
        {
            Console.Write("Mana: ");
            for (int i = 0; i < (((character.Mana * 100) / character.MaximumMana) / 10) + 1; i++)
            {
                Console.Write("■");
            }
        }

        public void DrawCharacter(int cusorY)
        {

        }

        public string EnnemyAttack()
        {
            if(CurrentFighter is not Enemy) { return "failed"; }
            
            int spell = Rand.Next(CurrentFighter.Attacks.Count);
            Attack attack = CurrentFighter.Attacks[spell];
            int target = Rand.Next(MainPlayer.Team.ListTeam.Count);
            while (MainPlayer.Team[target].Health < 0) 
            {
                target = Rand.Next(3);
            }
            Hunter cible = (Hunter)MainPlayer.Team[target];
            bool succes = CurrentFighter.Attacks[spell].Use(CurrentFighter, cible) ;

            if (succes == false) { throw new Exception("Attack didn't work"); }

            if (cible.Health == 0)
            {
                ActionOrder.Remove(cible);
            }
            return attack.Name + " sur " + cible.Name;

        }

        #endregion Methods
    }
}
