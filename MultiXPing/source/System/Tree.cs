using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MultiXPing
{
    public class Node
    {
        NodeObject _obj;
        NodeObject _parent;
        List<Node> _children;
        int _childrenCount;

        public NodeObject Obj { get => _obj; set => _obj = value; }
        public NodeObject Parent { get => _parent; set => _parent = value; }
        public List<Node> Children { get => _children; set => _children = value; }
        public int ChildrenCount { get => _childrenCount; set => _childrenCount = value; }

        public Node()
        {
            _obj = null;
            _parent = null;
            _children = new List<Node>();
            _childrenCount = 0; 
        }

        public void InsertChild(NodeObject obj)
        {
            Node noeud = new();
            noeud.Obj = obj;
            noeud.Parent = Obj;

            if (obj.NodeRef != null)
            {
                if (obj.NodeRef.HasChildren())
                {
                    for (int i = 0; i < obj.NodeRef.ChildrenCount; i++)
                    {
                        noeud.Children.Add(obj.NodeRef.Children[i]);
                        noeud.ChildrenCount++;
                    }
                }
            }

            if(Obj == null) { throw new NullReferenceException("Parent must be non nullable"); }
            _childrenCount++;
            Children.Add(noeud);
            obj.SetNode(noeud);


        }
        public void RemoveChild(NodeObject obj)
        {
            Children.Remove(obj.NodeRef);
            _childrenCount--;
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

        public void PrintChildrenOnly(int x, int y, int currentChoice)
        {
            Console.SetCursorPosition(x,y);
            Console.Write(Obj.Name + " : ");
            if(ChildrenCount == 0) { return; }
            for (int i = 0; i < Children.Count(); i++)
            {
                Console.SetCursorPosition(x, y + i + 1);
                if(i == currentChoice)
                {
                    Console.Write("> ");
                }
                Console.Write(" - " + Children[i].Obj.Name);
            }
        }

        public bool HasChildren()
        {
            if(ChildrenCount == 0) { return false; }
            return true;
        }

        public void DeleteChildren(int index)
        {
            Children[index] = null;
            Children.RemoveAt(index);
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

        public void RemoveNode(NodeObject obj)
        {
            Root.RemoveChild(obj);
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

