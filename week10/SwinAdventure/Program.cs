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
            Console.WriteLine("=== SwinAdventure Game ===");
            Console.WriteLine("Welcome to SwinAdventure!");

            // Task 10.2 Requirement 1: Get player name and description from user
            Console.Write("Enter your name: ");
            string playerName = Console.ReadLine() ?? "Player";
            
            Console.Write("Enter your description: ");
            string playerDesc = Console.ReadLine() ?? "an adventurer";

            Player _testPlayer = new Player(playerName, playerDesc);

            // Task 10.2 Requirement 2: Create two items and add to player inventory
            Item item1 = new Item(new string[] { "silver", "hat" }, "A Silver Hat", "A very shiny silver hat");
            Item ruby = new Item(new string[] { "gem", "ruby" }, "A Ruby", "A bright pink ruby");
            
            _testPlayer.Inventory.Put(item1);
            _testPlayer.Inventory.Put(ruby);
            Console.WriteLine("Added silver hat and ruby to your inventory.");

            // Task 10.2 Requirement 3: Create bag and add to player inventory
            Bag _testToolBag = new Bag(new string[] { "bag", "tool" }, "Tools Bag", "A bag that contains tools");
            _testPlayer.Inventory.Put(_testToolBag);
            Console.WriteLine("Added tools bag to your inventory.");

            // Task 10.2 Requirement 4: Create item and add to bag
            Item pen = new Item(new string[] { "pen", "black" }, "A Black Pen", "A black ink pen");
            _testToolBag.Inventory.Put(pen);
            Console.WriteLine("Added black pen to the tools bag.");

            Console.WriteLine("\nYour current status:");
            Console.WriteLine(_testPlayer.FullDescription);

            // Task 10.2 Requirement 5: Command loop
            LookCommand cmd = new LookCommand();
            bool finished = false;
            
            Console.WriteLine("\n=== Command Interface ===");
            Console.WriteLine("Try commands like:");
            Console.WriteLine("- look at inventory");
            Console.WriteLine("- look at hat");
            Console.WriteLine("- look at gem");
            Console.WriteLine("- look at pen in bag");
            Console.WriteLine("- look at gem in inventory");
            Console.WriteLine("- exit (to quit)");
            Console.WriteLine();

            while (!finished)
            {
                Console.Write("Enter a command: ");
                string command = Console.ReadLine() ?? "";
                
                if (command.ToLower() == "exit")
                {
                    finished = true;
                    break;
                }
                
                string[] split = command.Split(' ');
                Console.WriteLine(cmd.Execute(_testPlayer, split));
                Console.WriteLine();
            }

            Console.WriteLine("Thanks for playing SwinAdventure!");

            // Task 9.2 polymorphism demonstration
            Console.WriteLine("\n=== Task 9.2 Polymorphism Demo ===");
            List<IHaveInventory> myContainers = new List<IHaveInventory>();

            myContainers.Add(_testPlayer);
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

            // Task 8.2 file operations
            Console.WriteLine("\n=== Task 8.2 File Operations ===");
            StreamWriter writer = new StreamWriter("TestPlayer.txt");
            try {
                _testPlayer.SaveTo(writer);
                Console.WriteLine("Player data saved to TestPlayer.txt");
            }
            finally
            {
                writer.Close();
            }
            
            StreamReader reader = new StreamReader("TestPlayer.txt");
            try {
                _testPlayer.LoadFrom(reader);
            }
            finally
            {
                reader.Close();
            }
        }
    }
}