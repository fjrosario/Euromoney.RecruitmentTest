using System;

namespace ContentConsole
{
    public static class Program
    {
        public static void Main(string[] args)
        {

            string content =
                "The weather in Manchester in winter is bad. It rains all the time - it must be horrible for people visiting.";

            var analyzer = new TextAnalyzer.Analyzer();

            var results = analyzer.AnalyzeText(content);

            Console.WriteLine("Scanned the text:");
            Console.WriteLine(results.Text);
            Console.WriteLine("Total Number of negative words: " + results.NegativeWordCount);

            Console.WriteLine("Press ANY key to exit.");
            Console.ReadKey();
        }
    }

}
