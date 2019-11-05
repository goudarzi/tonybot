using NUnit.Framework;
using System;

namespace Tony.Tests
{
    public class OrientationTests
    {
        [Test]
        public void NESWInstancesMustBeReturnedByName()
        {
            Assert.AreEqual(Orientation.North, Orientation.GetByName(nameof(Orientation.North)));
            Assert.AreEqual(Orientation.East, Orientation.GetByName(nameof(Orientation.East)));
            Assert.AreEqual(Orientation.South, Orientation.GetByName(nameof(Orientation.South)));
            Assert.AreEqual(Orientation.West, Orientation.GetByName(nameof(Orientation.West)));

            Assert.Throws<InvalidOperationException>(() => Orientation.GetByName("SouthWest"));
        }

        [Test]
        [TestCase("E", 90)]
        [TestCase("S", 180)]
        [TestCase("W", 270)]
        [TestCase("N", 360)]
        [TestCase("W", -90)]
        [TestCase("S", -180)]
        [TestCase("E", -270)]
        public void NESWMustBeIdentifiedCorrectly(string name, int value)
        {
            Orientation o = Orientation.North;

            o = o.Shift(value);

            Assert.AreEqual("N", Orientation.North.Name);
            Assert.AreEqual(0, Orientation.North.Value);

            Assert.AreEqual(name, o.Name);
        }
    }
}
