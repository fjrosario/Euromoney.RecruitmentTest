using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAnalyzer
{
    public class Analyzer
    {
        IEnumerable<string> _negativeWords;
        public Analyzer()
        {
            _negativeWords = new string[] { "swine","bad","nasty","horrible"}.Select(s => s.ToLower());
        }

        public AnalysisResults AnalyzeText(string text)
        {
            var wordsInText = ExtractWordsFromText(text);

            var negativeWordsInTextCount = wordsInText.Count(_negativeWords.Contains);

            var result = new AnalysisResults
            {
                Text = text,
                NegativeWordCount = negativeWordsInTextCount
            };

            return result;
        }
        public IEnumerable<string> ExtractWordsFromText(string text)
        {
            var wordsWithPunctuation = System.Text.RegularExpressions.Regex.Split(text, @"\W+").ToList().Select(s => s.ToLower());
            return wordsWithPunctuation;
        }

}
}
