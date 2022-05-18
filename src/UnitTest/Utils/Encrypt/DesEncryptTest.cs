using Microsoft.VisualStudio.TestTools.UnitTesting;
using OneSteps.Utils.Encrypt;
using System;

namespace UnitTest.Utils.Encrypt
{
    [TestClass]
    public class DesEncryptTest
    {
        [TestMethod]
        public void TestMethod()
        {
            string inputStr = "helle word";

            string outputStr = DesEncrypt.Encrypt(inputStr);

            Assert.AreNotEqual(inputStr, outputStr);

            string decStr = DesEncrypt.Decrypt(outputStr);

            Assert.AreEqual(inputStr, decStr);

        }
    }
}
