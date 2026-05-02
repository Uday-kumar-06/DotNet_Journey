    using NUnit.Framework;
using CalculatorLib;
using System;

namespace CalculatorTests
{
    public class Tests
    {
        private Calculator calculator;

        [SetUp]
        public void Setup()
        {
            calculator = new Calculator();
        }

        [Test]
        public void Add_ReturnsCorrectResult()
        {
            Assert.That(calculator.Add(5, 3), Is.EqualTo(8));
        }

        [Test]
        public void Subtract_ReturnsCorrectResult()
        {
            Assert.That(calculator.Subtract(10, 4), Is.EqualTo(6));
        }

        [Test]
        public void Multiply_ReturnsCorrectResult()
        {
            Assert.That(calculator.Multiply(3, 4), Is.EqualTo(12));
        }

        [Test]
        public void Divide_ReturnsCorrectResult()
        {
            Assert.That(calculator.Divide(10, 2), Is.EqualTo(5));
        }

        [Test]
        public void Divide_ByZero_ThrowsException()
        {
            Assert.Throws<DivideByZeroException>(() => calculator.Divide(10, 0));
        }
    }
}