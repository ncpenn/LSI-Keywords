using LSI_Theme_Finder.Models;
using System.Collections.Generic;
using System.Linq;

namespace LSI_Theme_Finder
{
    public class Worker
    {
        private IReadOnlyCollection<string> _ignoreWords = new List<string> { "a", "and", "an", "the", "is", "are", "but", "still", "while", "I", "we", "you", "because", "when", "what" };


        public ThemedResult GetThemeElements(IEnumerable<string> incoming, uint maxPhraseSize = 4, IEnumerable<string> ignoreWords = null)
        {
            var themeResult = new ThemedResult();

            if (maxPhraseSize < 1)
            {
                return new ThemedResult();
            }

            if (ignoreWords == null)
            {
                ignoreWords = _ignoreWords;
            }

            themeResult.ThemeWords.AddRange(ThemeUnit.GetThemeWords(incoming, ignoreWords));
            for (int i = 2; i <= maxPhraseSize; i++)
            {
                themeResult.ThemePhrases.AddRange(ThemeUnit.GetThemePhrases(incoming, themeResult.ThemeWords.Select(x => x.Item1), i));
            }

            return themeResult;
        }
    }
}
