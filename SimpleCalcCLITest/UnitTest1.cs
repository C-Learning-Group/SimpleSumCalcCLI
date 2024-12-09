using NUnit.Framework;
using SimpleCalcCLI;

namespace SimpleCalcCLITests
{
    [TestFixture]
    public class CalculatorTests
    {
        private Calculator? calculator;

        [SetUp]
        public void Setup()
        {
            calculator = new Calculator();
        }

        #region TryParseNumber Tests

        [Test]
        public void TryParseNumber_ValidInteger_ReturnsTrueAndParsesNumber()
        {
            // Arrange
            string input = "12345";

            // Act
            bool result = Calculator.TryParseNumber(input, out long number);

            // Assert
            Assert.IsTrue(result);
            Assert.That(number, Is.EqualTo(12345));
        }

        [Test]
        public void TryParseNumber_InvalidInteger_ReturnsFalse()
        {
            // Arrange
            string input = "abc123";

            // Act
            bool result = Calculator.TryParseNumber(input, out long number);

            // Assert
            Assert.IsFalse(result);
            Assert.That(number, Is.EqualTo(0));
        }

        [Test]
        public void TryParseNumber_NullInput_ReturnsFalse()
        {
            // Arrange
            string? input = null;

            // Act
            bool result = Calculator.TryParseNumber(input, out long number);

            // Assert
            Assert.IsFalse(result);
            Assert.That(number, Is.EqualTo(0));
        }

        [Test]
        public void TryParseNumber_EmptyString_ReturnsFalse()
        {
            // Arrange
            string input = "";

            // Act
            bool result = Calculator.TryParseNumber(input, out long number);

            // Assert
            Assert.IsFalse(result);
            Assert.That(number, Is.EqualTo(0));
        }

        [Test]
        public void TryParseNumber_NumberWithSpaces_ReturnsTrueAndParsesNumber()
        {
            // Arrange
            string input = "  4567  ";

            // Act
            bool result = Calculator.TryParseNumber(input, out long number);

            // Assert
            Assert.IsTrue(result);
            Assert.That(number, Is.EqualTo(4567));
        }

        [Test]
        public void TryParseNumber_NegativeNumber_ReturnsTrueAndParsesNumber()
        {
            // Arrange
            string input = "-789";

            // Act
            bool result = Calculator.TryParseNumber(input, out long number);

            // Assert
            Assert.IsTrue(result);
            Assert.That(number, Is.EqualTo(-789));
        }

        [Test]
        public void TryParseNumber_MaxLongValue_ReturnsTrueAndParsesNumber()
        {
            // Arrange
            string input = long.MaxValue.ToString();

            // Act
            bool result = Calculator.TryParseNumber(input, out long number);

            // Assert
            Assert.IsTrue(result);
            Assert.That(number, Is.EqualTo(long.MaxValue));
        }

        [Test]
        public void TryParseNumber_MinLongValue_ReturnsTrueAndParsesNumber()
        {
            // Arrange
            string input = long.MinValue.ToString();

            // Act
            bool result = Calculator.TryParseNumber(input, out long number);

            // Assert
            Assert.IsTrue(result);
            Assert.That(number, Is.EqualTo(long.MinValue));
        }

        #endregion

        #region CalculateSum Tests

        [Test]
        public void CalculateSum_PositiveNumbers_ReturnsCorrectSum()
        {
            // Arrange
            long firstNumber = 100;
            long secondNumber = 200;

            // Act
            long sum = Calculator.CalculateSum(firstNumber, secondNumber);

            // Assert
            Assert.That(sum, Is.EqualTo(300));
        }

        [Test]
        public void CalculateSum_NegativeNumbers_ReturnsCorrectSum()
        {
            // Arrange
            long firstNumber = -50;
            long secondNumber = -70;

            // Act
            long sum = Calculator.CalculateSum(firstNumber, secondNumber);

            // Assert
            Assert.That(sum, Is.EqualTo(-120));
        }

        [Test]
        public void CalculateSum_PositiveAndNegativeNumbers_ReturnsCorrectSum()
        {
            // Arrange
            long firstNumber = 150;
            long secondNumber = -30;

            // Act
            long sum = Calculator.CalculateSum(firstNumber, secondNumber);

            // Assert
            Assert.That(sum, Is.EqualTo(120));
        }

        [Test]
        public void CalculateSum_ZeroValues_ReturnsZero()
        {
            // Arrange
            long firstNumber = 0;
            long secondNumber = 0;

            // Act
            long sum = Calculator.CalculateSum(firstNumber, secondNumber);

            // Assert
            Assert.That(sum, Is.EqualTo(0));
        }

        [Test]
        public void CalculateSum_MaxAndMinLongValues_ReturnsOverflow()
        {
            // Arrange
            long firstNumber = long.MaxValue;
            long secondNumber = long.MinValue;

            // Act
            long sum = Calculator.CalculateSum(firstNumber, secondNumber);

            // Assert
            // long.MaxValue + long.MinValue should be -1
            Assert.That(sum, Is.EqualTo(-1));
        }

        #endregion
    }
}
