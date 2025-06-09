using System;
using System.Collections.Generic;
using System.IO;
using SwinAdventure;
 
namespace MainProgram
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Player _testPlayer;
            _testPlayer = new Player("James", "an explorer");

            Item item1 = new Item(new string[] { "silver", "hat" }, "A Silver Hat", "A very shiny silver hat");
            Item item2 = new Item(new string[] { "light", "torch" }, "A Torch", "A Torch to light the path");

            //create a new inventory and add two items into it
            //Inventory _playerInventory = new Inventory();
            //_playerInventory.Put(item1);
            //_playerInventory.Put(item2);
            //_playerInventory.HasItem("light");

            //fetch an item from the inventory
            //Item fetchedItem = _playerInventory.Fetch("hat");
            //Console.WriteLine(fetchedItem == item1);

            //add the items into the player's inventory
            _testPlayer.Inventory.Put(item1);
            _testPlayer.Inventory.Put(item2);

            //Print the player Identifiers
            Console.WriteLine(_testPlayer.AreYou("me"));
            Console.WriteLine(_testPlayer.AreYou("inventory"));

            if(_testPlayer.Locate("torch") != null){
                Console.WriteLine("The object torch exists");
                Console.WriteLine(_testPlayer.Inventory.HasItem("torch"));
            } else{
                Console.WriteLine("The object torch does not exist");
            }

           

           

            List<IHaveInventory> myContainers = new List<IHaveInventory>();

            myContainers.Add(_testPlayer);

            //define a bag object and an item, then add the item into the inventory of the bag.
            Bag _testToolBag;
            _testToolBag = new Bag(new string[] { "bag", "tool" }, "Tools Bag", "A bag that contains tools");
            Item _testItem2;
            _testItem2 = new Item(new string[] { "stew", "beef" }, "A Beef Stew", "A hearty beef stew");

            _testToolBag.Inventory.Put(_testItem2);
        
            myContainers.Add(_testToolBag);

            foreach(IHaveInventory container in myContainers){
                if(container is Bag){
                    Console.WriteLine("This is a bag");
                    Bag bag = (Bag)container;
                    Console.WriteLine($"Bag Name: {bag.Name}");
                    Console.WriteLine($"Bag Description: {bag.FullDescription}");
                }
                if(container is Player){
                   Console.WriteLine("This is a player");
                   Player player = (Player)container;
                   Console.WriteLine($"Player Name: {player.Name}");
                   Console.WriteLine($"Player Description: {player.FullDescription}");
                }
                Console.WriteLine("---");
            }

            //write the PlayerObject to file
            StreamWriter writer = new StreamWriter("TestPlayer.txt");
            try {
                _testPlayer.SaveTo(writer);
            }
            finally
            {
                writer.Close();
            }
            
            
            //read from the file
            StreamReader reader = new StreamReader("TestPlayer.txt");
            try {
                _testPlayer.LoadFrom(reader);
            }
            finally
            {
                reader.Close(); // FIXED: Should close reader, not writer
            }
        }
    }
}