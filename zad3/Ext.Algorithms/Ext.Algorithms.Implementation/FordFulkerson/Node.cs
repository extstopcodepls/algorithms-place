namespace Ext.Algorithms.Implementation.FordFulkerson
{
    class Node  //klasa Node która reprezentuje węzeł sieci przepływowej
    {
        public string Name { get; set; }
        public Node(string name)
        {
            Name = name;
        }

        //nadpisana metoda z klasy bazowej, słuzy do porównywania dwóch obiektów
        public override bool Equals(object obj)
        {
            return Name == ((Node)obj).Name;
        }
    }
}
