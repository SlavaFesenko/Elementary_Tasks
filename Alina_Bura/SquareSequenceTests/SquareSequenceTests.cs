using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SquareSequence_7;

namespace SquareSequenceTests
{
    //[TestInitialize] - execute method before each test

    [TestClass]
    public class SquareSequenceTests
    {
        [TestMethod]
        public void TestGetSequence_InputPositive_ReturnOK()
        {
            // arrange 
            List<int> numbers = new List<int>() { 1, 5, 10 };

            List<IEnumerable<int>> actualResults = new List<IEnumerable<int>>();
            List<IEnumerable<int>> expectedResults = new List<IEnumerable<int>>();

            expectedResults.Add(new List<int> { 0 });
            expectedResults.Add(new List<int> { 0, 1, 2 });
            expectedResults.Add(new List<int> { 0, 1, 2, 3 });

            //act
            for (int i = 0; i < numbers.Count; i++)
            {
                actualResults.Add(new SquareSequence(numbers[i]).GetSequence());
            }

            //assert
            for (int i = 0; i < numbers.Count; i++)
            {
                CollectionAssert.AreEqual(expectedResults[0].ToList(), actualResults[0].ToList());
            }
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestGetSequence_Input0_ReturnError()
        {
            // arrange 
            int number = 0;
            ISequence sequence = new SquareSequence(number);

            //act
            IEnumerable<int> result = sequence.GetSequence();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestGetSequence_InputNegative_ReturnError()
        {
            List<int> numbers = new List<int>() { -1, -5, -10 };

            List<IEnumerable<int>> actualResults = new List<IEnumerable<int>>();
            
            //act
            for (int i = 0; i < numbers.Count; i++)
            {
                actualResults.Add(new SquareSequence(numbers[i]).GetSequence());
            }
        }

        [TestMethod]
        public void TestGetStringResult_Input10_ReturnStr0123()
        {
            // arrange 
            int number = 10;
            List<int> getSequenceResult = new List<int>() { 0, 1, 2, 3 };
            ISequence sequence = new SquareSequence(number);
            string expectedResult = "0, 1, 2, 3";

            //act
            string actualResult = sequence.GetStringResult(getSequenceResult);
            
            //assert
            Assert.AreEqual(actualResult, expectedResult);
        }
    }
}
