using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NumberToStringConvertor;

namespace ElementaryTasks.Test
{
    [TestClass]
    public class NumberToStringUnitTests
    {
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

        #region Tests

        [TestMethod]
        public void CorrectConverting()
        {
            string expectedString = "one hundred";
            string actualString = Converter.Convert(100);
            Assert.AreEqual(expectedString, actualString);
        }

        [TestMethod]
        public void CorrectConvertingWithMinus()
        {
            string expectedString = "minus one hundred";
            string actualString = Converter.Convert(-100);
            Assert.AreEqual(expectedString, actualString);
        }

        [TestMethod]
        public void CorrectValidation()
        {
            string[] args = { "1000" };
            int expectedNumber = 1000;
            int actualNumber = Validator.Validate(args);
            Assert.AreEqual(expectedNumber, actualNumber);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ThrowingNullArgumentException()
        {
            string[] args = { };
            int number = Validator.Validate(args);         
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ThrowingArgumentException()
        {
            string[] args = {"100", "200" };
            int number = Validator.Validate(args);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void ThrowingFormatException()
        {
            string[] args = { "string" };
            int number = Validator.Validate(args);
        }

        [TestMethod]
        public void ThrowingExceptionMoreThanTen()
        {           
            try
            {
                string[] args = { "12345678910" };
                int number = Validator.Validate(args);
                Assert.Fail("An exception should have been thrown");
            }
            catch (FormatException ae)
            {
                Assert.AreEqual("Unseccessful format! (May be more than 10 symbols)", ae.Message);
            }            
        }

        [TestMethod]
        public void ThrowingExceptionStartWithZero()
        {
            try
            {
                string[] args = { "012345678" };
                int number = Validator.Validate(args);
                Assert.Fail("An exception should have been thrown");
            }
            catch (FormatException ae)
            {
                Assert.AreEqual("Unseccessful format! (Number couldn't start with 0)", ae.Message);
            }
        }

        #endregion
    }
}
