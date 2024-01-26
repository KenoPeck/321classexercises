using System;


namespace HelloWorld.Date.Tests
{
    using NUnit.Framework;
    using HelloWorld.Date;

    [TestFixture]
    public class DateTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestIsLeap()
        {
            // positive numbers (normal case)
            Assert.AreEqual(false, Date.IsLeap(100));
            Assert.AreEqual(true, Date.IsLeap(4));
        }
    }
}
