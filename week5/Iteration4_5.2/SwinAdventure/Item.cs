using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace SwinAdventure
{
    // Item class represents objects the player can interact with
    public class Item : GameObject
    {
        // Constructor - creates an item with identifiers, name and description
        public Item(string[] ids, string name, string desc) : base(ids, name, desc)
        {
            // Base class handles all the setup
        }

        // Returns "a name (id)" format for items
        public override string ShortDescription
        {
            get
            {
                return $"a {Name} ({FirstID})";
            }
        }

        // Property for backward compatibility with old tests
        public string LongDescription
        {
            get
            {
                return FullDescription;
            }
        }
    }
}
