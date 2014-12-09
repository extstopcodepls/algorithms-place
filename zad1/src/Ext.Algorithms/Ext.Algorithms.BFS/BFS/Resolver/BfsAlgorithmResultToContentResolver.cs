using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ext.Algorithms.BFS.BFS.Result;
using Ext.Algorithms.BFS.BFS.Graphs;
using Ext.Algorithms.Common;
using Ext.Algorithms.Core.Algorithms;
using Ext.Algorithms.Core.Algorithms.Results;

namespace Ext.Algorithms.BFS.BFS.Resolver
{
    public class BfsAlgorithmResultToContentResolver<T> : IAlgorithmResultToAnotherResultResovler
        where T : Node
    {

        private readonly BfsAlgorithmResult<T> _result;

        public BfsAlgorithmResultToContentResolver(IAlgorithmResult result)
        {
            if (result is BfsAlgorithmResult<T>)
            {
                _result = result as BfsAlgorithmResult<T>;
            }
            else
            {
                throw new ArgumentException("Blad i co");
            }

        }

        public string Resolve()
        {
            var list = _result.Result;

            var contents = new string[list.Count];

            list.ForEach((node, i) =>
            {
                contents[i] = node.Label;
            });

            var result = String.Join(" -> ", contents);

            return result;
        }
    }
}
