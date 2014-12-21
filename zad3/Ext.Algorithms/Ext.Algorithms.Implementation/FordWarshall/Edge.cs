namespace Ext.Algorithms.Implementation.FordWarshall
{
    class Edge
    {
        //kostruktor klasy krawędź
        public Edge(string n1, string n2, int weight)
        {
            Node1 = n1;
            Node2 = n2;
            Weight = weight;
        }
        public string Node1 { get; set; }
        public string Node2 { get; set; }
        public int Weight { get; set; }

        //nadpisanie metody porównania dla obiektu klasy Edge, zwraca true jeśli wierzchołki obiektu podanego 
        //jako argument są równe wierzchołkom obiektu z którego wywoływana jest metoda
        public override bool Equals(object obj)
        {
            var edge = obj as Edge;
            return edge != null && (Node1 == edge.Node1 && Node2 == edge.Node2);
        }
    }
}
