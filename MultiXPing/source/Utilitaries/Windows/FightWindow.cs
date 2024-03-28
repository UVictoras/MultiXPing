﻿using System;
using System.Collections.Generic;
using System.Data;
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
        int _currentHero = 0;
        Node _currentNode;
        Player _player;

        Fight _fight;

        Attack _currentSpell = null;
        GameItem _currentItem = null;

        List<NodeObject> _nodes = new List<NodeObject>();

        Tree _arbre;
        Tree _arbreEnemy;

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
        internal Fight Fight { get => _fight; set => _fight = value; }
        public GameItem CurrentItem { get => _currentItem; set => _currentItem = value; }
        public int CurrentHero { get => _currentHero; set => _currentHero = value; }



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
            base.DrawContent();
            for (int i = 0; i < MainPlayer.Team.ListTeam.Count; ++i)
            {
                if (MainPlayer.Team.ListTeam[i].Health > 0)
                {
                    Console.SetCursorPosition(3, 2 + 5 * i);
                    Console.WriteLine(MainPlayer.Team.ListTeam[i].Name);
                    Console.SetCursorPosition(4, 3 + 5 * i);
                    DrawHealtBar(MainPlayer.Team.ListTeam[i], i);
                    Console.SetCursorPosition(4, 4 + 5 * i);
                    DrawManaBar(MainPlayer.Team.ListTeam[i], i);
                    Console.SetCursorPosition(25, 3 + 5 * i);
                    MainPlayer.Team.ListTeam[i].DrawSprite(25, 3 + 5 * i);
                }
            }

            for (int i = 0; i < Enemies.Count; ++i)
            {
                if (Enemies[i].Health > 0)
                {
                    Console.SetCursorPosition(Constants.WIDTH - 25, 2 + 5 * i);
                    Console.WriteLine(Enemies[i].Name);
                    Console.SetCursorPosition(Constants.WIDTH - 25, 3 + 5 * i);
                    DrawHealtBar(Enemies[i], i);
                    Console.SetCursorPosition(Constants.WIDTH - 32, 3 + 5 * i);
                    Enemies[i].DrawSprite(Constants.WIDTH - 32, 3 + 5 * i); ;
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

            Content = "Tour de : ";

        }

        public void Select()
        {
            if (MainPlayer.Team.ListTeam.Contains(Fight.CurrentFighter))
            {
                Node node;

                if (CurrentNode.Obj.Name == "Root")
                {
                    node = Nodes[_currentChoice].NodeRef;
                }else
                {
                    node = _currentNode.Children[_currentChoice];
                }

                if (node.HasChildren() == true)
                {
                    _currentNode = node;
                }
                else if (node.Obj.IsUsableOnTarget == true)
                {
                    if(node.Obj is Attack)
                    {
                        CurrentSpell = (Attack)node.Obj;

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
                        CurrentNode = Arbre.Root.GetChildByName("Inventory");
                        CurrentChoice = 0;

                    }

                    
                }
                else if(CurrentSpell != null)
                {
                    //Si il existe un spell en attente d'une cible

                    Character target = (Character)_currentNode.Children[_currentChoice].Obj;

                    if (CurrentSpell.Use(Fight.CurrentFighter, target))
                    {
                        CurrentNode = Arbre.Root;
                        CurrentSpell = null;
                        Fight.UpdateCurrentTurn();
                        UpdateHero();
                        Nodes[0] = Player.Team[CurrentHero];
                    }//Ici le node Object est une attack
                    
                }
                else if (CurrentItem != null)
                {
                    //Si il existe un objet en attente d'une cible

                    Hunter target = (Hunter)_currentNode.Children[_currentChoice].Obj;

                    if (CurrentItem.Use(Fight.CurrentFighter, target))
                    {
                        CurrentItem.Use(target); //Ici le node Object est une attack
                        CurrentItem = null;
                        Fight.UpdateCurrentTurn();
                        UpdateHero();
                        Nodes[0] = Player.Team[CurrentHero];
                    }
                }
                else
                {
                    node.Obj.Use(null,Fight.CurrentFighter);
                }
            }
            
            else
            {
                // Au tour de l'ennemis, donc y'a du texte à passer 
            }
        }
        #endregion Fight


        public void UpdateTurn(Character fighter)
        {

        }
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


        #endregion Methods
    }
}
