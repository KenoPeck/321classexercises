using NUnit.Framework;
using System.Globalization;

namespace ExpressionTreeCodeDemo
{
    [TestFixture]
    public class ExpressionTreeTests
    {
        [Test]
        [TestCase("3+5", ExpectedResult = 8.0)] // expression with a single operator
        [TestCase("100/10*10", ExpectedResult = 100.0)] // mixing operators (/ and *) with same precedence
        [TestCase("100/(10*10)", ExpectedResult = 1.0)]  // mixing operators (/ and *) with same precedence and parenthesis
        [TestCase("7-4+2", ExpectedResult = 5.0)] // mixing operators (+ and -) with same precedence 
        [TestCase("10/(7-2)", ExpectedResult = 2.0)]  // operators with different precedence with parentheses - higher precedence first
        [TestCase("(12-2)/2", ExpectedResult = 5.0)] // operators with different precedence with parentheses - lower precedence first
        [TestCase("(((((2+3)-(4+5)))))", ExpectedResult = -4.0)] // extra parentheses and negative result
        [TestCase("2*3+5", ExpectedResult = 11.0)] // operators with different precedence - higher precedence first
        [TestCase("2+3*5", ExpectedResult = 17.0)] // operators with different precedence - lower precedence first 
        [TestCase("2 + 3 * 5", ExpectedResult = 17.0)]  // spaces and mixing operators (+ and *) with different precedence
        [TestCase("5/0", ExpectedResult = double.PositiveInfinity)] // Dividing a floating-point value by zero doesn't throw an exception; 
                                                                    // it results in positive infinity, negative infinity, or not a number (NaN), 
                                                                    // according to the rules of IEEE 754 arithmetic. 
        public double TestEvaluateNormalCases(string expression)
        {
            Expression exp = new Expression(expression);
            return exp.Evaluate();
        }

        // TODO: Refactor to something more descriptive such as InvalidExpression
        [TestCase("((2+5))-2(2+3))")] // extra parenthesis at the end
        public void TestConstructInvalidExpression(string expression)
        {
            Assert.That(() => new Expression(expression), Throws.TypeOf<System.Exception>());
        }

        // TODO: Refactor to something more descriptive such as UnsupportedOperatorException
        [TestCase("4%2")] 
        public void TestEvaluateUnsupportedOperator(string expression)
        {
            Expression exp = new Expression(expression);
            Assert.That(() => exp.Evaluate(), Throws.TypeOf<System.Collections.Generic.KeyNotFoundException>());
        }

        [Test]
        public void TestInfinity()
        {
            string maxValue = (double.MaxValue).ToString("F", CultureInfo.InvariantCulture);
            double result = new Expression($"{maxValue}+{maxValue}").Evaluate();
            Assert.True(double.IsInfinity(result));
        }

        [Test]
        public void TestExpressionsWithVariableValues()
        {
            Expression exp = new Expression("A3+5");
            exp.SetVariable("A3",23);
            Assert.AreEqual(28, exp.Evaluate());

            exp = new Expression("B2+A3*5");
            exp.SetVariable("A3", 3);
            exp.SetVariable("B2", 2);
            Assert.AreEqual(17, exp.Evaluate());
        }
    }
}
