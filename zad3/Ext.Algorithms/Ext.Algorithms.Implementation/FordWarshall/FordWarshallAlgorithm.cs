using System;
using System.Collections.Generic;
using System.Globalization;

namespace Ext.Algorithms.Implementation.FordWarshall
{
    public class FordWarshallAlgorithm : IAlgorithm
    {
        public IAlgorithmResult Process()
        {
            throw new NotImplementedException();
        }

        public IAlgorithmResult Process(IEnumerable<string> fileContent)
        {
            var stringResult = String.Empty;

            var graf = Graph.ReadGraph(fileContent);

            
            var arrayNeighbourhood = Graph.ArrayNeighborhood(graf);
            var arrayResult = new double[graf.Nodes.Count, graf.Nodes.Count];
            //inicjacja macierzy wynikowej, wypełnienie wartościami z macierzy sąsiedztwa
            
            for (var i = 0; i < arrayResult.GetLength(0); i++)
            {
                for (var j = 0; j < arrayResult.GetLength(1); j++)
                    arrayResult[i, j] = arrayNeighbourhood[i, j] == 0.0d ? double.PositiveInfinity : arrayNeighbourhood[i, j];

                arrayResult[i, i] = 0;
            }

            //algorytm
            for (var i = 0; i < arrayResult.GetLength(0); i++)
            {
                //wypisanie rezultatu dla k
                stringResult += "k= " + (i + 1) + Environment.NewLine;
                for (var a = 0; a < arrayResult.GetLength(0); a++)
                {
                    for (var b = 0; b < arrayResult.GetLength(1); b++)
                    {
                        stringResult += double.PositiveInfinity.Equals(arrayResult[a, b]) ? " * " : " " + arrayResult[a, b].ToString(CultureInfo.InvariantCulture) + " ";
                    }
                    stringResult += Environment.NewLine;
                }
                //operacje algorytmu

                for (var j = 0; j < arrayResult.GetLength(0); j++)
                {
                    for (var k = 0; k < arrayResult.GetLength(0); k++)
                    {
                        if (arrayResult[j, k] > arrayResult[j, i] + arrayResult[i, k])
                            arrayResult[j, k] = arrayResult[j, i] + arrayResult[i, k];
                    }
                }

            }

            //wypisanie wyników
            stringResult += Environment.NewLine;
            stringResult += "Macierz wynikowa" + Environment.NewLine;
            for (var i = 0; i < arrayResult.GetLength(0); i++)
            {
                for (var j = 0; j < arrayResult.GetLength(1); j++)
                {
                    stringResult += double.PositiveInfinity.Equals(arrayResult[i, j]) ? " * " : " " + arrayResult[i, j].ToString(CultureInfo.InvariantCulture) + " ";
                }
                stringResult += Environment.NewLine;
            }
            
            return new StringAlgorithmResult(stringResult);
        }
    }
}