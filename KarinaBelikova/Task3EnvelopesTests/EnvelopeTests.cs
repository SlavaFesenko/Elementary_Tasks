using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Task2Envelopes.Tests
{
    [TestClass()]
    public class EnvelopeTests
    {
        [TestMethod()]
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

        [TestMethod()]
        public void CompareToTest_IsNotBigger()
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

        [TestMethod()]
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
    }
}