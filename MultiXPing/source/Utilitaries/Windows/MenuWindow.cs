using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultiXPing;

namespace MultiXPing
{
    public class MenuWindow : Window
    {
        /* ----------------------------------------------------- *\
        |                                                         |
        |                          Field                          |
        |                                                         |
        \* ----------------------------------------------------- */
        #region Field

        Player _mainPlayer;

        int _currentChoice;
        Node _currentNode;

        Node _tempNode = null;

        Tree _arbre;

        #endregion Field

        /* ----------------------------------------------------- *\
        |                                                         |
        |                        Property                         |
        |                                                         |
        \* ----------------------------------------------------- */
        #region Property

        public Player MainPlayer
        {
            get => _mainPlayer; 
            set => _mainPlayer = value;
        }
        public int CurrentChoice { get => _currentChoice; set => _currentChoice = value; }
       
        public Tree Arbre { get => _arbre; set => _arbre = value; }
        public Node CurrentNode { get => _currentNode; set => _currentNode = value; }
        public Node TempNode { get => _tempNode; set => _tempNode = value; }

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

        public MenuWindow(Player mainPlayer, Tree arbre)
        {
            _mainPlayer = mainPlayer;
            _arbre = arbre;
            _currentNode = arbre.Root;
        }

        public void ResetNode()
        {
            _currentNode = _arbre.Root;
        }

        public override void DrawContent()
        {
            base.DrawContent();
            

            Console.SetCursorPosition(X + 1, Y);
            _currentNode.PrintChildrenOnly(X + 1 , Y + 2, CurrentChoice);
            
        }

        public void Select()
        {
            Node node = _currentNode.Children[_currentChoice];

            if(node.HasChildren() == true)
            {
                _currentNode = node;
            }
            else if (node.Obj.IsUsableOnTarget)
            {
                CurrentNode = _arbre.Root.Children[1];

            }
            else if(TempNode != null)
            {
                //A modifier 
                CurrentNode = _arbre.Root.Children[1];
                if (node.Obj.Use())
                {
                    if (node.Obj.IsDestroyable)
                    {
                        _currentNode.DeleteChildren(_currentChoice);
                    }
                    
                }   
                


            }
        }

        public void UpdateChoice(int i)
        {
            _currentChoice = (_currentChoice + i) % _currentNode.ChildrenCount ;
        }

        #endregion Methods
    }
}
