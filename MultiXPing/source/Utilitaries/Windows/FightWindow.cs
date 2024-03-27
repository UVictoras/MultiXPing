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
                Console.SetCursorPosition(2, 2 + 4 * i);
                Console.WriteLine(MainPlayer.Team.ListTeam[i].Name);
                DrawHealtBar(MainPlayer.Team.ListTeam[i],i);
                DrawManaBar(MainPlayer.Team.ListTeam[i], i);
            }
            Console.SetCursorPosition(X + 2, Y + 2);
            Console.Write("Tour de : " + CharacterTurn.Name);
            _currentNode.PrintChildrenOnly(X + 2, Y + 3, CurrentChoice);
        }
        public void DrawHealtBar(Character character, int cursorY)
        {
            // FAIRE AVEC DES BOUCLE FOR PARCE QUE LA CA FAIT BOCOU
            Console.SetCursorPosition(3, 3 + 4 * cursorY);
            if ((character.Health * 100) / character.MaximumHealth >= 90.0f)
            {
                Console.WriteLine("Health: ■■■■■■■■■■");
            }
            else if ((character.Health * 100) / character.MaximumHealth >= 80.0f)
            {
                Console.WriteLine("Health: ■■■■■■■■■");
            }
            else if ((character.Health * 100) / character.MaximumHealth >= 70.0f)
            {
                Console.WriteLine("Health: ■■■■■■■■");
            }
            else if ((character.Health * 100) / character.MaximumHealth >= 60.0f)
            {
                Console.WriteLine("Health: ■■■■■■■");
            }
            else if ((character.Health * 100) / character.MaximumHealth >= 50.0f)
            {
                Console.WriteLine("Health: ■■■■■■");
            }
            else if ((character.Health * 100) / character.MaximumHealth >= 40.0f)
            {
                Console.WriteLine("Health: ■■■■■");
            }
            else if ((character.Health * 100) / character.MaximumHealth >= 30.0f)
            {
                Console.WriteLine("Health: ■■■■");
            }
            else if ((character.Health * 100) / character.MaximumHealth >= 20.0f)
            {
                Console.WriteLine("Health: ■■■");
            }
            else if ((character.Health * 100) / character.MaximumHealth >= 10.0f)
            {
                Console.WriteLine("Health: ■■");
            }
            else if ((character.Health * 100) / character.MaximumHealth > 0.0f)
            {
                Console.WriteLine("Health: ■");
            }
        }
        public void DrawManaBar(Character character, int cursorY)
        {
            // FAIRE AVEC DES BOUCLE FOR PARCE QUE LA CA FAIT BOCOU
            Console.SetCursorPosition(3, 4 + 4 * cursorY);
            if ((character.Mana * 100) / character.MaximumMana >= 90.0f)
            {
                Console.WriteLine("Mana: ■■■■■■■■■■");
            }
            else if ((character.Mana * 100) / character.MaximumMana >= 80.0f)
            {
                Console.WriteLine("Mana: ■■■■■■■■■");
            }
            else if ((character.Mana * 100) / character.MaximumMana >= 70.0f)
            {
                Console.WriteLine("Mana: ■■■■■■■■");
            }
            else if ((character.Mana * 100) / character.MaximumMana >= 60.0f)
            {
                Console.WriteLine("Mana: ■■■■■■■");
            }
            else if ((character.Mana * 100) / character.MaximumMana >= 50.0f)
            {
                Console.WriteLine("Mana: ■■■■■■");
            }
            else if ((character.Mana * 100) / character.MaximumMana >= 40.0f)
            {
                Console.WriteLine("Mana: ■■■■■");
            }
            else if ((character.Mana * 100) / character.MaximumMana >= 30.0f)
            {
                Console.WriteLine("Mana: ■■■■");
            }
            else if ((character.Mana * 100) / character.MaximumMana >= 20.0f)
            {
                Console.WriteLine("Mana: ■■■");
            }
            else if ((character.Mana * 100) / character.MaximumMana >= 10.0f)
            {
                Console.WriteLine("Mana: ■■");
            }
            else if ((character.Mana * 100) / character.MaximumMana > 0.0f)
            {
                Console.WriteLine("Mana: ■");
            }
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
