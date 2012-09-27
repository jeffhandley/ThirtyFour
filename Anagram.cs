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

            var charCounts = new Dictionary<string, int>(StringComparer.InvariantCultureIgnoreCase);

            for (int x = 0; x < word1.Length; ++x)
            {
                string char1 = word1[x].ToString();
                string char2 = word2[x].ToString();

                if (char1 != char2)
                {
                    if (charCounts.ContainsKey(char1))
                    {
                        if (++charCounts[char1] == 0)
                        {
                            charCounts.Remove(char1);
                        }
                    }
                    else
                    {
                        charCounts.Add(char1, 1);
                    }

                    if (charCounts.ContainsKey(char2))
                    {
                        if (--charCounts[char2] == 0)
                        {
                            charCounts.Remove(char2);
                        }
                    }
                    else
                    {
                        charCounts.Add(char2, -1);
                    }
                }
            }

            return charCounts.Count == 0;
        }

        private static string Sanitize(string word)
        {
            return word.Replace(" ", "");
        }
    }
}
