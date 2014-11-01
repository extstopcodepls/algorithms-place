using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ext.Algorithms.BFS.BFS.Graphs.Factory
{
    public class NodeComparer : IEqualityComparer<Node>
    {
        public bool Equals(Node x, Node y)
        {
            if (x.Label == y.Label)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int GetHashCode(Node obj)
        {
            return 0;
        }
    }
}
