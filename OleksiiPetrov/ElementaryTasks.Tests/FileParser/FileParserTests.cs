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
        string _path;

        [TestInitialize]
        public void TestInitialize()
        {
            _path = "test.txt";
            using (File.Create(_path)) { }
            File.WriteAllText(_path, "One, Two, Three\r\n Two, Three\r\n");
            _parser = new Parser(_path);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            if (File.Exists(_path))
                File.Delete(_path);
            _path = string.Empty;

        }

        [TestMethod]
        public void ParserGetCountEntries_ONENUMBERfindInPath_Return0()
        {
            // Arrange
            string find = "ONENUMBER";
            int expected = 0;

            // Act
            int actual = _parser.GetCountEntries(find);

            // Assert
            Assert.AreEqual(expected, actual);

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
            string actual = File.ReadAllText(_path);

            //Assert
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
        [ExpectedException(typeof(ArgumentException))]
        public void ParserReplaceAll_NUMBERReplace1_ArgumentException()
        {
            string searching = "NUMBER";
            string replacing = "1";

            _parser.ReplaceAll(searching, replacing);
        }
    }
}
