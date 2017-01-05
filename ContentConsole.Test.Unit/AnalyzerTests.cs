using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentConsole.Test.Unit
{
    [NUnit.Framework.TestFixture]
    public class AnalyzerTests
    {
        const string TEST_STRING = "The weather in Manchester in winter is bad. It rains all the time - it must be horrible for people visiting.";
        const string CENSORED_TEST_STRING = "The weather in Manchester in winter is b#d. It rains all the time - it must be h######e for people visiting.";
        IEnumerable<string> negativeWords = new string[] {"swine", "bad", "nasty", "horrible"};

        [NUnit.Framework.Test]
        public void TestAnalysisWordCount()
        {
            var analyzer = new TextAnalyzer.Analyzer(negativeWords);
            var results = analyzer.AnalyzeText(TEST_STRING);
            NUnit.Framework.Assert.AreEqual(results.NegativeWordCount, 2);
        }

        [NUnit.Framework.Test]
        public void TestAnalysisIndividualWordReplacement()
        {
            var analyzer = new TextAnalyzer.Analyzer(negativeWords);
            var censoredWord = analyzer.CensorWord("horrible");
            NUnit.Framework.Assert.AreEqual(censoredWord, "h######e");
        }

        [NUnit.Framework.Test]
        public void TestAnalysisIndividualWordExtraction()
        {
            var analyzer = new TextAnalyzer.Analyzer(negativeWords);
            var results = analyzer.GetNegativeWordsInText(TEST_STRING);
            var test1 = results.Contains("horrible");
            var test2 = results.Contains("bad");
            NUnit.Framework.Assert.AreEqual(true, test1 && test2);
        }

        [NUnit.Framework.Test]
        public void TestAnalysisWordReplacement()
        {
            var analyzer = new TextAnalyzer.Analyzer(negativeWords);
            var results = analyzer.CensorText(TEST_STRING);
            NUnit.Framework.Assert.AreEqual(results.CensoredText, CENSORED_TEST_STRING);
        }


    }
}
