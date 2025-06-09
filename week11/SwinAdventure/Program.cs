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
            Console.WriteLine("=== SwinAdventure Game - Week 11 ===");
            Console.WriteLine("Welcome to SwinAdventure with Locations!");

            // Get player name and description from user
            Console.Write("Enter your name: ");
            string playerName = Console.ReadLine() ?? "Player";
            
            Console.Write("Enter your description: ");
            string playerDesc = Console.ReadLine() ?? "an adventurer";

            Player _testPlayer = new Player(playerName, playerDesc);

            // Task 11.1: Create locations
            Location startRoom = new Location(new string[] { "room", "start" }, "Starting Room", "A small room with stone walls");
            Location garden = new Location(new string[] { "garden", "outside" }, "Garden", "A beautiful garden with flowers");
            Location library = new Location(new string[] { "library", "books" }, "Library", "A quiet library filled with books");

            // Task 11.2: Create paths between locations
            GamePath northPath = new GamePath(new string[] { "north", "n" }, garden);
            GamePath southPath = new GamePath(new string[] { "south", "s" }, startRoom);
            GamePath eastPath = new GamePath(new string[] { "east", "e" }, library);
            GamePath westPath = new GamePath(new string[] { "west", "w" }, startRoom);

            // Add paths to locations - FIXED: Add all directions properly
            startRoom.AddPath(northPath);  // Start -> Garden (north)
            startRoom.AddPath(eastPath);   // Start -> Library (east)
            garden.AddPath(southPath);     // Garden -> Start (south)
            library.AddPath(westPath);     // Library -> Start (west)

            // Add more paths for testing - FIXED: Add south and west from starting room
            GamePath southFromStart = new GamePath(new string[] { "south", "s" }, garden); // Can go south to garden too
            GamePath westFromStart = new GamePath(new string[] { "west", "w" }, library);  // Can go west to library too
            startRoom.AddPath(southFromStart);
            startRoom.AddPath(westFromStart);

            // Set player's starting location
            _testPlayer.Location = startRoom;

            // Add items to player inventory
            Item item1 = new Item(new string[] { "silver", "hat" }, "A Silver Hat", "A very shiny silver hat");
            Item ruby = new Item(new string[] { "gem", "ruby" }, "A Ruby", "A bright pink ruby");
            _testPlayer.Inventory.Put(item1);
            _testPlayer.Inventory.Put(ruby);

            // Add items to locations
            Item book = new Item(new string[] { "book", "tome" }, "Ancient Book", "An old leather-bound book");
            Item flower = new Item(new string[] { "flower", "rose" }, "Red Rose", "A beautiful red rose");
            Item key = new Item(new string[] { "key", "brass" }, "Brass Key", "A shiny brass key");

            startRoom.Inventory.Put(key);
            garden.Inventory.Put(flower);
            library.Inventory.Put(book);

            Console.WriteLine("Game world created with multiple locations!");
            Console.WriteLine("You start in: " + startRoom.Name);

            // Command loop with both Look and Move commands
            LookCommand lookCmd = new LookCommand();
            MoveCommand moveCmd = new MoveCommand();
            bool finished = false;
            
            Console.WriteLine("\n=== Command Interface ===");
            Console.WriteLine("Available commands:");
            Console.WriteLine("- look (see current location)");
            Console.WriteLine("- look at [item]");
            Console.WriteLine("- look at [item] in [container]");
            Console.WriteLine("- move [direction], go [direction], head [direction], or leave [direction]");
            Console.WriteLine("- Directions: north, south, east, west");
            Console.WriteLine("- exit (to quit)");
            Console.WriteLine();

            // Show initial location
            Console.WriteLine("=== Current Location ===");
            Console.WriteLine(lookCmd.Execute(_testPlayer, new string[] { "look" }));
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
                string result = "";

                // Determine which command to execute
                if (split.Length > 0)
                {
                    string firstWord = split[0].ToLower();
                    
                    if (firstWord == "look")
                    {
                        result = lookCmd.Execute(_testPlayer, split);
                    }
                    else if (firstWord == "move" || firstWord == "go" || firstWord == "head" || firstWord == "leave")
                    {
                        result = moveCmd.Execute(_testPlayer, split);
                    }
                    else
                    {
                        result = "Unknown command. Try 'look', 'move [direction]', 'go [direction]', 'head [direction]', or 'leave [direction]'.";
                    }
                }
                else
                {
                    result = "Please enter a command.";
                }

                Console.WriteLine(result);
                Console.WriteLine();
            }

            Console.WriteLine("Thanks for playing SwinAdventure!");

            // Previous task demonstrations
            Console.WriteLine("\n=== Previous Tasks Still Work ===");
            
            // Task 9.2 polymorphism demonstration
            List<IHaveInventory> myContainers = new List<IHaveInventory>();
            myContainers.Add(_testPlayer);
            myContainers.Add(startRoom);

            foreach(IHaveInventory container in myContainers){
                if(container is Location){
                    Console.WriteLine("This is a location");
                    Location loc = (Location)container;
                    Console.WriteLine($"Location Name: {loc.Name}");
                }
                if(container is Player){
                   Console.WriteLine("This is a player");
                   Player player = (Player)container;
                   Console.WriteLine($"Player Name: {player.Name}");
                }
                Console.WriteLine("---");
            }

            // Task 8.2 file operations
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