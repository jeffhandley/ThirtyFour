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

            if (string.IsNullOrEmpty(word1) || string.IsNullOrEmpty(word2))
            {
                return false;
            }

            if (word1.Length != word2.Length)
            {
                return false;
            }

            var word1chars = new Dictionary<char, int>();
            var word2chars = new Dictionary<char, int>();

            for (int x = 0; x < word1.Length; ++x)
            {
                CountCharacter(word1, word1chars, x);
                CountCharacter(word2, word2chars, x);
            }

            return DictionariesEqual(word1chars, word2chars);
        }

        private static bool DictionariesEqual(Dictionary<char, int> word1chars, Dictionary<char, int> word2chars)
        {
            if (word1chars.Keys.Count != word2chars.Keys.Count)
            {
                return false;
            }

            foreach (char key in word1chars.Keys)
            {
                if (!word2chars.ContainsKey(key) || word2chars[key] != word1chars[key])
                {
                    return false;
                }
            }

            return true;
        }

        private static void CountCharacter(string word, Dictionary<char, int> wordchars, int x)
        {
            var wordchar = word[x];

            if (wordchars.ContainsKey(wordchar))
            {
                ++wordchars[wordchar];
            }
            else
            {
                wordchars.Add(wordchar, 1);
            }
        }

        private static string Sanitize(string word)
        {
            return word.ToLowerInvariant().Replace(" ", "");
        }
    }
}
