using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Ext.Algorithms.Implementation.FordFulkerson
{
    class FlowNetworkManager                                                //klasa do zarządzania siecią
    {
        public FlowNetwork ReadFlowNetwork(IEnumerable<string> fileContent)         //statyczna metoda do wczytywania sieci
        {
            var fileCnt = fileContent as string[] ?? fileContent.ToArray();
            var startEndNodes = fileCnt[0].Split(' ');
            var startNode = new Node(startEndNodes[0]);
            var endNode = new Node(startEndNodes[1]);

            var flowNetwork = new FlowNetwork(startNode, endNode);

            for (var i = 2; i < fileCnt.Length; i++)
            {
                var tmp = fileCnt[i].Split(' ');
                flowNetwork.AddChannel(new Node(tmp[0]), new Node(tmp[1]), Convert.ToInt32(tmp[2]));
            }
            return flowNetwork;
        }

        private bool HaveAugmentingPath(FlowNetwork flowNetwork)                 
        {
            //poszukiwanie najkrótszej ścieżki metodą DFS
            var stack = new Stack<Node>();
            var result = new List<Node>();
            stack.Push(flowNetwork.StartNode);
            while (stack.Count > 0)
            {
                var tmp = stack.Pop();
                if (result.Contains(tmp)) continue;
                result.Add(tmp);
                if (tmp.Name == flowNetwork.EndNode.Name) 
                    break;                                
                foreach (var channel in flowNetwork.Channels)
                {
                    if (!channel.Node1.Equals(tmp)) continue;
                    if (!result.Contains(channel.Node2))
                    {
                        stack.Push(channel.Node2);
                    }
                }
            }

            return result.Any(p => p.Name == flowNetwork.EndNode.Name);
        }

        public string CalculateMaximumFlow(FlowNetwork flowNetwork)                    
        {
            var stringResult = String.Empty;
            var maximumFlow = 0;
            while (HaveAugmentingPath(flowNetwork)) 
            {
                var stack = new Stack<Node>();
                var result = new List<Node>();
                var augmentingPaths = new List<Channel>();
                var flow = 1000;

                stack.Push(flowNetwork.StartNode);                          
                while (stack.Count > 0)
                {
                    var tmp = stack.Pop();
                    if (result.Contains(tmp)) continue;
                    result.Add(tmp);
                    if (tmp.Name == flowNetwork.EndNode.Name)
                        break;
                    foreach (var channel in flowNetwork.Channels)
                    {
                        if (!channel.Node1.Equals(tmp)) continue;
                        if (!result.Contains(channel.Node2))
                        {
                            stack.Push(channel.Node2);
                        }
                    }
                }


                stringResult += Environment.NewLine + "Aktualna sciezka rozszerzajaca" + Environment.NewLine;
                for (var i = 0; i < result.Count; i++)
                {
                    foreach (var chanel in flowNetwork.Channels)
                    {
                        if (chanel.Node1.Equals(result[i]) && chanel.Node2.Equals(result[i + 1 == result.Count ? i : i + 1]))
                        {
                            augmentingPaths.Add(chanel);
                            stringResult += chanel + Environment.NewLine;
                        }
                    }
                }

                foreach (var chanell in augmentingPaths)
                {
                    if (chanell.ResidualCapacity < flow)
                        flow = chanell.ResidualCapacity; //ustaw majmniejszy przepływ jako akutualny przepływ
                }

                stringResult += Environment.NewLine + "Aktualny przeplyw: " + flow + Environment.NewLine;

                foreach (var channel in flowNetwork.Channels)
                {
                    foreach (var augmentingPath in augmentingPaths)
                    {
                        if (channel.Equals(augmentingPath))
                        {
                            channel.IncreaseFlow(flow);
                        }
                    }
                }

                exitForEach:
                foreach (var channel in flowNetwork.Channels)
                {
                    foreach (var augmentingPath in augmentingPaths)
                    {
                        if (!channel.Equals(augmentingPath)) continue;
                        if (channel.ResidualCapacity != 0) continue;
                        flowNetwork.RemoveChannel(channel.Node1, channel.Node2); //usuń ten kanał
                        goto exitForEach;
                    }
                }


                //wypisz sieć po tej operacji
                stringResult += Environment.NewLine + "Aktualny stan sieci: " + Environment.NewLine;
                foreach (var channel in flowNetwork.Channels)
                {
                    stringResult += channel + Environment.NewLine;
                }

                //zwiększ maxymalny przepływ sieci
                maximumFlow += flow;
            }
            //wypisz maxymalny przepływ sieci
            stringResult += Environment.NewLine + "Maksymalny przeplyw: " + maximumFlow + Environment.NewLine;

            return stringResult;
        }
    }
}
