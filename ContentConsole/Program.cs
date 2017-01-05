using System;
using System.Linq;

namespace ContentConsole
{
    public static class Program
    {
        public static void Main(string[] args)
        {

            string content =
                "The weather in Manchester in winter is bad. It rains all the time - it must be horrible for people visiting.";

            var negativeWords = System.IO.File.ReadAllLines(@"data\negativeWords.Txt");

            //clean any empty lines
            var negativeWordsCleanedUp = negativeWords.Select(s => s.Trim()).Where(s => string.IsNullOrWhiteSpace(s) == false);

            var analyzer = new TextAnalyzer.Analyzer(negativeWordsCleanedUp);

            var results = analyzer.AnalyzeText(content);

            Console.WriteLine("Scanned the text:");
            Console.WriteLine(results.Text);
            Console.WriteLine("Total Number of negative words: " + results.NegativeWordCount);

            Console.WriteLine("Press ANY key to exit.");
            Console.ReadKey();
        }
    }

}
