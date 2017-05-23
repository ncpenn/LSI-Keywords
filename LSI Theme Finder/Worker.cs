using LSI_Theme_Finder.Models;
using System.Collections.Generic;

namespace LSI_Theme_Finder
{
    public class Worker
    {
        private IReadOnlyCollection<string> _ignoreWords = new List<string> { "a", "and", "an", "the", "is", "are", "but", "still", "while", "I", "we", "you", "because", "when", "what" };


        public List<List<ThemedResult>> GetThemeElements(IEnumerable<string> incoming, uint maxPhraseSize = 4, IEnumerable<string> ignoreWords = null)
        {
            if (maxPhraseSize < 1)
            {
                return new List<List<ThemedResult>>();
            }

            if (ignoreWords == null)
            {
                ignoreWords = _ignoreWords;
            }

            var results = new List<List<ThemedResult>>();

            for (int i = 1; i <= maxPhraseSize; i++)
            {
                results.Add(ThemeUnit.Get(incoming, ignoreWords, i));
            }

            return results;
        }
    }
}
