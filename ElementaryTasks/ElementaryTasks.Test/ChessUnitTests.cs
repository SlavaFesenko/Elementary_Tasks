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
        public ChessUnitTests()
        {
            //
            // TODO: добавьте здесь логику конструктора
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Получает или устанавливает контекст теста, в котором предоставляются
        ///сведения о текущем тестовом запуске и обеспечивается его функциональность.
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

        #region Дополнительные атрибуты тестирования
        //
        // При написании тестов можно использовать следующие дополнительные атрибуты:
        //
        // ClassInitialize используется для выполнения кода до запуска первого теста в классе
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // ClassCleanup используется для выполнения кода после завершения работы всех тестов в классе
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // TestInitialize используется для выполнения кода перед запуском каждого теста 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // TestCleanup используется для выполнения кода после завершения каждого теста
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void CorrectColloringCell()
        {
            ChessBoardColor expectedColor = ChessBoardColor.White;
            Cell testCell = new Cell(0,0);
            Assert.AreEqual(expectedColor, testCell.CellColor);
        }

        [TestMethod]
        public void CorrectBuildingTable()
        {
            Board testBoard = new Board(1, 2);
            for (int i = 0; i < 1; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    if (j % 2 == 0)
                        Assert.AreEqual(ChessBoardColor.White, testBoard.CellsTable[i,j].CellColor);
                    else
                        Assert.AreEqual(ChessBoardColor.Black, testBoard.CellsTable[i, j].CellColor);
                }
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ThrowingNullArgumentException()
        {
            string[] args = { };
            Validator.Validate(args);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ThrowingArgumentExceptionLess0()
        {
            string[] args = {"-1", "8"};
            Validator.Validate(args);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ThrowingArgumentExceptionMore30()
        {
            string[] args = { "31", "8" };
            Validator.Validate(args);
        }

        [TestMethod]
        public void ThrowingExceptionCantParse()
        {
            try
            {
                string[] args = { "string", "8" };
                Validator.Validate(args);
            }
            catch (FormatException ae)
            {
                Assert.AreEqual("Can't parse rows or colomns", ae.Message);
            }
        }

        [TestMethod]
        public void ThrowingExceptionMoreThanTwoArgs()
        {
            try
            {
                string[] args = { "8", "8", "8" };
                Validator.Validate(args);
            }
            catch (FormatException ae)
            {
                Assert.AreEqual("Unsuccessful format. You must write only two arguments!", ae.Message);
            }
        }      
    }
}
