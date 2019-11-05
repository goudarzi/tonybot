using System;
using System.Linq;

namespace Tony.Commands
{
    public class MoveCommand
        : Command
    {
        public MoveCommand()
            : base()
        {
            this.Steps = null;
        }

        public MoveCommand(int steps)
            : this()
        {
            this.Steps = steps;
        }

        public int? Steps { get; }

        public static Command Parse(string[] tokens)
        {
            if (tokens.Length > 2)

                throw new InvalidOperationException($"{nameof(MoveCommand)} accepts no parameters.");

            if (tokens[0].ToUpper() != "MOVE")

                throw new InvalidOperationException($"Command {tokens[0]} cannot be parsed into {nameof(MoveCommand)}.");

            if (tokens.Length == 2)

                return new MoveCommand(int.Parse(tokens[1]));

            return new MoveCommand();
        }

        public override void Execute(IBot bot)
        {
            bot.Move(this.Steps ?? 1);
        }
    }
}