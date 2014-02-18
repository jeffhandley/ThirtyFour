using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ThirtyFour
{
    [TestClass]
    public class ParenMatchingTests
    {
        [TestMethod]
        public void NoParensHasNoUnclosedParens()
        {
            var noParens = "This string has no Parens.";
            Assert.IsFalse(noParens.HasMismatchedParens());
        }

        [TestMethod]
        public void NoParensHasNoPairs()
        {
            var noParens = "This string has no Parens.";
            Assert.AreEqual(0, noParens.GetParenPairCount());
        }

        [TestMethod]
        public void SinglePairHasNoUnclosedParens()
        {
            var openClose = "This string has (one pair) of Parens.";
            Assert.IsFalse(openClose.HasMismatchedParens());
        }

        [TestMethod]
        public void OpenCloseHasOnePair()
        {
            var openClose = "This string has (one pair) of Parens.";
            Assert.AreEqual(1, openClose.GetParenPairCount());
        }

        [TestMethod]
        public void OpenCloseOpenCloseHasNoUnclosedParens()
        {
            var openCloseOpenClose = "This (string) has (two pairs) of Parens.";
            Assert.IsFalse(openCloseOpenClose.HasMismatchedParens());
        }

        [TestMethod]
        public void OpenCloseOpenCloseHasTwoPairs()
        {
            var openCloseOpenClose = "This (string) has (two pairs) of Parens.";
            Assert.AreEqual(2, openCloseOpenClose.GetParenPairCount());
        }

        [TestMethod]
        public void OpenHasUnclosedPair()
        {
            var open = "This string has (a single Paren.";
            Assert.IsTrue(open.HasMismatchedParens());
        }

        [TestMethod]
        public void OpenHasNoPairs()
        {
            var open = "This string has (a single Paren.";
            Assert.AreEqual(0, open.GetParenPairCount());
        }

        [TestMethod]
        public void ThreeParensHasUnclosedPair()
        {
            var openCloseOpen = "This (string) has (three Parens.";
            Assert.IsTrue(openCloseOpen.HasMismatchedParens());
        }

        [TestMethod]
        public void OpenCloseOpenHasOnePair()
        {
            var openCloseOpen = "This (string) has (three Parens.";
            Assert.AreEqual(1, openCloseOpen.GetParenPairCount());            
        }

        [TestMethod]
        public void CloseCloseOpenHasTwoUnopened()
        {
            var closeCloseOpen = "This )) string ( has two unopened Parens.";
            Assert.AreEqual(2, closeCloseOpen.GetUnopenedParenCount());
        }

        [TestMethod]
        public void OpenOpenCloseCloseHasNoUnclosedPairs()
        {
            var openOpenCloseClose = "This (string has (two) pairs).";
            Assert.IsFalse(openOpenCloseClose.HasMismatchedParens());
        }

        [TestMethod]
        public void OpenOpenCloseCloseHasTwoPairs()
        {
            var openOpenCloseClose = "This (string has (two) pairs).";
            Assert.AreEqual(2, openOpenCloseClose.GetParenPairCount());
        }
    }
}
