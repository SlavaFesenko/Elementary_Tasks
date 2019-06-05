using CommonThings.AbstractClasses;
using NUnit.Framework;
using Task8_FibonacciOrder;


namespace TestForTasks
{
    [TestFixture]
    class BorderClassTesting
    {
        private Range _range = null;

        [SetUp]
        public void Setup()
        {
            _range = new Borders(null);
        }

        [TestCase]
        public void GetTrueFind_UpperBoarder_RangeBigger()
        {
            //arrange
            int[] _numberForCount = { 4, 6, 9, 14, 22, 35, 56, 90, 145 };
            int[] _etalonResults = { 4, 5, 6, 7, 8, 9, 10, 11, 12 };
            int _length = _numberForCount.Length;

            int[] result = new int[_length];

            //act
            for (int i = 0; i < _length; i++)
            {
                result[i] = _range.GetUpperBoarderConditionals(_numberForCount[i]);
            }

            //assert
            for (int i = 0; i < _length; i++)
            {
                Assert.AreEqual(_etalonResults[i], result[i]);
            }
        }

        [TestCase]
        public void GetTrueFind_UpperBoarder_RangeEqualBorder()
        {
            //arrange
            int[] _numberForCount = { 3, 5, 8, 13, 21, 34, 55, 89, 144 };
            int[] _etalonResults = { 4, 5, 6, 7, 8, 9, 10, 11, 12 };
            int _length = _numberForCount.Length;

            int[] result = new int[_length];

            //act
            for (int i = 0; i < _length; i++)
            {
                result[i] = _range.GetUpperBoarderConditionals(_numberForCount[i]);
            }

            //assert
            for (int i = 0; i < _length; i++)
            {
                Assert.AreEqual(_etalonResults[i], result[i]);
            }
        }

        [TestCase]
        public void GetTrueFind_LowwerBorder_RangeSmaller()
        {
            //arrange
            int[] _numberForCount = { 4, 7, 12, 20, 33, 54, 88, 143 };
            int[] _etalonResults = { 5, 6, 7, 8, 9, 10, 11, 12 };
            int _length = _numberForCount.Length;

            int[] result = new int[_length];

            //act
            for (int i = 0; i < _length; i++)
            {
                result[i] = _range.GetLowerBorderWithConditionals(_numberForCount[i]);
            }

            //assert
            for (int i = 0; i < _length; i++)
            {
                Assert.AreEqual(_etalonResults[i], result[i]);
            }
        }

        [TestCase]
        public void GetTrueFind_LowwerBorder_RangeEqualBorder()
        {
            //arrange
            int[] _numberForCount = { 3, 5, 8, 13, 21, 34, 55, 89, 144 };
            int[] _etalonResults = { 4, 5, 6, 7, 8, 9, 10, 11, 12 };
            int _length = _numberForCount.Length;

            int[] result = new int[_length];

            //act
            for (int i = 0; i < _length; i++)
            {
                result[i] = _range.GetLowerBorderWithConditionals(_numberForCount[i]);
            }

            //assert
            for (int i = 0; i < _length; i++)
            {
                Assert.AreEqual(_etalonResults[i], result[i]);
            }
        }
    }
}

