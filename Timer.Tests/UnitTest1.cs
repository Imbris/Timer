using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using timer;

namespace Timer.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual(Form1.convert_to_int("4", ",блаблабла это неважно"), 4);
        }
    }
}
