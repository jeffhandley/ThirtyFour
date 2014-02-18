using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ThirtyFour
{
    [TestClass]
    public class ClosedQuotesTests
    {
        [TestMethod]
        public void NoQuotesHasNoUnclosedQuotes()
        {
            var noquotes = "This string has no quotes.";
            Assert.IsFalse(noquotes.HasUnclosedQuotes());
        }

        [TestMethod]
        public void NoQuotesHasNoPairs()
        {
            var noquotes = "This string has no quotes.";
            Assert.AreEqual(0, noquotes.GetQuotePairCount());
        }

        [TestMethod]
        public void SinglePairHasNoUnclosedQuotes()
        {
            var singlepair = "This string has \"one pair\" of quotes.";
            Assert.IsFalse(singlepair.HasUnclosedQuotes());
        }

        [TestMethod]
        public void SinglePairHasOnePair()
        {
            var singlepair = "This string has \"one pair\" of quotes.";
            Assert.AreEqual(1, singlepair.GetQuotePairCount());
        }

        [TestMethod]
        public void DoublePairHasNoUnclosedQuotes()
        {
            var doublepair = "This \"string\" has \"two pairs\" of quotes.";
            Assert.IsFalse(doublepair.HasUnclosedQuotes());
        }

        [TestMethod]
        public void DoublePairHasTwoPairs()
        {
            var doublepair = "This \"string\" has \"two pairs\" of quotes.";
            Assert.AreEqual(2, doublepair.GetQuotePairCount());
        }

        [TestMethod]
        public void SingleQuoteHasUnclosedPair()
        {
            var singlequote = "This string has \"a single quote.";
            Assert.IsTrue(singlequote.HasUnclosedQuotes());
        }

        [TestMethod]
        public void SingleQuoteHasNoPairs()
        {
            var singlequote = "This string has \"a single quote.";
            Assert.AreEqual(0, singlequote.GetQuotePairCount());
        }

        [TestMethod]
        public void ThreeQuotesHasUnclosedPair()
        {
            var three = "This \"string\" has \"three quotes.";
            Assert.IsTrue(three.HasUnclosedQuotes());
        }

        [TestMethod]
        public void ThreeQuotesHasOnePair()
        {
            var three = "This \"string\" has \"three quotes.";
            Assert.AreEqual(1, three.GetQuotePairCount());            
        }
    }
}
