using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestBlazorTwo.Helpers;

namespace TestBlazorTwo.ViewModels
{
    public class Tree
    {
        public int Id { get; set; }
        public string Item_Id { get; set; }
        public string Text { get; set; }
        public string Type { get; set; }
        public string NewType { get; set; }
        public string Placeholder { get; set; }
        public string Parent_Id { get; set; }
        public bool IsActive { get; set; }
        public bool collapsed { get; set; }
        //public Options Options { get; set; }
        //public Responses Responses { get; set; } = new Responses();

        protected List<Tree> _children;
        protected Tree _parent;

        public Tree()
        {
            Text = string.Empty;
        }

        public Tree ShallowCopy()
        {
            return (Tree)this.MemberwiseClone();
        }

        public Tree Parent { get => _parent; set { _parent = value; } }
        public Tree Root { get { return _parent == null ? this : _parent.Root; } }
        //public int Depth { get { return this.Ancestors().Count() - 1; } }

        public IEnumerable<Tree> Children
        {
            get { return _children == null ? Enumerable.Empty<Tree>() : _children.ToArray(); }
            set { _children = (List<Tree>)value; }
        }

        public int Order_Id { get; internal set; }

        public override string ToString()
        {
            return Text;
        }

        public void Add(Tree child)
        {
            if (child == null)
                throw new ArgumentNullException();
            if (child._parent != null)
                throw new InvalidOperationException("A tree node must be removed from its parent before adding as child.");
            if (this.Ancestors().Contains(child))
                throw new InvalidOperationException("A tree cannot be a cyclic graph.");

            if (_children == null)
            {
                _children = new List<Tree>();
            }

            child._parent = this;
            _children.Add(child);
        }
    }
}
