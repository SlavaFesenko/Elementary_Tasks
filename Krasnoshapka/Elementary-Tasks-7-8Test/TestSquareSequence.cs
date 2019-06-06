using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Elementary_Tasks_7_8;


namespace Elementary_Tasks_7_8Test
{
    [TestClass]
    public class TestSquareSequence
    {
        [TestMethod]
        [DataRow(1, 10, 1, 10)]
        [DataRow(5, 20, 5, 20)]
        public void TestFibonachiSequncesCorrectInitialize(int leftBorder, int rightBorder, int expectedLeftBorder, int expectedRightBorder)
        {
           FibonacciSequence sequence = FibonacciSequence.FibonacciInitialize(leftBorder, rightBorder);
     
            Assert.IsTrue((expectedLeftBorder == sequence.LeftBorder)
                && (expectedRightBorder == sequence.RightBorder));
        }

        [TestMethod]
        [DataRow(5, 1, 5)]
        [DataRow(50, 1, 50)]

        public void LessThanNSequncesCorrectInitialize(int rightBorder, int expectedLeftBorder, int expectedRightBorder)
        {
            SquareSequence sequence = SquareSequence.SquareInitialize(rightBorder);

            Assert.IsTrue((expectedLeftBorder == sequence.LeftBorder)
            && (expectedRightBorder == sequence.RightBorder));
        }

       
        [TestMethod]
        [DataRow(1, 13, new int[] { 1, 1, 2, 3, 5, 8, 13 })]
        [DataRow(7, 21, new int[] { 8, 13, 21 })]


        public void FibbonachiNumberRange_Correct(int leftBorder,
            int rightBorder, int[] expected)
        {
            List<int> real = new List<int>();

            FibonacciSequence sequence = FibonacciSequence.FibonacciInitialize(leftBorder, rightBorder);
            foreach (int item in sequence.GetSequence())
            {
                real.Add(item);
            }

            CollectionAssert.AreEqual(expected, real.ToArray());
        }

        [TestMethod]
        [DataRow(13, new int[] { 1, 2, 3 })]
        [DataRow(21, new int[] { 1, 2, 3, 4 })]
        [DataRow(5, new int[] { 1, 2 })]

        public void LessThanNNumberRange_Correct(int rightBorder, int[] expected)
        {
           
            List<int> real = new List<int>();

            SquareSequence sequence = SquareSequence.SquareInitialize(rightBorder);
            foreach (int item in sequence.GetSequence())
            {
                real.Add(item);
            }

            CollectionAssert.AreEqual(expected, real.ToArray());
        }

        [TestMethod]

        [DataRow (-3, 1)]
        [DataRow (10, 1)]

        public void TestArgumentExceptionThrow(int leftBorder, int rightBorder)
        {
            Assert.ThrowsException<ArgumentException>(() => FibonacciSequence.FibonacciInitialize(leftBorder, rightBorder));
            Assert.ThrowsException<ArgumentException>(() => FibonacciSequence.FibonacciInitialize(leftBorder, rightBorder));
        }

  
    }
}
