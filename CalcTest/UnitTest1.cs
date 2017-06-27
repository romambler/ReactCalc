using System;
using RectCalc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalcTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestSum()
        {
            var c = new Calc();
            var x = c.Sum(1, 2);
            Assert.AreEqual(x, 3);
        }
        [TestMethod]
        public void TestDiv()
        {
            var c = new Calc();
            var x = c.Div(6, 2);
            Assert.AreEqual(x, 3);
        }
        [TestMethod]
        public void TestSqrt()
        {
            var c = new Calc();
            var x = c.Sqrt(4);
            Assert.AreEqual(x, 2);
        }
    }
}
