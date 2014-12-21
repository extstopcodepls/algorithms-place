namespace Ext.Algorithms.Implementation.FordFulkerson
{
    class Channel   //klasa reprezentująca kanał sieci przepływowej
    {
        public Node Node1 { get; set; }
        public Node Node2 { get; set; }                 
        public int Capacity { get; set; }               
        public int ResidualCapacity { get; set; }       
        public int Flow { get; set; }                   
        public Channel(Node n1, Node n2, int capacity)
        {
            Node1 = n1;
            Node2 = n2;
            Capacity = capacity;
            ResidualCapacity = capacity;
            Flow = 0;
        }
        public void IncreaseFlow(int value)
        {
            Flow += value;
            ResidualCapacity -= value;
        }

        public bool HaveNode(Node node)
        {
            return Node1.Equals(node) || Node2.Equals(node);
        }

        public override bool Equals(object obj)
        {
            return Node1.Name == ((Channel)obj).Node1.Name && Node2.Name == ((Channel)obj).Node2.Name;
        }

        public override string ToString()               
        {
            return Node1.Name + "--" + Node2.Name + " " + Capacity + " " + ResidualCapacity + " " + Flow;
        }
    }
}
