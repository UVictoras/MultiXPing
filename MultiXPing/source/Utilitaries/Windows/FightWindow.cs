using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultiXPing;
using MultiXPing.source.Utilitaries.Managers;

namespace MultiXPing
{
    class FightWindow : Fight
    {
        /* ----------------------------------------------------- *\
        |                                                         |
        |                          Field                          |
        |                                                         |
        \* ----------------------------------------------------- */
        #region Field

        int _currentChoice;
        Node _currentNode;

        //List<List<>> _choices;
        Tree _arbre;

        #endregion Field

        /* ----------------------------------------------------- *\
        |                                                         |
        |                        Property                         |
        |                                                         |
        \* ----------------------------------------------------- */
        #region Property
        public int CurrentChoice { get => _currentChoice; set => _currentChoice = value; }

        public Tree Arbre { get => _arbre; set => _arbre = value; }
        public Node CurrentNode { get => _currentNode; set => _currentNode = value; }

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

        public FightWindow(Player mainPlayer, Tree arbre, Enemy enemy)
        {
            Arbre = arbre;
            MainPlayer = mainPlayer;
            CurrentNode = arbre.Root;
            ActionOrder = new List<Character>();
            Turn = 0;
            FightingCharacter = new Tree();
            CharacterTeam = new Team();
            CharacterTeam.AddCharacter(enemy);

            for (int i = 0; i < mainPlayer.Team.ListTeam.Count ; i++)
            {
                CharacterTeam.AddCharacter(mainPlayer.Team.ListTeam[i]);
            }
            FightingCharacter.AddNode(CharacterTeam);
        }

        public override void DrawContent()
        {
            base.DrawContent();
            Console.SetCursorPosition(X + 2, Y + 2);
            Console.Write("Tour de : "+CharacterTurn.Name);
            _currentNode.PrintChildrenOnly(X + 2, Y + 3, CurrentChoice);

        }

        public void Select()
        {
            Node node = _currentNode.Children[_currentChoice];

            if (node.HasChildren() == true)
            {
                _currentNode = node;
            }
            else if (node.Obj.Name == "Attacks")
            {
                // Faut afficher le nom du character
                _currentNode = FightingCharacter.Root;
            }
            else
            {
                node.Obj.Use();
            }
        }
        public void UpdateFight()
        {
            if (Turn == 0)
            {
                DetermineOrder();
                Turn++;
            }
            else if (Turn != 0)
            {
                Arbre.RemoveNode(CharacterTurn.CharactersAttacks);
            }
            CharacterTurn = ActionOrder[Turn % ActionOrder.Count];
            Arbre.AddNode(CharacterTurn.CharactersAttacks);

            //Turn += 1;
        }
        public void UpdateChoice(int i)
        {
            _currentChoice = (_currentChoice + i) % _currentNode.ChildrenCount;
        }

        #endregion Methods
    }
}
