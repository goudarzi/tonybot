using System;

namespace Tony.Commands
{
    public class LeftCommand : Command
    {
        public static Command Parse(string[] tokens)
        {
            return new LeftCommand();
        }

        public override void Execute(IBot bot)
        {
            bot.Left();
        }
    }
}