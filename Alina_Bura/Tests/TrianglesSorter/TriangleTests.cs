using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using TrianglesSorting_3;

namespace Tests
{
    [TestClass]
    public class TriangleTests
    {
        [TestMethod]
        public void Perimeter_Positive_CorrectPerimeter()
        {
            List<List<double>> sides = new List<List<double>>();
            sides.Add(new List<double>() { 2.2, 3.3, 4.4 });
            sides.Add(new List<double>() { 2, 3, 4 });
            sides.Add(new List<double>() { 1, 1, 1 });

            List<double> expectedResults = new List<double>();
            List<double> actualResults = new List<double>();
            List<Triangle> triangles = new List<Triangle>();

            for (int i = 0; i < sides.Count; i++)
            {
                expectedResults.Add(sides[i].Sum());
            }
            for (int i = 0; i < sides.Count; i++)
            {
                triangles.Add(new Triangle($"name{i}", sides[i][0], sides[i][1], sides[i][2]));
            }

            for (int i = 0; i < triangles.Count; i++)
            {
                actualResults.Add(triangles[i].Perimeter);
            }

            CollectionAssert.AreEqual(actualResults, expectedResults);
        }

        [TestMethod]
        public void Square_Positive_CorrectSquare()
        {
            List<List<double>> sides = new List<List<double>>();
            sides.Add(new List<double>() { 2.2, 3.3, 4.4 });
            sides.Add(new List<double>() { 2, 3, 4 });
            sides.Add(new List<double>() { 1, 1, 1 });

            List<double> expectedResults = new List<double>();
            List<double> actualResults = new List<double>();
            List<Triangle> triangles = new List<Triangle>();
                        
            expectedResults.Add(3.5147323866832307);
            expectedResults.Add(2.9047375096555625);
            expectedResults.Add(0.4330127701892393);

            for (int i = 0; i < sides.Count; i++)
            {
                triangles.Add(new Triangle($"name{i}", sides[i][0], sides[i][1], sides[i][2]));
            }

            for (int i = 0; i < triangles.Count; i++)
            {
                actualResults.Add(triangles[i].Square);
            }

            for (int i = 0; i < actualResults.Count; i++)
            {
                Assert.IsTrue(actualResults[i] - expectedResults[i] < 0.001);
            }
        }

        [TestMethod]
        public void Validator_Negative_ArgumentException()
        {
            List<List<double>> sides = new List<List<double>>();
            sides.Add(new List<double>() { -2.2, 3.3, 4.4 });
            sides.Add(new List<double>() { 2, -3, 4 });
            sides.Add(new List<double>() { 1, 1, 0 });

            for (int i = 0; i < sides.Count; i++)
            {
                Assert.ThrowsException<ArgumentException>(() => new Triangle($"name{i}", sides[i][0], sides[i][1], sides[i][2]));
            }
        }

        [TestMethod]
        public void Validator_InvalidTriangle_ArgumentException()
        {
            List<List<double>> sides = new List<List<double>>();
            sides.Add(new List<double>() { 1, 1, 3 });
            sides.Add(new List<double>() { 5, 6, 20 });
            sides.Add(new List<double>() { 2, 2, 4 });

            for (int i = 0; i < sides.Count; i++)
            {
                Assert.ThrowsException<ArgumentException>(() => new Triangle($"name{i}", sides[i][0], sides[i][1], sides[i][2]));
            }
        }

        [TestMethod]
        public void ToString_Triangle_CorrectString()
        {
            List<List<double>> sides = new List<List<double>>();
            sides.Add(new List<double>() { 2.2, 3.3, 4.4 });
            sides.Add(new List<double>() { 2, 3, 4 });
            sides.Add(new List<double>() { 1, 1, 1 });

            List<string> expectedResults = new List<string>();
            List<string> actualResults = new List<string>();

            expectedResults.Add("[Triangle name0]: 3.5147 cm");
            expectedResults.Add("[Triangle name1]: 2.9047 cm");
            expectedResults.Add("[Triangle name2]: 0.433 cm");

            for (int i = 0; i < sides.Count; i++)
            {
                actualResults.Add(new Triangle($"name{i}", sides[i][0], sides[i][1], sides[i][2]).ToString());
            }

            CollectionAssert.AreEqual(actualResults, expectedResults);
        }
    }
}
