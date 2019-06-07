using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Chess;

namespace ElementaryTasks.Test
{
    /// <summary>
    /// Сводное описание для ChessUnitTests
    /// </summary>
    [TestClass]
    public class ChessUnitTests
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

        #region Building Board and Coloring Cell Tests

        [TestMethod]
        public void CorrectColoringCell()
        {            
            Cell testCell = new Cell(0,0);
            ChessBoardColor actualColor = testCell.CellColor;
            ChessBoardColor expectedColor = ChessBoardColor.White;

            string testFailMessage = "Tests was failed on coloring cell";

            Assert.AreEqual(expectedColor, actualColor, testFailMessage);
        }

        [TestMethod]
        public void CorrectBuildingTable()
        {
            Board testBoard = new Board(1, 2);
            ChessBoardColor actualColor = testBoard.CellsTable[0, 0].CellColor;
            ChessBoardColor expectedColor = ChessBoardColor.White;

            string testFailMessage = "Tests was failed on building board";

            Assert.AreEqual(expectedColor, actualColor, testFailMessage);
        }

        #endregion

        #region Exception Tests

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "Argument null exception wasn't thrown")]
        public void ThrowingNullArgumentException()
        {
            string[] actualArgs = { };
            Validator.Validate(actualArgs);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Argument exception(for less than zero argument) wasn't thrown")]
        public void ThrowingArgumentExceptionLess0()
        {
            string[] actualArgs = {"-1", "8"};
            Validator.Validate(actualArgs);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Argument exception(for equal zero argument) wasn't thrown")]
        public void ThrowingArgumentExceptionEqual0()
        {
            string[] actualArgs = { "0", "8" };
            Validator.Validate(actualArgs);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Argument exception(for greater than 30 argument) wasn't thrown")]
        public void ThrowingArgumentExceptionMore30()
        {
            string[] actualArgs = { "31", "8" };
            Validator.Validate(actualArgs);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException), "Format exception(user input string) wasn't thrown")]
        public void ThrowingExceptionCantParse()
        {
            string[] actualArgs = { "string", "8" };
            Validator.Validate(actualArgs);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException), "Format exception(user input more than 2 arguments) wasn't thrown")]
        public void ThrowingExceptionMoreThanTwoactualArgs()
        {
            string[] actualArgs = { "8", "8", "8" };
            Validator.Validate(actualArgs);          
        }

        #endregion
    }
}
