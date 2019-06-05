using CommonThings.AbstractClasses;
using NUnit.Framework;
using Task8_FibonacciOrder;


namespace TestForTasks
{
    [TestFixture]
    class RangeClassTesting
    {
        private Range _range = null;

        [SetUp]
        public void Setup()
        {
            _range = new Borders(null);
        }

        [TestCase]
        public void IsTrueLowAndUpBorderIfBiggerParamFirst()
        {
            //arrange
            int paramSmaller = 100;
            int paramBigger = 200;
            (int, int) forOut = (paramSmaller, paramBigger);

            //act
            var result = _range.FindLowAndUpBorder(paramBigger, paramSmaller);

            //assert
            Assert.AreEqual(forOut, result);
        }

        [TestCase]
        public void IsTrueLowAndUpBorderIfSmallerParamFirst()
        {
            //arrange
            int paramSmaller = 100;
            int paramBigger = 200;
            (int, int) forOut = (paramSmaller, paramBigger);

            //act
            var result = _range.FindLowAndUpBorder(paramSmaller, paramBigger);

            //assert
            Assert.AreEqual(forOut, result);
        }

        [TestCase]
        public void IsTrueLowAndUpBorderAreEqual()
        {
            //arrange
            int paramSmaller = 300;
            int paramBigger = paramSmaller;
            (int, int) forOut = (paramSmaller, paramBigger);

            //act
            var result = _range.FindLowAndUpBorder(paramSmaller, paramBigger);

            //assert
            Assert.AreEqual(forOut, result);
        }

    }
}
