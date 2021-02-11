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

        #region EqualTrue

        [TestMethod]
        public void GetSequenceCollection_0and41231_ReturnExpectedEqualTrue()
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

        #endregion

        #region Exceptions

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ChechInputModel_2string_ReturnException()
        {
            string[] args = "asd a2".Split();

            InputModel model = new InputModel(args);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ChechInputNull_NullArguments_ReturnException()
        {
            string[] args = "".Split();

            bool isNoExeption = Task8FibonacciNumbers.Validator.IsValid(args);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ChechInputLessThanZero_Min1AndMin5_ReturnException()
        {
            string[] args = "-1 -5".Split();

            bool isNoExeption = Task8FibonacciNumbers.Validator.IsValid(args);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ChechInputLessThanZero_Min1And5_ReturnException()
        {
            string[] args = "-1 5".Split();

            bool isNoExeption = Task8FibonacciNumbers.Validator.IsValid(args);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ChechInputLeftNumberLargerFight_5And1_ReturnException()
        {
            string[] args = "5 1".Split();

            bool isNoExeption = Task8FibonacciNumbers.Validator.IsValid(args);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ChechInput3Args_1And2And3_ReturnException()
        {
            string[] args = "1 2 3".Split();

            bool isNoExeption = Task8FibonacciNumbers.Validator.IsValid(args);
        }

        #endregion

    }
}
