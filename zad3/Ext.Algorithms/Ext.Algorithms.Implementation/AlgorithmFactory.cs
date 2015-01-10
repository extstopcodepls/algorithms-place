using System.Collections.Generic;
using Ext.Algorithms.Core.Enums;
using Ext.Algorithms.Implementation.BTree;
using Ext.Algorithms.Implementation.FordFulkerson;
using Ext.Algorithms.Implementation.FordWarshall;

namespace Ext.Algorithms.Implementation
{
    public static class AlgorithmFactory
    {
        public static readonly Dictionary<string, IAlgorithm> Algorithms =
            new Dictionary<string, IAlgorithm>
            {
                { ImplementedAlgorithms.FordFulkerson, new FordFulkersonAlgorithm() },
                { ImplementedAlgorithms.FordWarshall, new FordWarshallAlgorithm() },
                { ImplementedAlgorithms.BTree, new BTreeProcessor() },
            };
    }
}