using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task4FileParser;

namespace ElementaryTasks.tests.FileParser
{
    [TestClass]
    public class FileParserTests
    {
        [TestMethod]
        public void ParserGetCountEntries_ONENUMBERfindInPath_Return0()
        {
            // Arrange
            string path = "test2.txt";
            string find = "ONENUMBER";
            int expected = 0;

            // Act
            if (File.Exists(path))
                File.Delete(path);
            using (File.Create(path)) { }
            File.WriteAllText(path, "One, Two, Three\r\n Two, Three\r\n");

            Parser parser = new Parser(path);
            int actual = parser.GetCountEntries(find);

            // Assert
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void ParserReplaceAll_TwoReplace2_Replaced()
        {
            //Arrange
            string path = "test.txt";
            if (File.Exists(path))// TODO: ToSetup            //diapdown
                File.Delete(path);
            using (File.Create(path)) { }
            File.WriteAllText(path, "One, Two, Three\r\n Two, Three\r\n");
            
            string expected = "One, 2, Three\r\n 2, Three\r\n";

            //Act
            Parser parser = new Parser(path);
            parser.ReplaceAll("Two", "2");

            //Assert
            string actual = File.ReadAllText(path);
            Assert.AreEqual(expected, actual);
        }
        //cr file -> one -> replace two -> Check replace. +checkException + checkReturn0->returnExValue0
        //TODO: +ожидаем любой ексепшн

    }
}
