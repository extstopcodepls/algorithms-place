using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ext.Algorithms.BFS.BFS.Graphs
{
    interface IGraph<T>
    {
        bool IsDirected { get; set; }
        T StartingNode { get; set; }
    }
}
