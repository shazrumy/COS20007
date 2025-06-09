using System;
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

            // Simple demonstration of Bag functionality (Task 9.1)
            Console.WriteLine("\n=== Bag Demonstration ===");
            Bag _testToolBag = new Bag(new string[] { "bag", "tool" }, "Tools Bag", "A bag that contains tools");
            Item _testItem2 = new Item(new string[] { "stew", "beef" }, "A Beef Stew", "A hearty beef stew");

            _testToolBag.Inventory.Put(_testItem2);
            
            Console.WriteLine("Bag can locate itself:");
            Console.WriteLine(_testToolBag.Locate("bag") != null);
            
            Console.WriteLine("Bag can locate items in its inventory:");
            Console.WriteLine(_testToolBag.Locate("stew") != null);
            
            Console.WriteLine("Bag full description:");
            Console.WriteLine(_testToolBag.FullDescription);

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