using LSI_Theme_Finder.Models;
using System.Collections.Generic;
using System.Linq;

namespace LSI_Theme_Finder
{
    internal class ThemeUnit
    {
        public static List<ThemedResult> Get(IEnumerable<string> incoming, IEnumerable<string> ignoreWords, int size)
        {
            var themeResults = new Dictionary<string, int>();
            foreach (string text in incoming)
            {
                var words = Phrase.SplitBySize(text, size);
                var listOfWords = GetListOfUniqueWords(words, ignoreWords);
                UpdateThemeResults(themeResults, listOfWords);
            }

            return MapToThemeResults(themeResults);
        }

        private static IEnumerable<string> GetListOfUniqueWords(IEnumerable<string> words, IEnumerable<string> ignoreWords)
        {
            var hashset = new HashSet<string>();
            foreach (var item in words)
            {
                if (!ignoreWords.Contains(item))
                {
                    hashset.Add(item);
                }
            }

            return hashset;
        }

        private static void UpdateThemeResults(Dictionary<string, int> themeResults, IEnumerable<string> listOfWords)
        {
            foreach (var item in listOfWords)
            {
                if (themeResults.ContainsKey(item))
                {
                    themeResults[item] = themeResults[item] + 1;
                }
                else
                {
                    themeResults.Add(item, 1);
                }
            }
        }

        private static List<ThemedResult> MapToThemeResults(Dictionary<string, int> themeResults)
        {
            var results = new List<ThemedResult>();
            foreach (var item in themeResults)
            {
                results.Add(new ThemedResult { Phrase = item.Key, Rank = (uint)item.Value });
            }

            return results;
        }
    }
}
