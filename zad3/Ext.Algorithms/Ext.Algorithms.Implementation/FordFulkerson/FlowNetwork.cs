using System;
using System.Collections.Generic;
using System.Linq;

namespace Ext.Algorithms.Implementation.FordFulkerson
{
    class FlowNetwork                                                               
    {
        public List<Node> Nodes = new List<Node>();                                
        public List<Channel> Channels = new List<Channel>();                        
        public Node StartNode { get; set; }                                         
        public Node EndNode { get; set; }                                           

        public FlowNetwork(Node startNode, Node endNode)                           
        {
            StartNode = startNode;
            EndNode = endNode;
        }

        public void AddChannel(Node first, Node second, int capacity)               
        {
            var tmp = new Channel(first, second,capacity);
            if (Channels.Any(p => p.Equals(tmp))) return;
            Channels.Add(tmp); 
            AddNode(first);   
            AddNode(second);  
        }

        public void RemoveChannel(Node first, Node second, int capacity = 0)
        {
            var tmp = new Channel(first, second, capacity);  
            if (!Channels.Any(p => p.Equals(tmp))) return;
            Channels.Remove(tmp);                      

            var nodeHaveChannel = false;                   
            foreach(var channel in Channels)      
            {
                if (channel.HaveNode(tmp.Node1))           
                    nodeHaveChannel = true;
            }
            if (!nodeHaveChannel)                          
            {
                RemoveNode(tmp.Node1);                    
            }
            nodeHaveChannel = false;
            foreach (var channel in Channels)    
            {
                if (channel.HaveNode(tmp.Node2))
                    nodeHaveChannel = true;
            }
            if (!nodeHaveChannel)
            {
                RemoveNode(tmp.Node2);
            }
        }

        private void AddNode(Node node)                                                 
        {
            var tmp = Nodes.Find(n => n.Name == node.Name);
            if (tmp == null)            
            {
                Nodes.Add(node);   
            }
        }
        private void RemoveNode(Node node)                                              
        {
            var tmp = Nodes.Find(n => n.Name == node.Name);
            if (tmp != null)
            {
                Nodes.Remove(node);
            }
        }

        public static void PrintIncidenceList(FlowNetwork network)                      
        {
            Console.WriteLine("Lista incydencji");

            foreach (var node in network.Nodes)
            {
                Console.Write("{0}: ", node.Name);
                var node1 = node;
                foreach (var channel in network.Channels.Where(channel => channel.Node1.Equals(node1)))
                {
                    Console.Write(" {0}", channel.Node2.Name);
                }
                Console.WriteLine();
            }
        }
    }
}
