using LSI_Theme_Finder.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LSI_Theme_Finder
{
    internal class ThemeUnit
    {
        public static List<Tuple<string, int>> GetThemeWords(IEnumerable<string> incoming, IEnumerable<string> ignoreWords)
        {
            var themeResults = new Dictionary<string, int>();
            foreach (string text in incoming)
            {
                var words = Phrase.SplitBySize(text, 1);
                var listOfWords = GetListOfUniqueWordsBlackList(words, ignoreWords);
                UpdateThemeResults(themeResults, listOfWords);
            }

            return MapToThemeResults(themeResults);
        }

        public static List<Tuple<string, int>> GetThemePhrases(IEnumerable<string> incoming, IEnumerable<string> whiteList, int size)
        {
            var themeResults = new Dictionary<string, int>();
            foreach (string text in incoming)
            {
                var words = Phrase.SplitBySize(text, size);
                var listOfWords = GetListOfUniquePhrasesWhiteList(words, whiteList);
                UpdateThemeResults(themeResults, listOfWords);
            }

            return MapToThemeResults(themeResults);
        }

        private static IEnumerable<string> GetListOfUniquePhrasesWhiteList(IEnumerable<string> phrases, IEnumerable<string> whiteList)
        {
            var hashset = new HashSet<string>();
            foreach (var phrase in phrases)
            {
                var union = phrase.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries).Union(whiteList);
                if (union.Any())
                {
                    hashset.Add(phrase);
                }
            }

            return hashset;
        }

        private static IEnumerable<string> GetListOfUniqueWordsBlackList(IEnumerable<string> words, IEnumerable<string> ignoreWords)
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

        private static List<Tuple<string, int>> MapToThemeResults(Dictionary<string, int> themeResults)
        {
            var results = new List<Tuple<string, int>>();
            foreach (var item in themeResults)
            {
                results.Add(new Tuple<string, int>(item.Key, item.Value));
            }

            return results;
        }
    }
}
