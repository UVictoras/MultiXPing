using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiXPing
{

    class FightWindow : MenuWindow
    {
        /* ----------------------------------------------------- *\
        |                                                         |
        |                          Field                          |
        |                                                         |
        \* ----------------------------------------------------- */
        #region Field

        int _currentChoice;
        Node _currentNode;
        Player _player;

        Attack _currentSpell = null;

        List<NodeObject> _nodes = new List<NodeObject>();
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
        public List<NodeObject> Nodes { get => _nodes; set => _nodes = value; }
        public Player Player { get => _player; set => _player = value; }
        public Attack CurrentSpell { get => _currentSpell; set => _currentSpell = value; }

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

        public FightWindow(Player mainPlayer, Tree arbre) : base (mainPlayer, arbre)
        {
            Arbre = arbre;
        }

        #region Init
        public void Init()
        {
            CurrentNode = Arbre.Root;
            Nodes.Add(Player.Team[0]);
            Nodes.Add(Player.Inventory);

        }
        #endregion Init

        #region Fight
        public void DrawContent(Character perso)
        {
            base.DrawContent();
            Console.SetCursorPosition(X + 2, Y + 2);
            Console.Write("Tour de : " + perso.Name);
            if(CurrentNode.Obj.Name == "Root")
            {
                for (int i = 0; i < Nodes.Count; i++)
                {
                    Console.SetCursorPosition(X + 2, Y + i + 3);
                    if (i == CurrentChoice)
                    {
                        Console.Write("> ");
                    }
                    Console.Write(" - " + Nodes[i].Name);
                }
            }
            else
            {
                _currentNode.PrintChildrenOnly(X + 2, Y + 3, CurrentChoice);
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
                else if (CurrentSpell != null)
                {
                    if(CurrentSpell.AlliesTarget == true)
                    {
                        CurrentNode = 
                    }
                    else
                    {
                        CurrentNode = 
                    }
                }
                else if (node.Obj.IsUsableOnTarget == true)
                {
                    CurrentSpell = (Attack)node.Obj;
                    CurrentNode = 
                    _currentChoice = 0;
                    // Afficher le nom de perso contenu dans team, parce que la ca affiche Team
                    _currentNode = FightingCharacter.Root.Children[0];
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


        
        public void UpdateChoice(int i)
        {
            _currentChoice = (((_currentChoice + i) + _currentNode.ChildrenCount)) % _currentNode.ChildrenCount;
        }

        #endregion Methods
    }
}
