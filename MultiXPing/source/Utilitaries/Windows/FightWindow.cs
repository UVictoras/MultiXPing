using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultiXPing;
using MultiXPing.source.Utilitaries.Managers;

namespace MultiXPing
{
    public enum FightState
    {
        START = 0,
        FIGHTING = 1,
        FLEE = 2,
        END = 3,
    };
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
        FightState _state;

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
        public FightState State { get => _state; set => _state = value; }

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
            State = FightState.START;
            Arbre = arbre;
            MainPlayer = mainPlayer;
            Enemy = enemy;
            CharacterTeam = new Team();
            ActionOrder = new List<Character>();
            FightingCharacter = new Tree();
        }

        #region Init
        public void Init()
        {
            CurrentNode = Arbre.Root;
            Turn = 0;
            FightingCharacter.AddNode(CharacterTeam);
            CharacterTeam.AddCharacter(Enemy);

            for (int i = 0; i < MainPlayer.Team.ListTeam.Count; i++)
            {
                CharacterTeam.AddCharacter(MainPlayer.Team.ListTeam[i]);
            }
        }
        #endregion Init

        #region Fight
        public override void DrawContent()
        {
            base.DrawContent();
            Console.SetCursorPosition(X + 2, Y + 2);
            Console.Write("Tour de : " + CharacterTurn.Name);
            _currentNode.PrintChildrenOnly(X + 2, Y + 3, CurrentChoice);
        }

        public void Select()
        {
            if (MainPlayer.Team.ListTeam.Contains(CharacterTurn))
            {
                Node node = _currentNode.Children[_currentChoice];

                if (node.HasChildren() == true)
                {
                    _currentNode = node;
                }
                else if (node.Parent.Name== "Attacks")
                {
                    _currentChoice = 0;
                    // Afficher le nom de perso contenu dans team, parce que la ca affiche Team
                    _currentNode = FightingCharacter.Root.Children[0];
                }
                else if (node.Obj.Name == "Flee")
                {
                    State = FightState.FLEE;
                }
                else
                {
                    node.Obj.Use();
                    Turn++;
                }
            }
            else
            {
                // Au tour de l'ennemis, donc y'a du texte à passer 
            }
        }
        #endregion Fight


        public void UpdateFight(ref MultiXPing.State gameState)
        {
            switch (State)
            {
                case FightState.START:
                    Init();
                    State = FightState.FIGHTING;
                    DetermineOrder();
                    CharacterTurn = ActionOrder[Turn % ActionOrder.Count];
                    Arbre.AddNode(CharacterTurn.CharactersAttacks);
                    Arbre.AddNode(Flee);
                    break;
                case FightState.FIGHTING:

                    if (MainPlayer.Team.ListTeam.Contains(CharacterTurn))
                    {
                        Arbre.RemoveNode(Flee);
                        Arbre.RemoveNode(CharacterTurn.CharactersAttacks);
                        CharacterTurn = ActionOrder[Turn % ActionOrder.Count];
                        Arbre.AddNode(CharacterTurn.CharactersAttacks);
                        Arbre.AddNode(Flee);
                    }
                    else
                    {

                    }

                    DetermineOrder();
                    break;
                case FightState.FLEE:
                    gameState = MultiXPing.State.MAP;
                    State = FightState.END;
                    break;
                case FightState.END:
                    break;
                default:
                    break;
            }
        }
        public void UpdateChoice(int i)
        {
            _currentChoice = (((_currentChoice + i) + _currentNode.ChildrenCount)) % _currentNode.ChildrenCount;
        }

        #endregion Methods
    }
}
