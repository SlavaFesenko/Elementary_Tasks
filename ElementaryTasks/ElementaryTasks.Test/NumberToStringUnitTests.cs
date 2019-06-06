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

        #region Converter Tests

        [TestMethod]
        public void CorrectConverting()
        {
            string expectedString = "one hundred";
            int actualNumber = 100;
            string actualString = Converter.Convert(actualNumber);
            string testFailMessage = "Test was failed on converting 100";

            Assert.AreEqual(expectedString, actualString, testFailMessage);
        }

        [TestMethod]
        public void CorrectConvertingWithMinus()
        {
            string expectedString = "minus one hundred";
            int actualNumber = -100;
            string actualString = Converter.Convert(actualNumber);
            string testFailMessage = "Test was failed on converting -100";

            Assert.AreEqual(expectedString, actualString, testFailMessage);
        }

        [TestMethod]
        public void CorrectConvertingWithZero()
        {
            string expectedString = "zero";
            int actualNumber = 0;
            string actualString = Converter.Convert(actualNumber);
            string testFailMessage = "Test was failed on converting 0";

            Assert.AreEqual(expectedString, actualString, testFailMessage);
        }

        #endregion

        #region Validator Tests

        [TestMethod]
        public void CorrectValidation()
        {
            string[] actualArgs = { "1000" };
            int expectedNumber = 1000;
            int actualNumber = Validator.Validate(actualArgs);
            string testFailMessage = "Test was failed on validating 1000";

            Assert.AreEqual(expectedNumber, actualNumber, testFailMessage);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "Argument null exception wasn't thrown")]
        public void ThrowingNullArgumentException()
        {
            string[] actualArgs = { };
            int actualNumber = Validator.Validate(actualArgs);         
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Argument exception wasn't thrown")]
        public void ThrowingArgumentException()
        {
            string[] actualArgs = {"100", "200" };
            int actualNumber = Validator.Validate(actualArgs);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException), "Format exception(user input string) wasn't thrown")]
        public void ThrowingFormatException()
        {
            string[] actualArgs = { "string" };
            int actualNumber = Validator.Validate(actualArgs);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException), "Format exception(user input more than 10 symbolth) wasn't thrown")]
        public void ThrowingExceptionMoreThanTen()
        {           
            string[] actualArgs = { "12345678910" };
            int actualNumber = Validator.Validate(actualArgs);      
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException), "Format exception(number starts with zero) wasn't thrown")]
        public void ThrowingExceptionStartWithZero()
        {
            string[] actualArgs = { "012345678" };
            int actualNumber = Validator.Validate(actualArgs);   
        }

        #endregion
    }
}
