using System;
using System.Diagnostics;

namespace ClockApp
{
    public class Program
    {
        private static void Main(string[] args)
        {
            Clock MyClock = new Clock();
            
            Console.WriteLine("Clock Interactive Demo");
            Console.WriteLine("======================");
            Console.WriteLine("Commands:");
            Console.WriteLine("t - Tick (advance 1 second)");
            Console.WriteLine("r - Reset clock to 00:00:00");
            Console.WriteLine("s - Show current time");
            Console.WriteLine("p - Performance test (10,000 ticks)");
            Console.WriteLine("q - Quit");
            Console.WriteLine();
            
            while (true)
            {
                Console.Write("Enter command: ");
                string? input = Console.ReadLine()?.ToLower();
                
                switch (input)
                {
                    case "t":
                        MyClock.Tick();
                        Console.WriteLine("Ticked! Current time: " + MyClock.GetTime());
                        break;
                        
                    case "r":
                        MyClock.Reset();
                        Console.WriteLine("Reset! Current time: " + MyClock.GetTime());
                        break;
                        
                    case "s":
                        Console.WriteLine("Current time: " + MyClock.GetTime());
                        break;
                        
                    case "p":
                        Console.WriteLine("Running performance test...");
                        Stopwatch stopwatch = Stopwatch.StartNew();
                        for (int i = 0; i < 10000; i++)
                        {
                            MyClock.Tick();
                        }
                        stopwatch.Stop();
                        
                        Console.WriteLine("Time after 10,000 ticks: " + MyClock.GetTime());
                        Console.WriteLine("Execution time: " + stopwatch.ElapsedMilliseconds + " ms");
                        
                        Process process = Process.GetCurrentProcess();
                        Console.WriteLine("Memory usage: " + (process.WorkingSet64 / 1024 / 1024) + " MB");
                        break;
                        
                    case "q":
                        Console.WriteLine("Goodbye!");
                        return;
                        
                    default:
                        Console.WriteLine("Invalid command. Use t, r, s, p, or q");
                        break;
                }
                Console.WriteLine();
            }
        }
    }
}