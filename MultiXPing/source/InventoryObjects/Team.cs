using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultiXPing.source.Characters.Character;

namespace MultiXPing
{
    public class Team : NodeObject
    {
        /* ----------------------------------------------------- *\
        |                                                         |
        |                          Field                          |
        |                                                         |
        \* ----------------------------------------------------- */
        #region Field

        List<Character> _team = new List<Character>();// List of hunters the player has in its team

        #endregion Field

        /* ----------------------------------------------------- *\
        |                                                         |
        |                        Property                         |
        |                                                         |
        \* ----------------------------------------------------- */
        #region Property

        public List<Character> ListTeam
        {
            get => _team;
            private set => _team = value;
        }

        public Character this[int index]
        {
            get
            {
                return _team[index];
            }
            set
            {
                _team[index] = value;
            }
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

        public Team()
        {
            Name = "team";
        }

        public void AddCharacter(Character character)
        {
            _team.Add(character);
            NodeRef.InsertChild(character);
        }
        #endregion Methods
    }
}
