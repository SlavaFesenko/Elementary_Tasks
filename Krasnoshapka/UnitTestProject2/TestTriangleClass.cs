
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Elementary_Tasks_3;

namespace UnitTestElementaryTask3
{
    [TestClass]
    public class TestTriangleClass
    {
        [TestMethod]
        [DataRow("first", 3, 4, 5, "first", 3, 4, 5)]
        [DataRow("second", 10, 6, 8, "second", 10, 6, 8)]

        public void TestTriangleInitialize_Correct
                    (string triangleName, float firstTriangleSide,
                    float secondTriangleSide, float thirdTriangleSide, 
                    string expectedTriangleName, float expectedFirstTriangleSide,
                    float expectedSecondTriangleSide, float expectedThirdTriangleSide)
        {
            Triangle triangle = Triangle.TriangleInitialize(triangleName, firstTriangleSide, secondTriangleSide, thirdTriangleSide);

            Assert.IsTrue((expectedTriangleName == triangle.TriangleName)
                && (expectedFirstTriangleSide == triangle.FirstSide)
                && (expectedSecondTriangleSide == triangle.SecondSide)
                && (expectedThirdTriangleSide == triangle.ThirdSide));
        }

        [TestMethod]
        [DataRow("first", 3, 4, 5, 6)]
        [DataRow("second", 10, 6, 8, 24)]

        public void TestSquareOfTriangle_Correct
                    (string triangleName, float firstTriangleSide,
                    float secondTriangleSide, float thirdTriangleSide, int expected)
        {
            Triangle triangle = Triangle.TriangleInitialize(triangleName, firstTriangleSide, secondTriangleSide, thirdTriangleSide);

            float actual = triangle.GetSquare();

            Assert.AreEqual(expected, actual, "Not correct square calculated");
        }

        [TestMethod]

        public void TestListOfTrianglesSort_Correct()
        {
            Triangle triangleFirst = Triangle.TriangleInitialize("first", 4, 6, 7);
            Triangle triangleSecond = Triangle.TriangleInitialize("second", 7, 11, 9);
            Triangle triangleThird = Triangle.TriangleInitialize("third", 2, 3, 4);
            List<Triangle> actual = new List<Triangle> { triangleFirst, triangleSecond, triangleThird };
            List<Triangle> expected = new List<Triangle> { triangleSecond, triangleFirst, triangleThird };

            actual.Sort(new TrianglesCompare());

            CollectionAssert.AreEqual(expected, actual, "Not correct sorting by square");
        }


        [TestMethod]

        public void TestCreatingOfNegativeSidesTriangle_ArgumentExceptionThrow()
        {
            Assert.ThrowsException<ArgumentException> (() => Triangle.TriangleInitialize("wrongTriangle", -3, 1, 1));
        }
    }
}
