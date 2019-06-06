using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task4FileParser;

namespace ElementaryTasks.tests.FileParser
{
    [TestClass]
    public class FileParserTests
    {
        Parser _parser;
        private static string _mainPath;
        private static string _testPath;

        #region Inits

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            _testPath = "test.txt";
            using (File.Create(_testPath)) { }
            _mainPath = "main.txt";
            using (File.Create(_mainPath)) { }
            File.WriteAllText(_mainPath, "One, Two, Three\r\n Two, Three\r\n");

        }

        [TestInitialize]
        public void TestInitialize()
        {
            File.Copy(_mainPath, _testPath, true);

            _parser = new Parser(_testPath);
        }

        [TestCleanup]
        public void TestCleanup()
        {
        }

        #endregion

        #region AreEquals

        [TestMethod]
        public void ParserGetCountEntries_ONENUMBERfindInPath_Return0()
        {
            string find = "ONENUMBER";
            int expected = 0;

            int actual = _parser.GetCountEntries(find);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetCountEntries_SearchThree_Return2()
        {
            // Arrange
            string searchingString = "Three";
            int expected = 2;

            // Act
            int real = _parser.GetCountEntries(searchingString);

            // Assert
            Assert.AreEqual(real, expected);
        }

        [TestMethod]
        public void ParserReplaceAll_TwoReplace2_Replaced()
        {
            //Arrange
            string searching = "Two";
            string replacing = "2";
            string expected = "One, 2, Three\r\n 2, Three\r\n";

            //Act
            _parser.ReplaceAll(searching, replacing);
            string actual = File.ReadAllText(_testPath);

            //Assert
            Assert.AreEqual(expected, actual);
        }
           
        #endregion


        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ParserReplaceAll_NUMBERReplace1_ArgumentException()
        {
            string searching = "NUMBER";
            string replacing = "1";

            _parser.ReplaceAll(searching, replacing);
        }

    }
}
