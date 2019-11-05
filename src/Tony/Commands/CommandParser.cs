using System;
using System.Collections.Generic;
using System.Linq;

namespace Tony.Commands
{
    class CommandParser
    {
        public IEnumerable<Command> Parse(string text)
        {
            return text.Split(Environment.NewLine)
                .Select(
                    (command) => this.ParseSingleCommand(command)
                );
        }

        public Command ParseSingleCommand(string text)
        {
            string[] tokens = text.Split(' ').Select(value => value.Trim().ToUpper()).ToArray();
            string command = tokens.First();

            switch (command)
            {
                case "PLACE":
                    return PlaceCommand.Parse(tokens);
                case "MOVE":
                    return MoveCommand.Parse(tokens);
                case "LEFT":
                    return LeftCommand.Parse(tokens);
                case "RIGHT":
                    return RightCommand.Parse(tokens);
            }

            throw new InvalidOperationException($"{command} was not recognized.");
        }
    }
}
