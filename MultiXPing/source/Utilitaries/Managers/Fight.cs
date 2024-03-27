using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiXPing.source.Utilitaries.Managers
{
    class Fight: Window
    {
        /* ----------------------------------------------------- *\
       |                                                         |
       |                          Field                          |
       |                                                         |
       \* ----------------------------------------------------- */
        #region Field
        int _turn;
        List<Character> _actionOrder;
        Character _characterTurn;
        Player _mainPlayer;
        Team _characterTeam = new Team();
        Character _target;
        Enemy _enemy;
        Flee _flee = new Flee();
        Tree _fightingCharacter;

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
        public Character Target { get => _target; set => _target = value; }
        public Tree FightingCharacter { get => _fightingCharacter; set => _fightingCharacter = value; }
        internal Team CharacterTeam { get => _characterTeam; set => _characterTeam = value; }
        internal Enemy Enemy { get => _enemy; set => _enemy = value; }

        internal Flee Flee { get => _flee; set => _flee = value; }

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
        public Fight()
        {
        }

        public void DetermineOrder()
        {
            ActionOrder = CharacterTeam.ListTeam.OrderByDescending(x => x.Speed).ToList();
        }

        #endregion Methods
    }
}
