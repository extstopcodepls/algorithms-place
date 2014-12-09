using CLAP;
using Ext.Algorithms.BFS.BFS;
using Ext.Algorithms.BFS.BFS.Graphs;
using Ext.Algorithms.BFS.BFS.Input;
using Ext.Algorithms.BFS.BFS.Resolver;
using Ext.Algorithms.Common;
using Ext.Algorithms.Core.Algorithms.Inputs;
using System;
using System.Collections.Generic;
using System.IO;

namespace Ext.Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            var parser = new Parser<AlgorithmApp>();

            parser.Register.ErrorHandler(context =>
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(context.Exception.Message);
                Console.ResetColor();
            });

            var algorithmApp = new AlgorithmApp();
            parser.Run(args, algorithmApp);
        }
    }

    class AlgorithmApp
    {
        [Empty, Help]
        [Verb(Aliases="h,help")]
        public void Help(string help)
        {
            Console.WriteLine(help);
        }

        [Verb(
            Description = "Algorytm przeszukiwania grafu w szerz",
            IsDefault = true)]
        public void BFS(
            [Description("Sciezka do pliku wejsciowego")]
            [Aliases("fin")]
            string inputFilename,

            [Aliases("fout")]
            [Description("Sciezka do pliku wyjsciowego")]
            string outputFilename,

            [Description("Czy wypisywać wyniki na ekran?")]
            bool verbose)
        {

            IAlgorithmInput input;

            IEnumerable<string> data;

            if (File.Exists(inputFilename))
	        {
                data = File.ReadLines(inputFilename);
		        input = new BfsAlgorithmInput
                {
                    Data = data
                };
	        }
            else
            {
                throw new Exception("Brak pliku");
            }

            var algorithmFacade = new BfsAlgorithmFacade(input, null);

            var result = algorithmFacade.Result();

            var resultResolver = new BfsAlgorithmResultToContentResolver<Node>(result);

            var stringResult = resultResolver.Resolve();

            if (verbose)
            {
                Console.WriteLine("Zawartosc pliku wejsciowego");
                foreach (var line in data)
                {
                    Console.WriteLine(line);
                }
                Console.WriteLine(Environment.NewLine);
                Console.WriteLine("Zawartosc pliku wyjsciowego");
                Console.WriteLine(stringResult);
            }

            

            FileContentSaver.Save(stringResult, outputFilename);
        }

    }
}
