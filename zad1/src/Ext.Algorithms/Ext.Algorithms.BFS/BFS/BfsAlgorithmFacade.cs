using Ext.Algorithms.BFS.BFS.Config;
using Ext.Algorithms.BFS.BFS.Graphs;
using Ext.Algorithms.BFS.BFS.Graphs.Factory;
using Ext.Algorithms.BFS.BFS.Input;
using Ext.Algorithms.Core.Algorithms.Config;
using Ext.Algorithms.Core.Algorithms.Inputs;
using Ext.Algorithms.Core.Algorithms.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ext.Algorithms.BFS.BFS
{
    public class BfsAlgorithmFacade
    {
        public BfsAlgorithmConfig Config { get; private set; }
        public BfsAlgorithmInput Input { get; private set; }

        private BfsAlgorithm<Node> _algorithm;

        public BfsAlgorithmFacade(IAlgorithmInput input, IAlgorithmConfiguration config)
        {
            Config = config as BfsAlgorithmConfig;
            Input = input as BfsAlgorithmInput;
        }

        public IAlgorithmResult Result()
        {
            var graphFactory = new GraphFactory();
            
            var data = Input.Data as IEnumerable<string>;

            var graph = graphFactory.Build<Node>(data);

            foreach (var item in graph.List)
            {
                item.Value.OrderBy(node => node.Label);
            }


            var startNode = new Node { Label = "x" + data.FirstOrDefault() };

            _algorithm = new BfsAlgorithm<Node>(graph, startNode);

            return _algorithm.Resolve();
        }

    }
}
