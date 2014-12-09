using Ext.Algorithms.BFS.BFS.Graphs;
using Ext.Algorithms.BFS.BFS.Result;
using Ext.Algorithms.Core.Algorithms;
using Ext.Algorithms.Core.Algorithms.Results;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ext.Algorithms.BFS.BFS
{
    public class BfsAlgorithm<T> : IAlgorithm where T : Node, new()
    {
        private readonly ListIncydentialGraph<T> _graph;
        private readonly T _startNode;

        public BfsAlgorithm(ListIncydentialGraph<T> graph, T startNode)
        {
            _graph = graph;
            _startNode = startNode;
        }

        public IAlgorithmResult Resolve()
        {
            var list = _graph.List;

            var startingNode = list.Keys.FirstOrDefault(t => t.Label.Contains(_startNode.Label));

            var test = list.Keys.Where<Node>(n => n.IsVisited);

            var queue = new Queue<T>();
            var visitedList = new List<T>();

            if (startingNode == null)
            {
                if (!_graph.IsDirected) throw new ArgumentException("Nie znaleziono takiego node");
                visitedList.Add(_startNode);
                return new BfsAlgorithmResult<T> {Result = visitedList};
            }

            queue.Enqueue(startingNode);

            startingNode.IsVisited = true;

            while (queue.Count > 0)
            {
                var enqueuedItem = queue.Dequeue();

                enqueuedItem.IsVisited = true;

                visitedList.Add(enqueuedItem);

                List<T> connectedNodes;
                list.TryGetValue(enqueuedItem, out connectedNodes);

                if (connectedNodes != null)
                {
                    connectedNodes.ForEach(node =>
                    {
                        if (!queue.Contains(node) && !visitedList.Contains(node))
                        {
                            queue.Enqueue(node);
                        }
                    });
                }

            }

            return new BfsAlgorithmResult<T>{ Result = visitedList };
        }

        public void Prepare()
        {
        }

    }
}
