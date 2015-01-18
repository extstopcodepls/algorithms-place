using System;
using System.Collections.Generic;
using System.Linq;

namespace Ext.Algorithms.Implementation.KMP
{
    public class KmpAlgorithm : IAlgorithm
    {
        private const String Break = "======================";

        public IAlgorithmResult Process()
        {
            return new StringAlgorithmResult(String.Empty);
        }

        public IAlgorithmResult Process(IEnumerable<string> fileContent)
        {
            var data = fileContent as string[] ?? fileContent.ToArray();

            var text = data.TakeWhile(str => str != Break).ToArray();

            var textToSearch = data.Reverse().First();

            var result = String.Empty;

            var textLinesInWhichTextWasFound = new List<String>();

            var pTable = CreateP(textToSearch);

            foreach (var textLine in text)
                textLinesInWhichTextWasFound.AddRange(Search(pTable, textLine, textToSearch));

            if (textLinesInWhichTextWasFound.Count > 0)
            {

                result += "Tekst znaleziono w następujacych linijkach: " + Environment.NewLine;

                result = textLinesInWhichTextWasFound.Aggregate(result,
                    (current, next) => current += next + Environment.NewLine);
            }
            else
            {
                result += "Nie znaleziono tekstu";
            }

            return new StringAlgorithmResult(result);
        }

        private static int[] CreateP(String textToSearch)
        {
            var pTable = new int[textToSearch.Length];

            var textToSearchLength = textToSearch.Length;

            pTable[0] = 0; pTable[1] = 0;
            var t = 0; int j;
            for (j = 2; j < textToSearchLength; j++)
            {
                while ((t > 0) && (textToSearch[t+1] != textToSearch[j]))
                    t = pTable[t];

                if (textToSearch[t+1] == textToSearch[j])
                    t++;

                pTable[j] = t;
            }

            return pTable;
        }

        private static IEnumerable<string> Search(IList<int> pTable, string textLine, string textToSearch)
        {
            var textLineLenght = textLine.Length;
            var textToSearchLength = textToSearch.Length;

            var result = new List<string>();

            var i = 1; var j = 0;
            while (i <= textLineLenght - textToSearchLength + 1)
            {
                j = pTable[j];
                while( ( j < textToSearchLength ) && ( textToSearch[j] == textLine[i+j-1] ) )
                    j++;
                if (j == textToSearchLength)
                {
                    result.Add(textLine);
                    break;
                }
                i = i + Math.Max(1, j - pTable[j]);
            }

            return result;
        }
    }
}