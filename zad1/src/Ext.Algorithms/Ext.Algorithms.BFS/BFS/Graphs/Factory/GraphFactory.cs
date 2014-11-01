using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ext.Algorithms.BFS.BFS.Graphs.Factory
{
    class GraphFactory
    {
        public ListIncydentialGraph<T> Build<T>(object data) where T : Node, new()
        {
            var graph = new ListIncydentialGraph<T>();

            var dict = new Dictionary<T, List<T>>(new NodeComparer());

            var listOfData = data as IEnumerable<string>;

            var elements = listOfData.ToList();

            elements.RemoveAll(s => String.IsNullOrEmpty(s));

            int nodeCount;
            if (!Int32.TryParse(elements[1], out nodeCount))
	        {
                throw new Exception("Błędna ilość wierzchołków 1");
	        }

            int isDirected;
            if (Int32.TryParse(elements[2], out isDirected))
            {
                if (isDirected == 0)
                {
                    graph.IsDirected = false;
                }
                else
                {
                    graph.IsDirected = true;
                }
            }

            graph.StartingNode = new T { Label = elements[0] };

            elements = elements.Skip(3).ToList();

            foreach (var element in elements)
            {
                var nodes = element.Split(' ').Reverse().Skip(1).Reverse().ToList();

                if (nodes.Count == 0)
                {
                    continue;
                }

                if (nodes.Count != 2)
	            {
                    throw new Exception("Lista elementów w linii jest większa niż 2");
	            }

                var node1 = new T();
                var node2 = new T();

                node1.Label = nodes[0];
                node2.Label = nodes[1];

                if (graph.IsDirected)
                {
                    AddToGraphDirected(dict, node1, node2); 
                }
                else
                {
                    AddToGraphUnDirected(dict, node1, node2);
                }

                

            }

            //if (nodeCount != dict.Keys.Count)
            //{
            //    throw new Exception("Błędna ilość wierzchołków 1");
            //}

            graph.List = dict;

            return graph;
        }

        private void AddToGraphDirected<T>(Dictionary<T, List<T>> dict, T node1, T node2) where T : Node, new()
        {
            if (!dict.ContainsKey(node1))
            {
                dict.Add(node1, new List<T> { node2 });
            }
            else
            {
                var list = dict[node1];

                if (!list.Contains(node2))
                {
                    list.Add(node2);
                    list.Sort((firstNode, secondNode) =>
                    {
                        return firstNode.Label.CompareTo(secondNode.Label);
                    });
                }

            }
        }

        private void AddToGraphUnDirected<T>(Dictionary<T, List<T>> dict, T node1, T node2) where T : Node, new()
        {
            if (!dict.ContainsKey(node1))
            {
                dict.Add(node1, new List<T> { node2 });
            }
            else
            {
                var list = dict[node1];

                if (!list.Contains(node2))
                {
                    list.Add(node2);
                    list.Sort((firstNode, secondNode) =>
                    {
                        return firstNode.Label.CompareTo(secondNode.Label);
                    });
                }
            }


            if (!dict.ContainsKey(node2))
            {
                dict.Add(node2, new List<T> { node1 });
            }
            else
            {
                var list = dict[node2];

                if (!list.Contains(node1))
                {
                    list.Add(node1);
                    list.Sort((firstNode, secondNode) =>
                    {
                        return firstNode.Label.CompareTo(secondNode.Label);
                    });
                }
            }
        }
    }
}
