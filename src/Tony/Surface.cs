using System;
using System.Drawing;
using Tony.Visuals;

namespace Tony
{
    public class Surface
        : ISurface
    {
        public Surface(int x, int y, int width, int height)
        {
            this.Shape = new ConsoleRectangle(new Rectangle(x, y, width, height), ConsoleColor.DarkGray);
        }

        public ConsoleShape Shape { get; }
    }
}
