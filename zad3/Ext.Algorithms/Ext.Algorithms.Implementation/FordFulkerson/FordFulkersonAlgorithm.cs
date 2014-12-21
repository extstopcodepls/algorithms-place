using System;
using System.Collections.Generic;
using System.Linq;

namespace Ext.Algorithms.Implementation.FordFulkerson
{
    //klasa do wykonywania algorytmu Forda Fulkersona
    public class FordFulkersonAlgorithm : IAlgorithm
    {
        private readonly FlowNetworkManager _flowNetworkManager;

        public FordFulkersonAlgorithm()
        {
            _flowNetworkManager = new FlowNetworkManager();
        }

        public IAlgorithmResult Process()
        {
            return null;
        }

        public IAlgorithmResult Process(IEnumerable<string> fileContent)
        {
            var flownetwork = _flowNetworkManager.ReadFlowNetwork(fileContent);
            var calculateMaximumFlow = _flowNetworkManager.CalculateMaximumFlow(flownetwork);

            return new StringAlgorithmResult(calculateMaximumFlow);
        }
    }
}
