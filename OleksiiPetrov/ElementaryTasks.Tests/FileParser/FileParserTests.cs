using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task4FileParser;

namespace ElementaryTasks.tests.FileParser
{
    [TestClass]
    public class FileParserTests
    {
        Parser parser;
        
        private static void CreateFile(string path)
        {
            if (File.Exists(path))
                File.Delete(path);
            using (File.Create(path)) { }
        }

        [TestInitialize]
        public void TestInitialize()
        {
            
        }

        [TestMethod]
        public void ParserGetCountEntries_ONENUMBERfindInPath_Return0()
        {
            // Arrange
            string path = "test.txt";
            string find = "ONENUMBER";
            int expected = 0;

            // Act
            CreateFile(path);
            File.WriteAllText(path, "One, Two, Three\r\n Two, Three\r\n");

            parser = new Parser(path);
            int actual = parser.GetCountEntries(find);

            // Assert
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void ParserReplaceAll_TwoReplace2_Replaced()
        {
            //Arrange
            string path = "test.txt";
            string expected = "One, 2, Three\r\n 2, Three\r\n";// TODO: ToSetup            //diapdown

            CreateFile(path);
            File.WriteAllText(path, expected);
            

            //Act
            parser = new Parser(path);
            parser.ReplaceAll("Two", "2");
            string actual = File.ReadAllText(path);

            //Assert
            Assert.AreEqual(expected, actual);
        }
        //TODO: +ожидаем любой ексепшн

        //[ExpectedException(typeof(Exception))]
        //[TestMethod]
        //public void ParserReplaceAll_WrongArgs_Exceptions()
        //{
        //    //Arrange

        //    ////Act

        //    //Assert.ThrowsException
        //    //Assert.AreEqual(expected, actual);
        //}

    }
}
