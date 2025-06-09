using System;

namespace SwinAdventure
{
    // Look Command class - Task 10.1
    public class LookCommand : Command
    {
        public LookCommand() : base(new string[] { "look" })
        {
        }

        // Main execution method for look commands
        public override string Execute(Player p, string[] text)
        {
            // Must be either 3 or 5 elements
            if (text.Length != 3 && text.Length != 5)
            {
                return "I don't know how to look like that";
            }

            // First word must be "look"
            if (text[0].ToLower() != "look")
            {
                return "Error in look input";
            }

            // Second word must be "at"
            if (text[1].ToLower() != "at")
            {
                return "What do you want to look at?";
            }

            // If 5 elements, 4th word must be "in"
            if (text.Length == 5 && text[3].ToLower() != "in")
            {
                return "What do you want to look in?";
            }

            string itemId = text[2];
            IHaveInventory? container;

            if (text.Length == 3)
            {
                container = p;
            }
            else
            {
                string containerId = text[4];
                container = FetchContainer(p, containerId);
                
                if (container == null)
                {
                    return "I cannot find the " + containerId;
                }
            }

            return LookAtIn(itemId, container);
        }

        // Fetch container from player
        private IHaveInventory? FetchContainer(Player p, string containerId)
        {
            GameObject? obj = p.Locate(containerId);
            IHaveInventory? container = obj as IHaveInventory;
            return container;
        }

        // Look at item in specified container
        private string LookAtIn(string thingId, IHaveInventory container)
        {
            GameObject? item = container.Locate(thingId);
            
            if (item == null)
            {
                return "I cannot find the " + thingId + " in the " + container.Name;
            }
            
            return item.FullDescription;
        }
    }
}
