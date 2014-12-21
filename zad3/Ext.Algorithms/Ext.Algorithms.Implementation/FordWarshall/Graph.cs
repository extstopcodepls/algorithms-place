using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Ext.Algorithms.Implementation.FordWarshall
{
    class Graph
    {
        public List<string> Nodes = new List<string>();
        public List<Edge> Edges = new List<Edge>();
        public int Type { get; set; }
        public Graph(int type)
        {
            Type = type;
        }

        //dodanie krawędzi
        public void AddEdge(string n1, string n2, int weight)
        {
            var tmp = new Edge(n1, n2, weight);
            if (!Edges.Any(p => p.Equals(tmp)))
            {
                Edges.Add(tmp);
            }

            AddNode(n1);
            AddNode(n2);
        }

        //dodanie wierzchołka
        private void AddNode(string name)
        {
            var tmp = Nodes.Find(n => n == name);

            if(tmp == null)
            {
                Nodes.Add(name);
            }        
        }

        //szukanie krawędzi
        public Edge FindEdge(string w1, string w2)
        {
            return Edges.Find(e => e.Node1 == w1 && e.Node2 == w2);
        }

        //wypisanie macierzy sąsiedztwa
        public static double[,] ArrayNeighborhood(Graph graph)
        {
            var length = graph.Nodes.Count; 
            var array = new double[length, length];
            for (var i = 0; i < length; i++)
            {
                for (var j = 0; j < length; j++)
                {
                    if (i == j) continue;

                    var edge = graph.FindEdge(graph.Nodes[i], graph.Nodes[j]);

                    array[i, j] = edge == null ? 0 : edge.Weight;
                }
            }

            return array;
        }

        //wczytanie grafu z pliku wejściowego
        public static Graph ReadGraph(IEnumerable<string> fileContent)
        {
            var fileCnt = fileContent as string[] ?? fileContent.ToArray();
            var typeGraph = Int32.Parse(fileCnt[2]);
            var graph = new Graph(typeGraph);

            for (var i = 3; i < fileCnt.Length; i++)
            {
                var dataEdge = fileCnt[i].Split(' ');
                var waga = Int32.Parse(dataEdge[2]);

                graph.AddEdge(dataEdge[0], dataEdge[1], waga);
                if (graph.Type == 0)
                    graph.AddEdge(dataEdge[1], dataEdge[0], waga);  
            }

            graph.Nodes.Sort();

            return graph;
        }
    }
}
