using System;
using System.Drawing;

namespace Tony.Visuals
{
    public abstract class ConsoleShape
    {
        public ConsoleShape()
            : base()
        {
            this.IsVisible = true;
        }

        protected ConsoleShape(Rectangle area, ConsoleColor borderColor)
            : this()
        {
            this.Area = area;
            this.BorderColor = borderColor;
        }

        public Rectangle Area { get; set; }
        public ConsoleColor BorderColor { get; set; }
        public bool IsVisible { get; set; }
        public abstract void Draw(IDisplay display);
    }
}