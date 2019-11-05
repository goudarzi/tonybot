using Moq;
using NUnit.Framework;
using System;
using System.Drawing;
using System.Linq;
using Tony.Visuals;

namespace Tony.Tests
{
    class DisplayTests
    {
        [Test]
        [TestCase(0, 0, 10, 10, ConsoleColor.Black)]
        [TestCase(20, 20, 8, 6, ConsoleColor.DarkBlue)]
        public void ConsoleRectangleMustBePaintedCorrectly(int x, int y, int w, int h, ConsoleColor borderColor)
        {
            Mock<IDisplay> mockOfIDisplay = new Mock<IDisplay>();

            ConsoleRectangle consoleRectangle = new ConsoleRectangle(new Rectangle(x, y, w, h), borderColor);

            consoleRectangle.Draw(mockOfIDisplay.Object);

            mockOfIDisplay.Verify((display) => display.DrawText(borderColor, x, y, "╔".PadRight(w, '═') + "╗"));
            
            string horizontalLine = "║".PadRight(w) + "║";

            Enumerable.Range(1, h)
                .ToList()
                .ForEach(
                    (i) => mockOfIDisplay.Verify((display) => display.DrawText(borderColor, x, y + i, horizontalLine))
                );

            mockOfIDisplay.Verify((display) => display.DrawText(borderColor, x, y + h, "╚".PadRight(w, '═') + "╝"));
        }
    }
}
