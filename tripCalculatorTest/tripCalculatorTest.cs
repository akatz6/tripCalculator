using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using tripCalculator;

namespace tripCalculatorTest
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class tripCalculatorTest
    {
        public tripCalculatorTest()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void TestCorrectNameWorks()
        {
            Verification ver = new Verification();
            Assert.AreEqual(ver.VerifyName("Aaron"), true, "Aaron is correct name");
            
        }

        [TestMethod]
        public void TestIncorrectSpellingReturnsFalse()
        {
            Verification ver = new Verification();
            Assert.AreEqual(ver.VerifyName("aaron"), false, "aaron is incorrect name");
        }

        [TestMethod]
        public void TestNameWithNumbersReturnsFalse()
        {
            Verification ver = new Verification();
            Assert.AreEqual(ver.VerifyName("Aaron5"), false, "Aaron5 is incorrect name");
        }

        [TestMethod]
        public void TestBlankNameReturnsFalse()
        {
            Verification ver = new Verification();
            Assert.AreEqual(ver.VerifyName(""), false, "no name is incorrect name");
        }

        [TestMethod]
        public void TestDollarAmountBlankReturnsFalse()
        {
            Verification ver = new Verification();
            Assert.AreEqual(ver.DollarAmount(""), false, "no dollar amount is incorrect dollar amount");
        }

        [TestMethod]
        public void TestDollarAmountNameReturnsFalse()
        {
            Verification ver = new Verification();
            Assert.AreEqual(ver.DollarAmount("Aaron"), false, "Aaron dollar amount is incorrect dollar amount");
        }

        [TestMethod]
        public void TestDollarAmountNegativeNumberReturnsFalse()
        {
            Verification ver = new Verification();
            Assert.AreEqual(ver.DollarAmount("-.01"), false, "-.01 dollar amount is incorrect dollar amount");
        }

        [TestMethod]
        public void TestDollarAmountZeroNumberReturnsTrue()
        {
            Verification ver = new Verification();
            Assert.AreEqual(ver.DollarAmount(".00"), true, ".00 dollar amount is correct dollar amount");
        }


        [TestMethod]
        public void TestDollarAmountNintyNiveCentsReturnsTrue()
        {
            Verification ver = new Verification();
            Assert.AreEqual(ver.DollarAmount(".99"), true, ".99 dollar amount is correct dollar amount");
        }

        [TestMethod]
        public void TestDollarAmountOneDollarReturnsTrue()
        {
            Verification ver = new Verification();
            Assert.AreEqual(ver.DollarAmount("1.00"), true, "1.00 dollar amount is correct dollar amount");
        }

        [TestMethod]
        public void TestDollarAmountOneDollarAndOneCentReturnsTrue()
        {
            Verification ver = new Verification();
            Assert.AreEqual(ver.DollarAmount("1.01"), true, "1.01 dollar amount is correct dollar amount");
        }

        [TestMethod]
        public void TestDollarAmountCorrectNumbertReturnsTrue()
        {
            Verification ver = new Verification();
            Assert.AreEqual(ver.DollarAmount("51.55"), true, "51.55 dollar amount is correct dollar amount");
        }

        [TestMethod]
        public void TestPerPersonReturnsCorrectAmount()
        {
            Verification ver = new Verification();
            Assert.AreEqual(ver.PerPerson(15.01, 15.01, 15.01), 15.01, 0.001,"15.01 returned per person");
        }

        [TestMethod]
        public void TestPerPersonReturnsCorrectAmountExpectedIsIncorrect()
        {
            Verification ver = new Verification();
            Assert.AreNotEqual(ver.PerPerson(15.01, 15.01, 15.01), 16.01, 0.001, "16.01 returned per person is not correct amount");
        }
    }
}
