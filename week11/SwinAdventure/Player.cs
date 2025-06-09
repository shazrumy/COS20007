using System;
using System.IO;

namespace SwinAdventure
{
    public class Player : GameObject, IHaveInventory
    {
        private Inventory _inventory;
        private Location? _location;

        public Player(string name, string desc) : base(new string[] { "me", "inventory" }, name, desc)
        {
            _inventory = new Inventory();
        }

        public Inventory Inventory
        {
            get {
                return _inventory;
            }
        }

        // Task 11.1: Add Location property
        public Location? Location
        {
            get { return _location; }
            set { _location = value; }
        }

        // Task 11.1: Updated Locate method with 3-step search
        public GameObject? Locate(string id)
        {
            // Step 1: Check if player is what's being located
            if (AreYou(id))
            {
                return this;
            }
            
            // Step 2: Check player's inventory
            GameObject? inventoryResult = Inventory.Fetch(id);
            if (inventoryResult != null)
            {
                return inventoryResult;
            }
            
            // Step 3: Check current location
            if (_location != null)
            {
                return _location.Locate(id);
            }
            
            return null;
        }

        public override string FullDescription
        {
            get
            {
                return $"You are {Name}, {base.FullDescription}\nYou are carrying:\n{_inventory.ItemList}";
            }
        }

        public override void SaveTo(StreamWriter writer)
        {
            base.SaveTo(writer);
            writer.WriteLine(_inventory.ItemList);
        }

        public override void LoadFrom(StreamReader reader)
        {
            base.LoadFrom(reader);
            string ItemDescriptionList = reader.ReadLine() ?? "";

            Console.WriteLine("Player information");
            Console.WriteLine(Name);
            Console.WriteLine(ShortDescription);
            Console.WriteLine(ItemDescriptionList);
        }
    }
}