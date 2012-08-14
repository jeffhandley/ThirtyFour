using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ThirtyFour
{
    /// <summary>
    /// Summary description for AnagramTests
    /// </summary>
    [TestClass]
    public class AnagramTests
    {
        [TestMethod]
        public void ReversedWordIsAnagram()
        {
            Assert.IsTrue(Anagram.AreWordsAnagrams("abcde", "edcba"));
        }

        [TestMethod]
        public void ShiftedWordIsAnagram()
        {
            Assert.IsTrue(Anagram.AreWordsAnagrams("abcde", "cdeba"));
        }

        [TestMethod]
        public void MixedWordIsAnagram()
        {
            Assert.IsTrue(Anagram.AreWordsAnagrams("abcde", "acebd"));
        }

        [TestMethod]
        public void ExtraLettersRuleItOut()
        {
            Assert.IsFalse(Anagram.AreWordsAnagrams("abcde", "abcdef"));
        }

        [TestMethod]
        public void MissingLettersRuleItOut()
        {
            Assert.IsFalse(Anagram.AreWordsAnagrams("abcde", "abcd"));
        }

        [TestMethod]
        public void ExtraLetterOccurrenceRulesItOut()
        {
            Assert.IsFalse(Anagram.AreWordsAnagrams("abcde", "abcdee"));
        }

        [TestMethod]
        public void MismatchIsNotAnAnagram()
        {
            Assert.IsFalse(Anagram.AreWordsAnagrams("abcde", "fghij"));
        }

        [TestMethod]
        public void CaseDoesNotMatter()
        {
            Assert.IsTrue(Anagram.AreWordsAnagrams("ABCDE", "abcde"));
        }

        [TestMethod]
        public void TwoWordsCanMatchTwoWords()
        {
            Assert.IsTrue(Anagram.AreWordsAnagrams("abcde fghij", "cdefghi jab"));
        }

        [TestMethod]
        public void TwoWordsCanMatchOneWord()
        {
            Assert.IsTrue(Anagram.AreWordsAnagrams("abcde fghij", "cdefghijab")); 
        }

        [TestMethod]
        public void NullDoesNotThrowForFirstWord()
        {
            Assert.IsFalse(Anagram.AreWordsAnagrams(null, "abcde"));
        }

        [TestMethod]
        public void NullDoesNotThrowForSecondWord()
        {
            Assert.IsFalse(Anagram.AreWordsAnagrams("abcde", null));
        }

        [TestMethod]
        public void EmptyWordsDoNotMatch()
        {
            Assert.IsFalse(Anagram.AreWordsAnagrams(string.Empty, string.Empty));
        }

        [TestMethod]
        public void NullsDoNotMatch()
        {
            Assert.IsFalse(Anagram.AreWordsAnagrams(null, null));
        }

        [TestMethod]
        public void SpacesDoNotMatch()
        {
            Assert.IsFalse(Anagram.AreWordsAnagrams(" ", " "));
        }
    }
}
