using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ext.Algorithms.BFS.BFS.Graphs
{
    public class Node : IEquatable<Node>
    {
        public string Label { get; set; }
        public bool IsVisited { get; set; }

        public bool Equals(Node other)
        {
            if (this.Label == other.Label)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
