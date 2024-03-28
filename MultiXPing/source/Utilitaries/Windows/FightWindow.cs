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
        END = 2,
        FLEE = 3,
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

        public FightWindow(Player mainPlayer, Tree arbre)
        {
            State = FightState.START;
            Arbre = arbre;
            MainPlayer = mainPlayer;
            CharacterTeam = new Team();
            CharacterTurn = new Character();
            ActionOrder = new List<Character>();
            FightingCharacter = new Tree();
        }

        #region Init
        public void Init()
        {
            CurrentNode = Arbre.Root;
            Turn = 0;
            FightingCharacter.AddNode(CharacterTeam);
            //CharacterTeam.AddCharacter(Enemy);

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
            for (int i = 0; i < MainPlayer.Team.ListTeam.Count; ++i)
            {
                if (MainPlayer.Team.ListTeam[i].Health > 0)
                {
                    Console.SetCursorPosition(3, 2 + 4 * i);
                    Console.WriteLine(MainPlayer.Team.ListTeam[i].Name);
                    Console.SetCursorPosition(4, 3 + 4 * i);
                    DrawHealtBar(MainPlayer.Team.ListTeam[i], i);
                    Console.SetCursorPosition(4, 4 + 4 * i);
                    DrawManaBar(MainPlayer.Team.ListTeam[i], i);
                }
            }

            for (int i = 0; i < Enemies.Count; ++i)
            {
                if (Enemies[i].Health > 0)
                {
                    Console.SetCursorPosition(Constants.WIDTH - 40, 2 + 4 * i);
                    Console.WriteLine(Enemies[i].Name);
                    Console.SetCursorPosition(Constants.WIDTH - 40, 3 + 4 * i);
                    DrawHealtBar(Enemies[i], i);
                }
            }
            Console.SetCursorPosition(X + 2, Y + 2);
            Console.Write("Tour de : " + CharacterTurn.Name);
            _currentNode.PrintChildrenOnly(X + 2, Y + 3, CurrentChoice);
        }
        public void DrawHealtBar(Character character, int cursorY)
        {
            
            Console.Write("Health: ");
            for (int i = 0; i < (((character.Health * 100) / character.MaximumHealth) / 10); i++)
            {
                Console.Write("■");
            }
        }
        public void DrawManaBar(Character character, int cursorY)
        {
            Console.Write("Mana: ");
            for (int i = 0; i < (((character.Mana * 100) / character.MaximumMana) / 10); i++)
            {
                Console.Write("■");
            }
        }
        public void DrawCharacter(int cusorY)
        {

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
                else if (node.Obj.Name== "Attacks")
                {
                    _currentChoice = 0;
                    _currentNode = CharacterTurn.CharactersAttacks.NodeRef;
                }
                else if (node.Parent.Name == "Attacks")
                {
                    SelectedAttack = (Attack)(node.Obj);
                    _currentChoice = 0;
                    _currentNode = FightingCharacter.Root.Children[0];
                }
                else
                {
                    if (node.Parent.Name != "team")
                    {
                        node.Obj.Use();
                        Turn++;
                    }
                    else
                    {
                        SelectedAttack.Use();
                    }
                }
            }
            
            else
            {
                // Au tour de l'ennemis, donc y'a du texte à passer 
            }
        }
        #endregion Fight


        public void UpdateFight()
        {
            switch (State)
            {
                case FightState.START:
                    Init();
                    State = FightState.FIGHTING;
                    DetermineOrder();
                    CharacterTurn = ActionOrder[Turn % ActionOrder.Count];
                    Arbre.AddNode(CharacterTurn.CharactersAttacks);
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
        public void UpdateChoice(int i)
        {
            _currentChoice = (((_currentChoice + i) + _currentNode.ChildrenCount)) % _currentNode.ChildrenCount;
        }

        #endregion Methods
    }
}
