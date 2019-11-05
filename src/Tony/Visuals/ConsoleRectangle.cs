using System;
using System.Drawing;
using System.Linq;

namespace Tony.Visuals
{
    public class ConsoleRectangle
        : ConsoleShape
    {
        public ConsoleRectangle(Rectangle area, ConsoleColor borderColor)
            : base(area, borderColor)
        { }

        public override void Draw(IDisplay display)
        {
            display.DrawText(base.BorderColor, base.Area.X, base.Area.Y, "╔".PadRight(base.Area.Width, '═') + "╗");

            string horizontalLine = "║".PadRight(base.Area.Width) + "║";

            Enumerable.Range(1, base.Area.Height)
                .ToList()
                .ForEach(
                    (i) => display.DrawText(base.BorderColor, base.Area.X, base.Area.Y + i, horizontalLine)
                );

            display.DrawText(base.BorderColor, base.Area.X, base.Area.Y + base.Area.Height, "╚".PadRight(base.Area.Width, '═') + "╝");
        }
    }
}
