using NUnit.Framework;
using CommonThings.Interfaces;
using Task8_FibonacciOrder;
using CommonThings.AbstractClasses;
using System.Collections.Generic;

namespace TestForTasks
{
    [TestFixture]
    class OrderFibonacciWithBordersClassTesting
    {
        private Order _fibOrder = null;
        private Range _range = null;
        private List<int> _fibList = new List<int> { 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, 610, 987, 1597 };

        [SetUp]
        public void Setup()
        {
            _fibOrder = new OrderFibonacciWithBorders(null, null);
            _range = new Borders(null);

        }

        [TestCase(0, 10)]
        [TestCase(2, 11)]
        [TestCase(3, 12)]
        [TestCase(5, 15)]
        [TestCase(8, 17)]
        public void GetTrueOrderWithRanges(int lowBord, int upBord)
        {
            //arrange
            _range.LowerBorder = lowBord;
            _range.UpperBorder = upBord;
            int _length = upBord - lowBord;
            int index = lowBord;

            IEnumerable<int> result = null;

            //act
            result = _fibOrder.FindArrayOrder(_range);

            //assert
            foreach (var number in result)
            {
                Assert.AreEqual(number, _fibList[index]);
                index++;
            }
        }
    }
}
