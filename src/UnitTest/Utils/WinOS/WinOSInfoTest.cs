using Microsoft.VisualStudio.TestTools.UnitTesting;
using OneSteps.Utils.WinOS;
using System;

namespace UnitTest.Utils.WinOS
{
    [TestClass]
    public class WinOSInfoTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            var s = WinOSInfo.MachineName();
            Assert.IsNotNull(s);
        }
    }
}
