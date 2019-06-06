using System;
using System.Text;
using System.Collections.Generic;
using TrianglesSorting_3;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class TriangleComparerTests
    {
        [TestMethod]
        public void Compare_More_ReturnMinus1()
        {
            Triangle t1 = new Triangle("name0", 2.2, 3.3, 4.4);
            Triangle t2 = new Triangle("name1", 2, 3, 4);
            IComparer<Triangle> comparer = new TriangleDescBySquareComparer();

            int result = comparer.Compare(t1, t2);

            Assert.IsTrue(result == -1);
        }

        [TestMethod]
        public void Compare_Less_Return1()
        {
            Triangle t1 = new Triangle("name0", 2, 3, 4);
            Triangle t2 = new Triangle("name1", 2.2, 3.3, 4.4);
            IComparer<Triangle> comparer = new TriangleDescBySquareComparer();

            int result = comparer.Compare(t1, t2);

            Assert.IsTrue(result == 1);
        }

        [TestMethod]
        public void Compare_Equals_Return0()
        {
            Triangle t1 = new Triangle("name0", 2, 3, 4);
            Triangle t2 = new Triangle("name1", 2, 3, 4);
            IComparer<Triangle> comparer = new TriangleDescBySquareComparer();

            int result = comparer.Compare(t1, t2);

            Assert.IsTrue(result == 0);
        }
    }
}
