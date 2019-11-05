using System;

namespace Tony.Commands
{
    public class RightCommand
        : Command
    {
        public static Command Parse(string[] tokens)
        {
            return new RightCommand();
        }

        public override void Execute(IBot bot)
        {
            bot.Right();
        }
    }
}