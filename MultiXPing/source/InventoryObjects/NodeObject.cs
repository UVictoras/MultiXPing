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
        bool _isUsableOnTarget = false;
        protected string _name = " node ";

        public string Name { get => _name; set => _name = value; }
        internal Node NodeRef { get => _nodeRef; set => _nodeRef = value; }
        public bool IsDestroyable { get => _isDestroyable; set => _isDestroyable = value; }
        public bool IsUsableOnTarget { get => _isUsableOnTarget; set => _isUsableOnTarget = value; }

        public void SetNode(Node node)
        {
            if (_nodeRef == default)
            {
                _nodeRef = node;
            }
        }

        public virtual bool Use(Character from, Character to) { return true; }

        public virtual bool Use() { return true; }

        public virtual bool Use(Hunter to) { return true; }

    }
}
