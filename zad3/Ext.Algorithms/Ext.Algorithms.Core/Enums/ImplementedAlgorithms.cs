using System.Collections;
using System.Collections.Generic;

namespace Ext.Algorithms.Core.Enums
{
    public static class ImplementedAlgorithms
    {
        static ImplementedAlgorithms()
        {
            AlgorithmsTypes.Add(FordFulkerson);
            AlgorithmsTypes.Add(FordWarshall);
            AlgorithmsTypes.Add(BTree);
            AlgorithmsTypes.Add(Another);
            AlgorithmsTypes.Add(Kmp);
        }

        public const string FordFulkerson = "Ford-Fulkerson";
        public const string FordWarshall = "Ford-Warshall";
        public const string BTree = "B-Drzewo";
        public const string Kmp = "Algorytm KMP";
        public const string Another = "Inne-takie";

        public static readonly IList<string> AlgorithmsTypes = new List<string>();
    }
}