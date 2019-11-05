using NUnit.Framework;
using System.Drawing;

namespace Tony.Tests
{
    class BotMovementTests
    {
        [SetUp]
        public void SetupTony()
        {
            Surface s1 = new Surface(0, 0, 30, 30);
            this._bot = new Bot(s1);
        }

        private IBot _bot = default;

        [Test]
        [TestCase(10, 11, true)]
        [TestCase(10, 0, false)]
        [TestCase(10, 1, true)]
        [TestCase(1, 1, true)]
        [TestCase(-1, -1, false)]
        public void BotMustMoveTowardsNorth(int x, int y, bool expectedResult)
        {
            this._bot.Place(x, y, Orientation.North);

            Orientation o1 = this._bot.Orientation;
            Rectangle area = this._bot.Shape.Area;

            var result = this._bot.Move();

            Assert.AreEqual(expectedResult, result);

            Assert.AreEqual(area.X, this._bot.Shape.Area.X);

            if (result == true)
            {
                Assert.AreEqual(area.Y - 1, this._bot.Shape.Area.Y);
                Assert.AreEqual(Orientation.North, this._bot.Orientation);
            }
            else if (result == false)
            {
                Assert.AreEqual(area.Y, this._bot.Shape.Area.Y);
                Assert.AreEqual(o1, this._bot.Orientation);
            }
        }

        [Test]
        [TestCase(10, 11, true)]
        [TestCase(10, 30, false)]
        [TestCase(10, 1, true)]
        [TestCase(1, 1, true)]
        [TestCase(-1, -1, false)]
        public void BotMustMoveTowardsSouth(int x, int y, bool expectedResult)
        {
            this._bot.Place(x, y, Orientation.South);

            Orientation o1 = this._bot.Orientation;
            Rectangle area = this._bot.Shape.Area;

            var result = this._bot.Move();

            Assert.AreEqual(expectedResult, result);

            Assert.AreEqual(area.X, this._bot.Shape.Area.X);

            if (result == true)
            {
                Assert.AreEqual(area.Y + 1, this._bot.Shape.Area.Y);
                Assert.AreEqual(Orientation.South, this._bot.Orientation);
            }
            else if (result == false)
            {
                Assert.AreEqual(area.Y, this._bot.Shape.Area.Y);
                Assert.AreEqual(o1, this._bot.Orientation);
            }
        }

        [Test]
        [TestCase(10, 11, true)]
        [TestCase(0, 0, false)]
        [TestCase(10, 1, true)]
        [TestCase(1, 1, true)]
        [TestCase(-1, -1, false)]
        public void BotMustMoveTowardsWest(int x, int y, bool expectedResult)
        {
            this._bot.Place(x, y, Orientation.West);

            Orientation o1 = this._bot.Orientation;
            Rectangle area = this._bot.Shape.Area;

            var result = this._bot.Move();

            Assert.AreEqual(expectedResult, result);

            Assert.AreEqual(area.Y, this._bot.Shape.Area.Y);

            if (result == true)
            {
                Assert.AreEqual(area.X - 1, this._bot.Shape.Area.X);
                Assert.AreEqual(Orientation.West, this._bot.Orientation);
            }
            else if (result == false)
            {
                Assert.AreEqual(area.X, this._bot.Shape.Area.X);
                Assert.AreEqual(o1, this._bot.Orientation);
            }
        }

        [Test]
        [TestCase(10, 11, true)]
        [TestCase(30, 0, false)]
        [TestCase(10, 1, true)]
        [TestCase(1, 1, true)]
        [TestCase(-1, -1, false)]
        public void BotMustMoveTowardsEast(int x, int y, bool expectedResult)
        {
            this._bot.Place(x, y, Orientation.East);

            Orientation o1 = this._bot.Orientation;
            Rectangle area = this._bot.Shape.Area;

            var result = this._bot.Move();

            Assert.AreEqual(expectedResult, result);

            Assert.AreEqual(area.Y, this._bot.Shape.Area.Y);

            if (result == true)
            {
                Assert.AreEqual(area.X + 1, this._bot.Shape.Area.X);
                Assert.AreEqual(Orientation.East, this._bot.Orientation);
            }
            else if (result == false)
            {
                Assert.AreEqual(area.X, this._bot.Shape.Area.X);
                Assert.AreEqual(o1, this._bot.Orientation);
            }
        }
    }
}
