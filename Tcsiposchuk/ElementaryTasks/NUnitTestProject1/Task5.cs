using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Task5Conerter;

namespace Tests
{
    public class Task5
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void ShouldThrowExceptionFromConstructorInputModel()
        {
            Assert.Throws(typeof(ArgumentException), () => new InputModel(1999999999));
        }
        [Test]
        public void SholdThrowExceptionFromConstructorInputModel()
        {
            Assert.Throws(typeof(ArgumentException), () => new InputModel(-1999999999));
        }

        [Test]
        public void ValidatorIsNumber_GetsNotNumber_ShouldBeFalse()
        {
            bool result = Validator.IsNumber("ыыыыыыы");

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

            bool result = Validator.IsLenghtArgsInvalid(args.Length);

            Assert.IsTrue(result);
        }
        [Test]
        public void ValidatorIsLenghtArgsInvalid_Gets1Args_ShouldBeFalse()
        {
            string[] args = new string[1];

            bool result = Validator.IsLenghtArgsInvalid(args.Length);

            Assert.IsFalse(result);
        }
        [Test]
        public void ConverterString_GetNumber_ReturnRightString()
        {
            Converter conv = new Converter(23);
            string expected = "twenty-three";

            string actual = conv.String;

            Assert.AreEqual(expected, actual);
        }
        

        [Test]
        public void ConverterString_GetBigNumber_ReturnRightString()
        {
            Converter conv = new Converter(2488328);
            string expected = "two million four hundred eigthy-eight thousand three hundred twenty-eight";
            
            string actual = conv.String;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ConverterString_GetMinusNumber_ReturnRightString()
        {
            Converter conv = new Converter(-235451);
            string expected = "minus two hundred thirty-five thousand four hundred fifty-one";

            string actual = conv.String;

            Assert.AreEqual(expected, actual);
        }


    }
}
