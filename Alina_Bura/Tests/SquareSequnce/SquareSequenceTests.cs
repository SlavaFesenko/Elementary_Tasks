using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SquareSequence_7;

namespace Tests
{
    //[TestInitialize] - execute method before each test

    [TestClass]
    public class SquareSequenceTests
    {
        [TestMethod]
        public void GetSequence_Positive_Success()
        {
            List<int> numbers = new List<int>() { 1, 5, 10 };

            List<IEnumerable<int>> actualResults = new List<IEnumerable<int>>();
            List<IEnumerable<int>> expectedResults = new List<IEnumerable<int>>();

            expectedResults.Add(new List<int> { 0 });
            expectedResults.Add(new List<int> { 0, 1, 2 });
            expectedResults.Add(new List<int> { 0, 1, 2, 3 });

            for (int i = 0; i < numbers.Count; i++)
            {
                actualResults.Add(new SquareSequence(numbers[i]).GetSequence());
            }

            for (int i = 0; i < numbers.Count; i++)
            {
                CollectionAssert.AreEqual(expectedResults[0].ToList(), actualResults[0].ToList());
            }
        }


        [TestMethod]
        public void GetSequence_Zero_ArgumentException()
        {
            int number = 0; 

            Assert.ThrowsException<ArgumentException>(() => new SquareSequence(number).GetSequence());
        }

        [TestMethod]
        public void TestGetSequence_Negative_ArgumentException()
        {
            List<int> numbers = new List<int>() { -1, -5, -10 };
           
            for (int i = 0; i < numbers.Count; i++)
            {
                Assert.ThrowsException<ArgumentException>(() => new SquareSequence(numbers[i]).GetSequence());
            }
        }

        [TestMethod]
        public void GetStringResult_NotEmptySequence_CorrectString()
        {
            List<int> getSequenceResult = new List<int>() { 0, 1, 2, 3 };
            string expectedResult = "0, 1, 2, 3";

            string actualResult = SquareSequence.GetStringResult(getSequenceResult);
            
            Assert.AreEqual(actualResult, expectedResult);
        }

        [TestMethod]
        public void GetStringResult_Null_ArgumentNullException()
        {
            Assert.ThrowsException<ArgumentNullException>(() => SquareSequence.GetStringResult(null));            
        }

        [TestMethod]
        public void GetStringResult_Empty_ArgumentNullException()
        {
            List<int> getSequenceResult = new List<int>();
            string expectedResult = string.Empty;
           
            string actualResult = SquareSequence.GetStringResult(getSequenceResult);

            Assert.AreEqual(actualResult, expectedResult);
        }
    }
}
