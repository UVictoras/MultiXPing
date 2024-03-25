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
        Enemy _enemy;

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
        public Enemy Enemy
        {
            get => _enemy;
            set => _enemy = value;
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
        public Fight()
        {
        }

        public void DetermineOrder()
        {
            List<Hunter> sortedHunter = (MainPlayer.Team.ListTeam.OrderByDescending(x => x.Speed).ToList());
            for (int i = 0; i < sortedHunter.Count; i++)
            {
                ActionOrder.Add(sortedHunter[i]);
            }

            for (int i = 0; i < ActionOrder.Count; i++)
            {
                if (ActionOrder[i].Speed <= Enemy.Speed)
                {
                    ActionOrder.Insert(i,Enemy);
                }
                else if (i == ActionOrder.Count - 1)
                {
                    ActionOrder.Add(Enemy);
                    break;
                }
            }
        }

        #endregion Methods
    }
}
