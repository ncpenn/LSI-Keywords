using System;
using System.Collections.Generic;

namespace LSI_Theme_Finder.Models
{
    public class ThemedResult
    {
        public ThemedResult()
        {
            this.ThemePhrases = new List<Tuple<string, int>>();
            this.ThemeWords = new List<Tuple<string, int>>();
        }

        public List<Tuple<string, int>> ThemeWords { get; }

        public List<Tuple<string, int>> ThemePhrases { get; }
    }
}
