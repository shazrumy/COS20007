using System;
using System.Collections.Generic;

namespace SwinAdventure
{
    // Location class - Task 11.1 & 11.2
    public class Location : GameObject, IHaveInventory
    {
        private Inventory _inventory;
        private List<GamePath> _paths;

        public Location(string[] ids, string name, string desc) : base(ids, name, desc)
        {
            _inventory = new Inventory();
            _paths = new List<GamePath>();
        }

        public Inventory Inventory
        {
            get
            {
                return _inventory;
            }
        }

        // Task 11.2: Add path management
        public void AddPath(GamePath path)
        {
            _paths.Add(path);
        }

        public GamePath? GetPath(string direction)
        {
            foreach (GamePath path in _paths)
            {
                if (path.AreYou(direction))
                {
                    return path;
                }
            }
            return null;
        }

        public GameObject? Locate(string id)
        {
            if (AreYou(id))
            {
                return this;
            }
            else
            {
                return _inventory.Fetch(id);
            }
        }

        public override string FullDescription
        {
            get
            {
                string nameDescription;
                string inventoryDescription;

                if (Name != null && Name != "")
                {
                    nameDescription = Name;
                }
                else
                {
                    nameDescription = "an unknown location";
                }

                if (_inventory != null && _inventory.ItemList != null && _inventory.ItemList.Trim() != "")
                {
                    inventoryDescription = _inventory.ItemList;
                }
                else
                {
                    inventoryDescription = "there are no items at this location.";
                }

                return "You are in " + nameDescription + ". " +
                       base.FullDescription +
                       "\nHere, you can see:\n" + inventoryDescription;
            }
        }
    }
}
