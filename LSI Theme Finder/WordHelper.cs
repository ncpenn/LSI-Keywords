using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSI_Theme_Finder
{
    internal static class WordHelper
    {
        static IReadOnlyCollection<char> stripThese = new List<char> { ',', '.', ':', ';', '"', '!', '?', '(', ')' };

        public static string Clean(this string incoming)
        {
            var cleaned = new List<char>();
            foreach (char item in incoming)
            {
                if (!stripThese.Contains(item))
                {
                    cleaned.Add(item);
                }
            }

            return string.Join("", cleaned);
        }
    }
}
