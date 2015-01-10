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

            content = content.Skip(1).ToArray();

            var btree = new BTree<int, char>(m);

            var data = content[0].Split(' ');

            var dataToInsert = data.Select(x =>
            {
                var key = x[0];
                int value = key;

                return new KeyValuePair<int, char>(value, key);
            });

            btree.BulkInsert(dataToInsert);

            return new StringAlgorithmResult(btree.ToString());
        }
    }
}