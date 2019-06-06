using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ElementaryTask7;


namespace ElementaryTask7Test
{
    [TestClass]
    public class TestSquareSequence
    {
        

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

       

  
    }
}
