using System;
using System.IO;  // ADDED: Required for StreamWriter/StreamReader

namespace SwinAdventure
{
    public class Player : GameObject, IHaveInventory
    {
        private Inventory _inventory;

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

        public GameObject? Locate(string id)  // FIXED: Added nullable return type
        {
            if (AreYou(id))
            {
                return this;
            }
            else
            {
                return Inventory.Fetch(id);
            }
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
            string ItemDescriptionList = reader.ReadLine() ?? "";  // FIXED: Added null safety

            //display the information to Console
            Console.WriteLine("Player information");
            Console.WriteLine(Name);
            Console.WriteLine(ShortDescription);
            Console.WriteLine(ItemDescriptionList);
        }
    }
}