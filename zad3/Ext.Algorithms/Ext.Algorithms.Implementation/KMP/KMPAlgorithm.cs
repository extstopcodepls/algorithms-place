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

            //var wholeText = GetWholeText(text);

            var textToSearch = data.Reverse().First();

            var result = String.Empty;

            var textLinesInWhichTextWasFound = new List<String>();

            var pTable = CreateP(textToSearch);


            result += "Paweł Borawski: " + GiveResult(pTable) + Environment.NewLine;

//            foreach (var textLine in text)
//                textLinesInWhichTextWasFound.AddRange(Search(pTable, text, textToSearch));

            textLinesInWhichTextWasFound.AddRange(Search(pTable, text, textToSearch));
            

            if (textLinesInWhichTextWasFound.Count > 0)
            {

                result += "Tekst znaleziono w następujacych linijkach: " + Environment.NewLine;

                result = textLinesInWhichTextWasFound.Aggregate(result,
                    (current, next) => current + (next + Environment.NewLine));
            }
            else
            {
                result += "Nie znaleziono tekstu";
            }

            return new StringAlgorithmResult(result);
        }

        private static String GetWholeText(IEnumerable<string> text)
        {
            return text.Aggregate(String.Empty, (source, next) => source + next);
        }

        private static string GiveResult(IEnumerable<int> pTable)
        {
            return pTable.Aggregate(String.Empty, (current, t) => current + (t + " "));
        }

        private static int[] CreateP(String textToSearch)
        {
            var pTable = new int[textToSearch.Length];

            var textToSearchLength = textToSearch.Length;

            pTable[0] = 0;
            var t = 0; int j;
            for (j = 1; j < textToSearchLength - 1; j++)
            {
                if (textToSearch[j] == textToSearch[t])
                {
                    t++;
                    pTable[j] = t;           

                    continue;
                }

                t = 0;
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
                    result.Add(textLine + ", i: " + j);
                    break;
                }
                i = i + Math.Max(1, j - pTable[j]);
            }

            return result;
        }

        private static IEnumerable<string> Search(IList<int> pTable, IEnumerable<string> textLines, string textToSearch)
        {
            var textLine = GetWholeText(textLines);
            var textLineLenght = textLine.Length;
            var textToSearchLength = textToSearch.Length;

            var result = new List<string>();

            var j = 0;
            for (var i = 1; i <= textLineLenght; i++)
            {
                while (j > 0 && textToSearch[j] != textLine[i - 1])
                {
                    j = pTable[j > 0 ? j - 1 : 0];
                }

                if (textToSearch[j] == textLine[i - 1])
                {
                    j++;
                }

                if (j == textToSearchLength)
                {
                    var index = i - j + 1;

                    result.Add("i: " + index);
                }

                j = pTable[j > 0 ? j - 1 : 0];

            }

            return result;
        }
    }
}