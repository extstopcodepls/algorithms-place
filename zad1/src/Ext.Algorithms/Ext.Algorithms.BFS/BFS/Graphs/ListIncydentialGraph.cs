using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ext.Algorithms.BFS.BFS.Graphs
{
    public class ListIncydentialGraph<T> : IGraph<T>
    {
        public Dictionary<T, List<T>> List { get; set; }
        public bool IsDirected { get; set; }
        public T StartingNode { get; set; }
    }
}
