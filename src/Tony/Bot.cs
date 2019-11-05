using System;
using System.Drawing;
using Tony.Visuals;

namespace Tony
{
    public class Bot
        : IBot
    {
        public Bot(Surface surface)
            : base()
        {
            this.Surface = surface;

            this._botShape = new BotShape(this, new Rectangle(1, 1, 10, 6), this.BorderColor) { IsVisible = false };

            this.Orientation = Orientation.North;
        }

        public ConsoleColor CrashedBorderColor { get; } = ConsoleColor.DarkYellow;
        public ConsoleColor BorderColor { get; } = ConsoleColor.Magenta;

        public Surface Surface { get; }

        private BotShape _botShape;
        public ConsoleShape Shape { get => this._botShape; }

        public Orientation Orientation { get; private set; }

        private bool Offset(int x, int y, Orientation orientation)
        {
            Rectangle area = this.Shape.Area;

            area.Offset(x, y);

            return ((IBot)this).Place(area.X, area.Y, orientation);
        }

        bool IBot.Place(int x, int y, Orientation orientation)
        {
            Rectangle newArea = new Rectangle(x, y, this.Shape.Area.Width, this.Shape.Area.Height);

            if (!this.Surface.Shape.Area.Contains(newArea))
            {
                this._botShape.BorderColor = this.CrashedBorderColor;

                return false;
            }
            else this._botShape.BorderColor = this.BorderColor;

            this.Shape.Area = newArea;

            this.Orientation = orientation;

            return this.Shape.IsVisible = true;
        }

        void IBot.Right()
        {
            this.Orientation = this.Orientation.Shift(90);
        }

        void IBot.Left()
        {
            this.Orientation = this.Orientation.Shift(-90);
        }

        public bool Move(int steps = 1)
        {
            if (true == this.Shape.IsVisible)
            {
                switch (this.Orientation.Name)
                {
                    case "N":
                        return this.Offset(0, -steps, this.Orientation);
                    case "E":
                        return this.Offset(steps, 0, this.Orientation);
                    case "W":
                        return this.Offset(-steps, 0, this.Orientation);
                    case "S":
                        return this.Offset(0, steps, this.Orientation);
                }
            }

            return false;
        }
    }
}