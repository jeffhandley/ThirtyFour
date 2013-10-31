using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ThirtyFour
{
    public static class Anagram
    {
        internal static bool AreWordsAnagrams(string word1, string word2)
        {
            if (string.IsNullOrWhiteSpace(word1) || string.IsNullOrWhiteSpace(word2))
            {
                return false;
            }

            word1 = Sanitize(word1);
            word2 = Sanitize(word2);

            if (word1.Length != word2.Length)
            {
                return false;
            }

            var sorted1 = word1.ToLowerInvariant().OrderBy(c => c);
            var sorted2 = word2.ToLowerInvariant().OrderBy(c => c);

            return sorted1.SequenceEqual(sorted2);
        }

        private static string Sanitize(string word)
        {
            return word.Replace(" ", "");
        }
    }
}
