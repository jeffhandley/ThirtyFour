using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ThirtyFour
{
    [TestClass]
    public class RepeatedStringTests
    {
        [TestMethod]
        public void Null()
        {
            try
            {
                string input = null;
                input.LongestRepeatedString();
                Assert.Fail("Expected ArgumentNullException. None caught.");
            }
            catch (ArgumentNullException)
            {
                // Success
            }
            catch (Exception ex)
            {
                Assert.Fail(string.Format("ArgumentNullException expected.  Caught: {0}", ex.GetType()));
            }
        }

        [TestMethod]
        public void EmptyString()
        {
            try
            {
                string input = string.Empty;
                input.LongestRepeatedString();
                Assert.Fail("Expected ArgumentNullException. None caught.");
            }
            catch (ArgumentNullException)
            {
                // Success
            }
            catch (Exception ex)
            {
                Assert.Fail(string.Format("ArgumentNullException expected.  Caught: {0}", ex.GetType()));
            }
        }

        [TestMethod]
        public void x_yields_null()
        {
            string input = "x";
            string longest = input.LongestRepeatedString();

            Assert.IsNull(longest);
        }

        [TestMethod]
        public void xx_yields_x()
        {
            string input = "xx";
            string longest = input.LongestRepeatedString();

            Assert.AreEqual("x", longest);
        }

        [TestMethod]
        public void xxx_yields_x()
        {
            string input = "xxx";
            string longest = input.LongestRepeatedString();

            Assert.AreEqual("x", longest);
        }

        [TestMethod]
        public void xxy_yields_x()
        {
            string input = "xxy";
            string longest = input.LongestRepeatedString();

            Assert.AreEqual("x", longest);
        }

        [TestMethod]
        public void xxyy_yields_x()
        {
            string input = "xxyy";
            string longest = input.LongestRepeatedString();

            Assert.AreEqual("x", longest);
        }

        [TestMethod]
        public void xxyxx_yields_xx()
        {
            string input = "xxyxx";
            string longest = input.LongestRepeatedString();

            Assert.AreEqual("xx", longest);
        }

        [TestMethod]
        public void xyxyxy_yields_xy()
        {
            string input = "xyxyxy";
            string longest = input.LongestRepeatedString();

            Assert.AreEqual("xy", longest);
        }

        [TestMethod]
        public void xyxyxyxyxyxyxyx_yields_xyxyxyx()
        {
            string input = "xyxyxyxyxyxyxyx";
            string longest = input.LongestRepeatedString();

            Assert.AreEqual("xyxyxyx", longest);
        }
    }
}
