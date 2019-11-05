using Moq;
using NUnit.Framework;
using Tony;

namespace Tests
{
    public class BotSurfaceTests
    {
        [Test]
        [TestCase(20, 20, 10, 11, true, 10, 11)]
        [TestCase(20, 20, 20, 20, false, 1, 1)]
        [TestCase(20, 20, 18, 19, false, 1, 1)]
        [TestCase(20, 20, 130, 100, false, 1, 1)]
        [TestCase(100, 100, -10, -50, false, 1, 1)]
        public void BotMustNotFallOnPlacement(int width, int height, int x, int y, bool expectedResult, int expectedX, int expectedY)
        {
            Surface s1 = new Surface(0, 0, width, height);
            IBot b1 = new Bot(s1);
            Orientation o1 = b1.Orientation;

            var result = b1.Place(x, y, Orientation.South);

            Assert.AreEqual(expectedResult, result);
            Assert.AreEqual(expectedX, b1.Shape.Area.X);
            Assert.AreEqual(expectedY, b1.Shape.Area.Y);

            if (result == true)
            {
                Assert.AreEqual(Orientation.South, b1.Orientation);
            }
            else if (result == false)
            {
                Assert.AreEqual(o1, b1.Orientation);
            }
        }
    }
}