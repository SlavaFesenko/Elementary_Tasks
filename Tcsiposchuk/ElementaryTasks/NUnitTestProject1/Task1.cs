using NUnit.Framework;
using System;
using Task1;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void SholdThrowExceptionFromConstructorInputModel()
        {
            Assert.Throws(typeof(ArgumentException), () => new Task1.InputModel(32, 33));
        }

        [Test]
        public void ValidatorIsNumber_GetsNotNumber_ShouldBeFalse()
        {
            bool result = Validator.IsNumber("ûûûûûûû");

            Assert.IsFalse(result);
        }
        [Test]
        public void ValidatorIsNumber_GetsNumber_ShouldBeTrue()
        {
            bool result = Validator.IsNumber("23");

            Assert.IsTrue(result);
        }
        [Test]
        public void ValidatorIsLenghtArgsInvalid_Gets3Args_ShouldBeTrue()
        {
            string[] args = new string[3];

            bool result = Validator.IsLenghtArgsInvalid(args);

            Assert.IsTrue(result);
        }
        [Test]
        public void ValidatorIsLenghtArgsInvalid_Gets1Args_ShouldBeTrue()
        {
            string[] args = new string[1];

            bool result = Validator.IsLenghtArgsInvalid(args);

            Assert.IsTrue(result);
        }
        [Test]
        public void ValidatorIsLenghtArgsInvalid_Gets2Args_ShouldBeFalse()
        {
            string[] args = new string[2];

            bool result = Validator.IsLenghtArgsInvalid(args);

            Assert.IsFalse(result);
        }
        [Test]
        public void ValidatorIsValidArgs_GetsOnlyOneNumber_ShouldThrowException()
        {
            string[] args = new string[1];

            Assert.Throws(typeof(IndexOutOfRangeException), () => Validator.IsValidArgs(args));
        }

        [Test]
        public void ValidatorIsValidArgs_Gets2Numbers_ShouldBeTrue()
        {
            string[] args = new string[2] { "2", "3" };

            bool result = Validator.IsValidArgs(args);

            Assert.True(result);
        }
        [Test]
        public void ValidatorIsValidArgs_GetsNumberAndString_ShouldBeFalse()
        {
            string[] args = new string[2] { "2", "ssss" };

            bool result = Validator.IsValidArgs(args);

            Assert.IsFalse(result);
        }
    }
}