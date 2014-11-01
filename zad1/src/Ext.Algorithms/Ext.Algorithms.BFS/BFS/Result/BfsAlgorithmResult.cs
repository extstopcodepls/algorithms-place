using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ext.Algorithms.BFS.BFS.Graphs;
using Ext.Algorithms.Core.Algorithms.Results;

namespace Ext.Algorithms.BFS.BFS.Result
{
    public class BfsAlgorithmResult<T> : IAlgorithmResult 
    {
        public List<T> Result { get; set; } 
    }
}
