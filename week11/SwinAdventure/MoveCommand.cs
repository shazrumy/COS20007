using System;

namespace SwinAdventure
{
    // Move Command class - Task 11.2
    public class MoveCommand : Command
    {
        public MoveCommand() : base(new string[] { "move", "go", "head", "leave" })
        {
        }

        public override string Execute(Player p, string[] text)
        {
            // Must have exactly 2 words: command + direction
            if (text.Length != 2)
            {
                return "I don't know how to move like that";
            }

            // First word must be a valid move command
            if (!AreYou(text[0].ToLower()))
            {
                return "Error in move input";
            }

            string direction = text[1];

            // Check if player has a location
            if (p.Location == null)
            {
                return "You are not in any location to move from.";
            }

            // Try to find path in current location
            GamePath? path = p.Location.GetPath(direction);
            
            if (path == null)
            {
                return "You cannot go " + direction + " from here.";
            }

            // Move player to destination
            string currentLocationName = p.Location.Name;
            path.MovePlayer(p);
            
            return "You move " + direction + " from " + currentLocationName + 
                   " to " + p.Location.Name + ".";
        }
    }
}