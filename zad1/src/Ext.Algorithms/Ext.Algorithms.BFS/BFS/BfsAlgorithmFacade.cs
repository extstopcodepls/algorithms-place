using Ext.Algorithms.BFS.BFS.Config;
using Ext.Algorithms.BFS.BFS.Graphs;
using Ext.Algorithms.BFS.BFS.Graphs.Factory;
using Ext.Algorithms.BFS.BFS.Input;
using Ext.Algorithms.Core.Algorithms.Config;
using Ext.Algorithms.Core.Algorithms.Inputs;
using Ext.Algorithms.Core.Algorithms.Results;
using System.Collections.Generic;
using System.Linq;

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

            if (data == null) return null;

            var graph = graphFactory.Build<Node>(data);

            var firstLineOfData = data.FirstOrDefault();

            var labelOfFirstNode = firstLineOfData != null && firstLineOfData.Contains("x") ? firstLineOfData : "x" + firstLineOfData;
            
            var startNode = new Node { Label = labelOfFirstNode };

            _algorithm = new BfsAlgorithm<Node>(graph, startNode);

            return _algorithm.Resolve();
        }

    }
}
