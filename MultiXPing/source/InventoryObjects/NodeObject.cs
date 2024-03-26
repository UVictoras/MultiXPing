using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiXPing
{
    public abstract class NodeObject
    {
        Node _nodeRef = default;
        bool _isDestroyable = false;
        protected string _name = " node ";

        public string Name { get => _name; set => _name = value; }
        internal Node NodeRef { get => _nodeRef; set => _nodeRef = value; }
        public bool IsDestroyable { get => _isDestroyable; set => _isDestroyable = value; }

        public void SetNode(Node node)
        {
            _nodeRef = node;
        }

        public virtual bool Use() { return true; }

    }
}
