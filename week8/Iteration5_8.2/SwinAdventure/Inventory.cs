using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace SwinAdventure
{
    // Inventory class manages a collection of Item objects
    public class Inventory
    {
        // Private field to store the list of items in the inventory
        private List<Item> _items;

        // Constructor - creates an empty inventory
        public Inventory()
        {
            _items = new List<Item>();
        }

        // Checks if an item with the given identifier exists in the inventory
        public bool HasItem(string id)
        {
            // Search through all items to find a match
            foreach (Item i in _items)
            {
                // Use the item's AreYou method to check if it matches the ID
                if (i.AreYou(id))
                {
                    return true;
                }
            }
            // No matching item found
            return false;
        }

        // Adds an item to the inventory
        public void Put(Item itm)
        {
            _items.Add(itm);
        }

        // Removes and returns an item by its identifier (null if not found)
        public Item? Take(string id)
        {
            // First locate the item using Fetch
            Item? takeitem = this.Fetch(id);
            
            // Only remove the item if it was found
            if (takeitem != null)
            {
                _items.Remove(takeitem);
            }
            
            // Return the item (or null if not found)
            return takeitem;
        }

        // Finds and returns an item by its identifier without removing it (null if not found)
        public Item? Fetch(string id)
        {
            // Search through all items in the inventory
            foreach (Item i in _items)
            {
                // Check if this item matches the given identifier
                if (i.AreYou(id))
                {
                    return i;
                }
            }
            // Item not found, return null
            return null;
        }

        // STEP 13: Modified ItemList property exactly as shown in PDF
    // STEP 13: Modified ItemList property - OPTION 1 for tests
        public string ItemList
        {
            get
            {
                string list = String.Empty;
                // Option 1: separate list elements by a new line
                foreach (Item itm in _items)
                {
                    list = list + "\t" + itm.ShortDescription + "\n";
                }
                return list;
            }
        }        
    }
}
