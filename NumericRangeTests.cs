using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ThirtyFour
{
    [TestClass]
    public class NumericRangeTests
    {
        [TestMethod]
        public void Empty()
        {
            var numbers = new int[] { };
            var ranges = numbers.ToRangesString();

            Assert.AreEqual(string.Empty, ranges);
        }
        [TestMethod]
        public void Number()
        {
            var numbers = new int[] { 34 };
            var ranges = numbers.ToRangesString();

            Assert.AreEqual("34", ranges);
        }

        [TestMethod]
        public void Range()
        {
            var numbers = new int[] { 33, 34, 35 };
            var ranges = numbers.ToRangesString();

            Assert.AreEqual("33-35", ranges);
        }

        [TestMethod]
        public void NegativeRange()
        {
            var numbers = new int[] { -36, -35, -34 };
            var ranges = numbers.ToRangesString();

            Assert.AreEqual("-36--34", ranges);
        }

        [TestMethod]
        public void NegativeToPositiveRange()
        {
            var numbers = new int[] { -1, 0, 1 };
            var ranges = numbers.ToRangesString();

            Assert.AreEqual("-1-1", ranges);
        }

        [TestMethod]
        public void NumberNumberNumberNumber()
        {
            var numbers = new int[] { 1, 3, 5, 7 };
            var ranges = numbers.ToRangesString();

            Assert.AreEqual("1,3,5,7", ranges);
        }

        [TestMethod]
        public void NumberRangeNumber()
        {
            var numbers = new int[] { 1, 3, 4, 5, 7 };
            var ranges = numbers.ToRangesString();

            Assert.AreEqual("1,3-5,7", ranges);
        }

        [TestMethod]
        public void RangeNumberRange()
        {
            var numbers = new int[] { 1, 2, 3, 5, 7, 8, 9 };
            var ranges = numbers.ToRangesString();

            Assert.AreEqual("1-3,5,7-9", ranges);
        }

        [TestMethod]
        public void RangeRangeRange()
        {
            var numbers = new int[] { 34, 35, 36, 38, 39, 40, 42, 43 };
            var ranges = numbers.ToRangesString();

            Assert.AreEqual("34-36,38-40,42-43", ranges);
        }
    }
}
