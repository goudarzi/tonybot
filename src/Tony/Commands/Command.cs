using System;
using System.Collections.Generic;
using System.Text;

namespace Tony.Commands
{
    public abstract class Command
    {
        public abstract void Execute(IBot bot);
    }
}
