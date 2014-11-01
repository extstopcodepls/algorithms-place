using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ext.Algorithms.BFS.BFS.Graphs
{
    public class Graph<T> : IGraph<T>
    {
        public T[] V { get; set; }
        public T[] E { get; set; }
        public bool IsDirected { get; set; }
        public T StartingNode { get; set; }
    }
}
