using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MultiXPing
{
    public struct Node
    {
        NodeObject? _obj;
        NodeObject? _parent;
        List<Node> _children;

        public NodeObject Obj { get => _obj; set => _obj = value; }
        public NodeObject Parent { get => _parent; set => _parent = value; }
        public List<Node> Children { get => _children; set => _children = value; }
        
        public Node()
        {
            _obj = null;
            _parent = null;
            _children = new List<Node>();
        }

        public void InsertChild(NodeObject obj)
        {
            Node noeud = new();
            noeud.Obj = obj;
            noeud.Parent = Obj;
            if(Obj == null) { throw new NullReferenceException("Parent must be non nullable"); }
            
            Children.Add(noeud);
            obj.SetNode(noeud);
            
        }

        public void PrintNode(string offset)
        {
            //Pseudo fonction récursive qui print le nom du noeud et de ses enfants
            Console.Write(offset+"- "+Obj.Name+"\n");
            for (int i = 0; i < Children.Count(); i++)
            {
                Children[i].PrintNode(offset + " ");
            }
        }

        public void PrintChildrenOnly()
        {
            for (int i = 0; i < Children.Count(); i++)
            {
                Console.Write("- " + Obj.Name + "\n");
            }
        }
    }

    public struct Tree
    {

        Node _root;

        public Node Root { get => _root; set => _root = value; }

        public Tree ()
        {
            _root = new Node();
            _root.Obj = new Root();
        }

        public void AddNode(NodeObject obj)
        {
            Root.InsertChild(obj);
        }

        public void PrintTree()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("root \n");
            for(int i = 0; i < Root.Children.Count(); i++)
            {
                Root.Children[i].PrintNode("");
            }
        }

    }
}

