using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task8FibonacciNumbers;
using SharedLibrary;

namespace ElementaryTasks.tests.FibonacciNumbers
{
    [TestClass]
    public class FibonacciNumbers
    {
        Sequence sequence;
        
        [TestMethod]
        public void GetSequenceCollection_0and41231_ReturnEqualTrue()
        {
            string expected = "0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, 610, 987, 1597, 2584, 4181, 6765, 10946, 17711, 28657";

            sequence = new FibonacciSequence(0, 41231);
            
            string actual = sequence.GetStringSequence(sequence.GetSequenceCollection()).ToString();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetSequenceCollection_56667and122236_ReturnEqualTrue()
        {
            string expected = "75025, 121393";

            sequence = new FibonacciSequence(56667, 122236);

            string actual = sequence.GetStringSequence(sequence.GetSequenceCollection()).ToString();

            Assert.AreEqual(expected, actual);
        }
       
    }
}
