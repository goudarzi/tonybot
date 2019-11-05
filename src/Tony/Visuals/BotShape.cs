using System;
using System.Drawing;

namespace Tony.Visuals
{
    class BotShape
        : ConsoleRectangle
    {
        public BotShape(IBot bot, Rectangle area, ConsoleColor borderColor)
            : base(area, borderColor)
        {
            this.Bot = bot;
        }

        public IBot Bot { get; }

        public override void Draw(IDisplay display)
        {
            base.Draw(display);

            display.DrawText(ConsoleColor.Gray, this.Area.X + 3, this.Area.Y + 1, $"{this.Area.X},{this.Area.Y}");
            display.DrawText(ConsoleColor.White, this.Area.X + 3, this.Area.Y + 2, this.Bot.Orientation.Name);
            display.DrawText(ConsoleColor.DarkGreen, this.Area.X + 5, this.Area.Y + 2, this.Bot.Orientation.Value.ToString());

            string headlight = "X";
            switch (this.Bot.Orientation.Name)
            {
                case "N":
                    display.DrawText(ConsoleColor.Yellow, base.Area.X + (base.Area.Width / 2), base.Area.Y, headlight);
                    break;
                case "S":
                    display.DrawText(ConsoleColor.Yellow, base.Area.X + (base.Area.Width / 2), base.Area.Y + base.Area.Height, headlight);
                    break;
                case "E":
                    display.DrawText(ConsoleColor.Yellow, base.Area.X + base.Area.Width, base.Area.Y + (this.Area.Height / 2), headlight);
                    break;
                case "W":
                    display.DrawText(ConsoleColor.Yellow, base.Area.X, base.Area.Y + (this.Area.Height / 2), headlight);
                    break;
            }
        }
    }
}
