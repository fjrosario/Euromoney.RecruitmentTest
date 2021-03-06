﻿using System;
using System.Linq;

namespace ContentConsole
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            bool disableFiltering = false;

            if(args.Count() > 0)
            {
                if(args[0].ToLower() == "disablefiltering")
                {
                    disableFiltering = true;
                }
            }
            string content =
                "The weather in Manchester in winter is bad. It rains all the time - it must be horrible for people visiting.";

            var negativeWords = System.IO.File.ReadAllLines(@"data\negativeWords.Txt");

            //clean any empty lines
            var negativeWordsCleanedUp = negativeWords.Select(s => s.Trim()).Where(s => string.IsNullOrWhiteSpace(s) == false);

            var analyzer = new TextAnalyzer.Analyzer(negativeWordsCleanedUp);

            if(disableFiltering == true)
            {
                var results = analyzer.CensorText(content);
                Console.WriteLine("Scanned the text:");
                Console.WriteLine(results.Text);
                Console.WriteLine("Total Number of negative words: " + results.NegativeWordCount);
            }
            else
            {
                var results = analyzer.CensorText(content);
                Console.WriteLine("Scanned the text.");
                Console.WriteLine("Total Number of negative words: " + results.NegativeWordCount);
                Console.WriteLine("Censored Text:");
                Console.WriteLine(results.CensoredText);
            }


            Console.WriteLine("Press ANY key to exit.");
            Console.ReadKey();
        }
    }

}
