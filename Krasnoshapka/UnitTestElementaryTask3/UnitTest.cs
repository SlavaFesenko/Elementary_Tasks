
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Elementary_Tasks_3;

namespace UnitTestElementaryTask3
{
    [TestClass]
    public class TestTriangleClass
    {
        /// <summary>
        /// Testing correct execution of
        /// <see cref="Triangle.Square()"/> method.
        /// </summary>
        /// <param name="triangleName">Name of triangle</param>
        /// <param name="firstTriangleSide">First side of triangle</param>
        /// <param name="secondTriangleSide">Second side of triangle</param>
        /// <param name="thirdTriangleSide">Third side of triangle</param>
        /// <param name="expected">Expected square</param>
        [TestMethod]
        [DataRow("first", 3, 4, 5, 6)]
        [DataRow("second", 10, 6, 8, 24)]

        public void TestSquareOfTriangle_Correct
                    (string triangleName, float firstTriangleSide,
                    float secondTriangleSide, float thirdTriangleSide, int expected)
        {
            Triangle triangle = Triangle.TriangleInitialize(firstTriangleSide, secondTriangleSide, thirdTriangleSide, triangleName);
            float actual = triangle.Square();

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Testing sorting is determined in 
        /// <see cref="TriangleComparerBySquare"/> class.
        /// </summary>
        [TestMethod]

        public void TestListOfTrianglesSort_Correct()
        {
            Triangle triangleFirst = Triangle.Initialize(4, 6, 7, "first");
            Triangle triangleSecond = Triangle.Initialize(7, 11, 9, "second");
            Triangle triangleThird = Triangle.Initialize(2, 3, 4, "third");
            List<Triangle> actual = new List<Triangle> { triangleFirst, triangleSecond, triangleThird };
            List<Triangle> expected = new List<Triangle> { triangleSecond, triangleFirst, triangleThird };

            actual.Sort(new TriangleComparerBySquare());

            CollectionAssert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Testing throwing exceptions at creating 
        /// wrong instance of <see cref="Triangle"/> class.
        /// </summary>
        [TestMethod]

        public void TestCreatingOfNegativeSidesTriangle_OverflowExceptionThrow()
        {
            Assert.ThrowsException<WrongTriangleParametersException>(() => Triangle.Initialize(-3, 1, 1, "wrongTriangle"));
        }
    }
}
