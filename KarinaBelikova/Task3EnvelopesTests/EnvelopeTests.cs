using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Task2Envelopes
{
    [TestClass]
    public class EnvelopeTests
    {
        #region ResultOfComparison_Tests()

        [TestMethod]
        public void ResultOfComparison_FirstInSecond()
        {
            //Arrenge
            Envelope first = new Envelope(1, 1);
            Envelope second = new Envelope(10, 1);
            string expected = Constants.FIRST_IN_SECOND;

            //Act
            string actual = Application.ResultOfComparison(first, second);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ResultOfComparison_SecondInFirst()
        {
            //Arrenge
            Envelope first = new Envelope(5, 6);
            Envelope second = new Envelope(1, 4);
            string expected = Constants.SECOND_IN_FIRST;

            //Act
            string actual = Application.ResultOfComparison(first, second);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ResultOfComparison_NotNested()
        {
            //Arrenge
            Envelope first = new Envelope(1, 1);
            Envelope second = new Envelope(1, 1);
            string expected = Constants.NOT_NESTED;

            //Act
            string actual = Application.ResultOfComparison(first, second);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        #endregion

        #region CompareTo_Tests()

        [TestMethod]
        public void CompareToTest_IsBigger()
        {
            // Arrange
            Envelope first = new Envelope(1, 2);
            Envelope second = new Envelope(3, 4);
            int expected = 1;

            // Act
            int actual = second.CompareTo(first);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CompareToTest_IsSmaller()
        {
            // Arrange
            Envelope first = new Envelope(1, 2);
            Envelope second = new Envelope(3, 4);
            int expected = -1;

            // Act
            int actual = first.CompareTo(second);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CompareToTest_AreSame()
        {
            // Arrange
            Envelope first = new Envelope(1, 2);
            Envelope second = new Envelope(1, 2);
            int expected = 0;

            // Act
            int actual = second.CompareTo(first);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        #endregion
    }
}