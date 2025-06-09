using System;

namespace SwinAdventure
{
    // Abstract base class for all commands - Task 10.1
    public abstract class Command : IdentifiableObject
    {
        public Command(string[] ids) : base(ids)
        {
        }

        public abstract string Execute(Player p, string[] text);
    }
}
