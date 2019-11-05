using System;
using System.Collections.Generic;
using System.Text;

namespace Tony.Commands
{
    public class PlaceCommand
        : Command
    {
        private PlaceCommand(int x, int y, string orientation)
        {
            this.X = x;
            this.Y = y;
            this.Orientation = Orientation.GetByName(orientation);
        }

        public int X { get; }
        public int Y { get; }
        public Orientation Orientation { get; }

        public override void Execute(IBot bot)
        {
            bot.Place(this.X, this.Y, this.Orientation);
        }

        public static Command Parse(string[] tokens)
        {
            if (tokens.Length != 4)

                throw new InvalidOperationException($"{nameof(PlaceCommand)} accepts 3 parameters. X, Y and Orientation (South, North, East and West).");

            if (tokens[0].ToUpper() != "PLACE")

                throw new InvalidOperationException($"Command {tokens[0]} cannot be parsed into {nameof(PlaceCommand)}.");

            return new PlaceCommand(Int32.Parse(tokens[1]), Int32.Parse(tokens[2]), tokens[3]);
        }
    }
}
