using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
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
        int _currentHero = 0;
        Node _currentNode;
        Player _player;

        Fight _fight;

        Attack _currentSpell = null;
        GameItem _currentItem = null;

        List<NodeObject> _nodes = new List<NodeObject>();

        Tree _arbre;
        Tree _arbreEnemy;

        private Dictionary<string, ConsoleColor> dicoCouleur = new Dictionary<string, ConsoleColor>();

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
        
        public Tree ArbreEnemy { get => _arbreEnemy; set => _arbreEnemy = value; }
        public Fight Fight { get => _fight; set => _fight = value; }
        public GameItem CurrentItem { get => _currentItem; set => _currentItem = value; }
        public int CurrentHero { get => _currentHero; set => _currentHero = value; }
        public Dictionary<string, ConsoleColor> DicoCouleur { get => dicoCouleur; set => dicoCouleur = value; }



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
            ArbreEnemy = new Tree();
            ArbreEnemy.Root.Obj.Name = "Ennemis";
            Player = mainPlayer;
            Content = "Tour de : ";

            DicoCouleur.Add("fire", ConsoleColor.Red);
            DicoCouleur.Add("physic", ConsoleColor.Gray);
            DicoCouleur.Add("water", ConsoleColor.Blue);
            DicoCouleur.Add("electric", ConsoleColor.Yellow);
            DicoCouleur.Add("plant", ConsoleColor.Green);

        }

        #region Init
        public void Init(List<Enemy> enemyList, Fight fight)
        {
            Fight = fight;

            CurrentNode = Arbre.Root;
            Nodes.Add(Player.Team[CurrentHero]);
            Nodes.Add(Player.Inventory);

            foreach (Enemy enemy in enemyList)
            {
                ArbreEnemy.AddNode(enemy);
            }

        }
        #endregion Init

        #region Fight
        public override void DrawContent()
        {
            Content += Fight.CurrentFighter.Name;
            Nodes[0] = Fight.CurrentFighter;

            if (Content == string.Empty)
            {
                return;
            }

            //Base.Base

            Console.BackgroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(X + 1, Y + 1);
            int countLine = 1;

            foreach (char c in Content)
            {
                if (c == '\n')
                {
                    countLine++;
                    Console.SetCursorPosition(X + 1, Y + countLine);
                }
                else
                {
                    Console.Write(c);
                }
            }

            ////

            if (CurrentNode.Obj.Name == "Root")
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
            Content = "Tour de : ";

            if(CurrentNode.Obj is Hunter)
            {
                PrintAttackStats(((Character)CurrentNode.Obj).Attacks[CurrentChoice]);
            }

            }
           

        public void Select()
        {
            if (IsOpen == false)
            {
                return;
            }
            
            Node node;

            if (CurrentNode.Obj.Name == "Root")
            {
                node = Nodes[_currentChoice].NodeRef;//Si on est pas dans l'arbre on prend le node à l'indice currentchoice
            }
            else
            {
                node = _currentNode.Children[_currentChoice];//On prend l'enfant du currentNode
            }

            if(CurrentItem != null && node.Obj is Hunter)
            {
                //Si il existe un objet en attente d'une cible

                Hunter target = (Hunter)node.Obj;

                if (CurrentItem.Use(Fight.CurrentFighter, target))
                {
                    CurrentItem.Use(target); //Ici le node Object est une attack
                    if (MainPlayer.GetIndexItem(CurrentItem) == -1) { throw new Exception("Current item doesn't exist"); }

                    MainPlayer.Inventory.NodeRef.DeleteChildren(MainPlayer.GetIndexItem(CurrentItem));
                    Fight.UpdateCurrentTurn();
                    UpdateHero();
                    Nodes[0] = Player.Team[CurrentHero];
                    CurrentItem = null;
                }

                CurrentChoice = 0;
            }
            else if (node.HasChildren() == true )//Navigue dans l'enfant sous-jascent
            {
                _currentNode = node;
            }
            else if (node.Obj.IsUsableOnTarget == true)//Si le node selectionnée est utilisable sur une target
            {
                if(node.Obj is Attack)
                {
                    CurrentSpell = (Attack)node.Obj;

                    if(CurrentSpell.MagicCost > Fight.CurrentFighter.Mana) { return; }

                    if (CurrentSpell.AlliesTarget == true)
                    {
                        //Si le sort est un boost, on affiche les alliées éligibles à ce sort
                        CurrentNode = Arbre.Root.GetChildByName("Team");
                        CurrentChoice = 0;
                    }
                    else
                    {
                        //Si le sort est un sort de dmg, on affiche les ennemis
                        CurrentNode = ArbreEnemy.Root;
                        CurrentChoice = 0;
                    }
                }
                else if(node.Obj is GameItem)
                {
                    CurrentItem = (GameItem)node.Obj;

                    //Si le sort est un boost, on affiche les alliées éligibles à ce sort
                    CurrentNode = Arbre.Root.GetChildByName("Team");
                    CurrentChoice = 0;

                }
            }
            else if(CurrentSpell != null)//Si il y a un spell en reserve à utiliser
            {
                //Si il existe un spell en attente d'une cible

                Character target = (Character)_currentNode.Children[_currentChoice].Obj;

                if (CurrentSpell.Use(Fight.CurrentFighter, target))
                {
                    if (target.Health == 0)
                    {
                        if (_currentNode.Children[_currentChoice].Obj is Enemy)
                        {
                            ArbreEnemy.RemoveNode(target);
                            Fight.ActionOrder.Remove(target);
                            Fight.Enemies.Remove((Enemy)target);
                        }
                    }
                    Fight.UpdateCurrentTurn();
                    UpdateHero();
                    Nodes[0] = Player.Team[CurrentHero];

                    //Reset
                    CurrentNode = Arbre.Root;
                    CurrentSpell = null;

                }//Ici le node Object est une attack
                CurrentChoice = 0;

            }
            else// Si rien on utilise l'objet selectionné
            {
                node.Obj.Use(null,Fight.CurrentFighter);
                CurrentChoice = 0;
            }
            
        }
        #endregion Fight
        
        public void UpdateChoice(int i)
        {
            if(CurrentNode.Obj.Name == "Root")
            {
                if (Nodes.Count == 0) { return; }
                _currentChoice = (_currentChoice + i) % Nodes.Count;
                if (_currentChoice < 0) _currentChoice += Nodes.Count;
            }
            else
            {
                if (_currentNode.ChildrenCount == 0) { return; }
                _currentChoice = (_currentChoice + i) % _currentNode.ChildrenCount;
                if (_currentChoice < 0) _currentChoice += _currentNode.ChildrenCount;
            }
        }

        public void UpdateHero()
        {
            CurrentHero = (CurrentHero + 1) % 4;
            if (CurrentHero < 0) CurrentHero += 4;
        }

        public void PrintAttackStats(Attack att)
        {
            Console.SetCursorPosition(X + Width/2 + 15, Y + 3);
            Console.Write("Dégats: " + att.Damage);
            Console.SetCursorPosition(X + Width / 2 + 15 + 25, Y + 3);
            Console.Write("Précision: " + att.Accuracy);

            Console.SetCursorPosition(X + Width/ 2 + 15, Y + 5);
            Console.Write("Cout en mana: " + att.Damage);
            Console.SetCursorPosition(X + Width / 2 + 15 + 25, Y + 5);

            Console.Write("Type: ");
            Console.ForegroundColor = dicoCouleur[att.Element];
            Console.Write(att.Element);
            Console.ForegroundColor = ConsoleColor.White;

            Console.SetCursorPosition(X + Width / 2 + 15, Y + 7);
            Console.Write("Description: ");
            Console.SetCursorPosition(X + Width / 2 + 15, Y + 9);
            Console.Write(att.Descriptor);

        }

        #endregion Methods
    }
}
