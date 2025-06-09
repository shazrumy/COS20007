using System;

namespace SwinAdventure
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            
            // Create a test player
            Player testPlayer = new Player("Shak", "an explorer");
            
            // Create some items to test with
            Item item1 = new Item(new string[] { "silver", "hat" }, "A Silver Hat", "A very shiny silver hat");
            Item item2 = new Item(new string[] { "light", "torch" }, "A Torch", "A torch to light the path");
            
            // Add the items into the player's inventory
            testPlayer.Inventory.Put(item1);
            testPlayer.Inventory.Put(item2);
            
            // Print the player identifiers
            Console.WriteLine($"Player responds to 'me': {testPlayer.AreYou("me")}");
            Console.WriteLine($"Player responds to 'inventory': {testPlayer.AreYou("inventory")}");
            
            // Test if player can locate torch
            if (testPlayer.Locate("torch") != null)
            {
                Console.WriteLine("The object torch exists");
                Console.WriteLine($"Inventory has torch: {testPlayer.Inventory.HasItem("torch")}");
            }
            else
            {
                Console.WriteLine("The object torch does not exist");
            }
            
            // Print the player's full description
            Console.WriteLine("\n" + testPlayer.FullDescription);
        }
    }
}
