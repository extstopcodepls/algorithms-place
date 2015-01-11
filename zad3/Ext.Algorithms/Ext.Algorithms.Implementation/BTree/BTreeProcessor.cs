using System;
using System.Collections.Generic;
using System.Linq;

namespace Ext.Algorithms.Implementation.BTree
{
    public class BTreeProcessor : IAlgorithm
    {
        public IAlgorithmResult Process()
        {
            throw new System.NotImplementedException();
        }

        public IAlgorithmResult Process(IEnumerable<string> fileContent)
        {
            var content = fileContent as string[];

            if (content == null) return new StringAlgorithmResult("słabo");

            var m = 0;
            if(!Int32.TryParse(content[0], out m)) return new StringAlgorithmResult("słabo");

            var btree = new BTree<int, char>(m);

            var data = content[1].Split(' ');

            var dataToInsert = data.Select(x =>
            {
                var key = x[0];
                int value = key;

                return new KeyValuePair<int, char>(value, key);
            });

            btree.BulkInsert(dataToInsert);

            var treeBeforeOperation = btree.ToString();

            var op = content[2];

            String result;

            switch (op)
            {
                case "insert":
                    btree.Insert(content[3][0], content[3][0]);

                    result = "Drzewo przed operacją insert:";

                    result += Environment.NewLine;
                    result += treeBeforeOperation;
                    result += Environment.NewLine;

                    result += "Drzewo po wykonaniu operacji insert:";

                    result += Environment.NewLine;
                    result += btree.ToString();
                    result += Environment.NewLine;

                    return new StringAlgorithmResult(result);
                case "delete":
                    btree.Delete(content[3][0]);

                    result = "Drzewo przed operacją delete:";

                    result += Environment.NewLine;
                    result += treeBeforeOperation;
                    result += Environment.NewLine;

                    result += "Drzewo po wykonaniu operacji delete:";

                    result += Environment.NewLine;
                    result += btree.ToString();
                    result += Environment.NewLine;

                    return new StringAlgorithmResult(result);
                case "search":
                    var searchResult = btree.Search(content[3][0]);

                    result = "Drzewo:";

                    result += Environment.NewLine;
                    result += treeBeforeOperation;
                    result += Environment.NewLine;

                    if (searchResult != null)
                    {
                        result += "Znaleziono szukaną wartość:" + searchResult.Pointer;
                    }
                    else
                    {
                        result += "Nie odnaleziono szukanej wartości";
                    }

                    return new StringAlgorithmResult(result);
                default:
                    return new StringAlgorithmResult("co nie taka operacja");

            }
        }
    }
}