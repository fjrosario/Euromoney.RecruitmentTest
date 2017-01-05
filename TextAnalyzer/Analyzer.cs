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
        public Analyzer(IEnumerable<string> negativeWords)
        {
            _negativeWords = negativeWords.Select(s => s.ToLower());
        }

        public IEnumerable<string> GetNegativeWordsInText(string text)
        {
            var wordsInText = ExtractWordsFromText(text);

            var negativeWordsInText = wordsInText.Where(_negativeWords.Contains);

            return negativeWordsInText.ToList();
        }

        public AnalysisResults AnalyzeText(string text)
        {
            var negativeWordsInText = GetNegativeWordsInText(text);

            var result = new AnalysisResults
            {
                Text = text,
                NegativeWordCount = negativeWordsInText.Count()
            };

            return result;
        }

        public string CensorWord(string word)
        {
            const char CENSORED_CHAR = '#';
            if (string.IsNullOrWhiteSpace(word) || word.Length < 2) return word;
            char first = word[0];
            char last = word[word.Length - 1];

            StringBuilder sb = new StringBuilder();
            sb.Append(first);
            for(int x=0; x<word.Length-2;x++)
            {
                sb.Append(CENSORED_CHAR);
            }
            sb.Append(last);

            return sb.ToString();
        }

        public ReplacementResults CensorText(string text)
        {
            var negativeWordsInText = GetNegativeWordsInText(text);

            var replacementText = text;

            var result = new ReplacementResults
            {
                Text = text,
                NegativeWordCount = negativeWordsInText.Count()
            };

            foreach(var negativeWord in negativeWordsInText)
            {
                replacementText = replacementText.Replace(negativeWord, CensorWord(negativeWord));
            }

            result.CensoredText = replacementText;

            return result;
        }


        public IEnumerable<string> ExtractWordsFromText(string text)
        {
            var wordsWithPunctuation = System.Text.RegularExpressions.Regex.Split(text, @"\W+").ToList().Select(s => s.ToLower());
            return wordsWithPunctuation;
        }

}
}
