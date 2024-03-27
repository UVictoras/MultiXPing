using System;
using System.Collections.Generic;
using System.Linq;
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

        int _turn;

        List<Character> _actionOrder;
        Character _characterTurn;
        Player _mainPlayer;
        Team _characterTeam = new Team();
        Attack _selectedAttack;
        Tree _enemies;
        FightState _state;

        FightWindow _windowCombat;


        string[] _nameMobs = { "dog", "snake", "goblin", "salamender" };

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
        public Tree Enemies { get => _enemies; set => _enemies = value; }

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
        }

        public void InitFight(Player player)
        {
            InitEnnemies(player);
            DetermineOrder();
        }

        public void DetermineOrder()
        {
            ActionOrder = CharacterTeam.ListTeam.OrderByDescending(x => x.Speed).ToList();
        }

        public void InitEnnemies(Player player)
        {
            int averageLevel = player.GetAverageLevel();

            for(int i = 0; i < 4; i++)
            {
                Enemies.Add(new Enemy());
                Enemies[i].Initialize(NameMobs[Rand.Next(3)], ListAttack);
                Enemies[i].Level = averageLevel;
            }
        }
        public void UpdateFight()
        {
            switch (State)
            {
                case FightState.START:
                    State = FightState.FIGHTING;
                    break;
                case FightState.FIGHTING:

                    if (MainPlayer.Team.ListTeam.Contains(CharacterTurn))
                    {
                        Arbre.RemoveNode(CharacterTurn.CharactersAttacks);
                        CharacterTurn = ActionOrder[Turn % ActionOrder.Count];
                        Arbre.AddNode(CharacterTurn.CharactersAttacks);
                    }
                    else
                    {

                    }

                    DetermineOrder();
                    break;
                case FightState.END:
                    break;
                case FightState.FLEE:
                    break;
                default:
                    break;
            }
        }

        #endregion Methods
    }
}
