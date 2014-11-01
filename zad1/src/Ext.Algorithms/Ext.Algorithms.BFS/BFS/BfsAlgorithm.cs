using Ext.Algorithms.BFS.BFS.Config;
using Ext.Algorithms.BFS.BFS.Graphs;
using Ext.Algorithms.BFS.BFS.Graphs.Factory;
using Ext.Algorithms.BFS.BFS.Input;
using Ext.Algorithms.BFS.BFS.Result;
using Ext.Algorithms.Core.Algorithms;
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
    public class BfsAlgorithm<T> : IAlgorithm where T : Node, new()
    {
        private ListIncydentialGraph<T> _graph;
        private T _startNode;

        public BfsAlgorithm(ListIncydentialGraph<T> graph, T startNode)
        {
            _graph = graph;
            _startNode = startNode;
        }

        public IAlgorithmResult Resolve()
        {
            var list = _graph.List;

            var startingNode = list.Keys.Where(t => t.Label.Contains(_startNode.Label)).FirstOrDefault();

            var queue = new Queue<T>();
            var visitedList = new List<T>();

            if (startingNode == null)
            {
                if (_graph.IsDirected)
                {
                    visitedList.Add(_startNode);
                    return new BfsAlgorithmResult<T> { Result = visitedList };
                }
                else
                {
                    throw new ArgumentException("Nie znaleziono takiego node");
                }
            }

            queue.Enqueue(startingNode);

            startingNode.IsVisited = true;

            while (queue.Count > 0)
            {
                var enqueuedItem = queue.Dequeue();

                enqueuedItem.IsVisited = true;

                visitedList.Add(enqueuedItem);

                var connectedNodes = new List<T>();
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
