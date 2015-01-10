using System.Collections.Generic;

namespace Ext.Algorithms.Implementation.BTree
{
    public class BTreeNode<TK, TP>
    {
        private readonly int _degree;

        public BTreeNode(int degree)
        {
            _degree = degree;
            Children = new List<BTreeNode<TK, TP>>(degree);
            Entries = new List<Entry<TK, TP>>(degree);
        }

        public List<BTreeNode<TK, TP>> Children { get; set; }

        public List<Entry<TK, TP>> Entries { get; set; }

        public bool IsLeaf
        {
            get
            {
                return Children.Count == 0;
            }
        }

        public bool HasReachedMaxEntries
        {
            get
            {
                return Entries.Count == (2 * _degree) - 1;
            }
        }

        public bool HasReachedMinEntries
        {
            get
            {
                return Entries.Count == _degree - 1;
            }
        }
    }
}
