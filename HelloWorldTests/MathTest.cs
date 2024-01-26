namespace HelloWorld.Math.Tests
{
    using NUnit.Framework;
    using HelloWorld.Math;

    [TestFixture]
    public class MathTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestAdd()
        {
            // positive numbers (normal case)
            Assert.AreEqual(2, Math.Add(1,1));
            Assert.AreEqual(-1, Math.Add(6,-7));
        }
    }
}