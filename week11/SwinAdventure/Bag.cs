using System;

namespace SwinAdventure
{
    public class Bag : Item, IHaveInventory
    {
        private Inventory _inventory;

        public Bag(string[] ids, string name, string desc) : base(ids, name, desc)
        {
            _inventory = new Inventory();
        }

        public GameObject? Locate(string id)  // FIXED: Added nullable return type
        {
            if (_inventory.HasItem(id))
            {
                return _inventory.Fetch(id);
            }
            else if (AreYou(id))
            {
                return this;
            }
            else
            {
                return null;
            }
        }

        public Inventory Inventory
        {
            get { return _inventory; }
        }

        public override string FullDescription
        {
            get { return "In the " + Name + " you can see:\n" + Inventory.ItemList; }
        }
    }
}
