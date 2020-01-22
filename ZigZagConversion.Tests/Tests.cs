using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ZigZagConversion.Tests
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        [DataRow("PAYPALISHIRING", 3, "PAHNAPLSIIGYIR")]
        [DataRow("ABCD", 2, "ACBD")]
        public void Test(string s, int numRows, string expected)
        {
            var sut = new Solution();
            var result = sut.Convert(s, numRows);
            Assert.AreEqual(expected, result);
        }
    }
}
