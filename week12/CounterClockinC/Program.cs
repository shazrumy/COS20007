using System;
using System.Diagnostics;

namespace ClockApp
{
    public class Program
    {
        private static void Main(string[] args)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            Clock MyClock = new Clock();
            for (int i = 0; i < 10000; i++)
            {
                MyClock.Tick();
            }
            stopwatch.Stop();

            Console.WriteLine("Time after 10,000 ticks: " + MyClock.GetTime());
            Console.WriteLine("Execution time: " + stopwatch.ElapsedMilliseconds + " ms");
            
            MyClock.Restart();
            Console.WriteLine("Time after restart: " + MyClock.GetTime());

            Process process = Process.GetCurrentProcess();
            Console.WriteLine("Memory usage: " + (process.WorkingSet64 / 1024 / 1024) + " MB");
        }
    }
}