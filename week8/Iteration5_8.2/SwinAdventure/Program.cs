using System;
using System.IO;

namespace SwinAdventure
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Create a test player
            Player testPlayer = new Player("James", "an explorer");
            
            // Create some items to test with
            Item item1 = new Item(new string[] { "silver", "hat" }, "A Silver Hat", "A very shiny silver hat");
            Item item2 = new Item(new string[] { "light", "torch" }, "A Torch", "A torch to light the path");
            
            // Add the items into the player's inventory
            testPlayer.Inventory.Put(item1);
            testPlayer.Inventory.Put(item2);

            //write the PlayerObject to file
            StreamWriter writer = new StreamWriter("TestPlayer.txt");
            try
            {
                testPlayer.SaveTo(writer);
            }
            finally
            {
                writer.Close();
            }

            //read from the file
            StreamReader reader = new StreamReader("TestPlayer.txt");
            try
            {
                testPlayer.LoadFrom(reader);
            }
            finally
            {
                writer.Close();
            }
        }
    }
}
