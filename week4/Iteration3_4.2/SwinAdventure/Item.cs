using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace SwinAdventure
{
    // Item class inherits from IdentifiableObject for game objects
    public class Item : IdentifiableObject
    {
        // Private fields to store item properties
        private string _description, _name;

        // Constructor: creates item with identifiers, name, and description
        public Item(string[] ids, string name, string desc) : base(ids)
        {
            _name = name;
            _description = desc;
        }

        // Returns the item's name
        public string Name
        {
            get
            {
                return _name;
            }
        }

        // Returns the full description of the item
        public string LongDescription
        {
            get
            {
                return _description;
            }
        }

        // Returns brief description with name and first identifier
        public string ShortDescription
        {
            get
            {
                return $"a {_name} ({FirstID})";
            }
        }

        // Inherited methods from IdentifiableObject:
        // - AreYou(string id) : bool - checks if item matches identifier
        // - FirstID : string - returns first identifier or empty string
        // - AddIdentifier(string id) - adds new identifier to list
        // - RemoveIdentifier(string id) - removes identifier from list
        // - PrivilegeEscalation(string pin) - replaces first ID if PIN matches
    }
}