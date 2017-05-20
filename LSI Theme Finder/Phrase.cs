using System;
using System.Collections.Generic;
using System.Linq;

namespace LSI_Theme_Finder
{
    internal class Phrase
    {
        public static IEnumerable<string> SplitBySize(string text, int size)
        {
            var words = text.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToList();

            if (size == 1)
            {
                return words;
            }

            if (size > words.Count)
            {
                return new List<string>();
            }

            var results = new List<string>();
            for (int i = size - 1; i < words.Count; i++)
            {
                var subList = new List<string>();

                for (int j = 0; j < size; j++)
                {
                    subList.Add(words[i - j]);
                }

                results.Add(string.Join(" ", subList));
            }
            return results;
        }
    }
}
