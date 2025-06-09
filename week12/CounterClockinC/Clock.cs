using System;

namespace ClockApp
{
    public class Clock
    {
        private Counter _hour;
        private Counter _min;
        private Counter _sec;

        public Clock()
        {
            _hour = new Counter("Hours");
            _min = new Counter("Minutes");
            _sec = new Counter("Seconds");
            
            // Start at a randomized time
            Random random = new Random();
            int randomHours = random.Next(0, 24);     // 0-23 hours (24-hour format)
            int randomMinutes = random.Next(0, 60);   // 0-59 minutes
            int randomSeconds = random.Next(0, 60);   // 0-59 seconds
            
            Console.WriteLine($"Generated random values: {randomHours}h {randomMinutes}m {randomSeconds}s");
            
            // Set the random starting time by incrementing counters
            for (int i = 0; i < randomHours; i++)
            {
                _hour.Increment();
            }
            
            for (int i = 0; i < randomMinutes; i++)
            {
                _min.Increment();
            }
            
            for (int i = 0; i < randomSeconds; i++)
            {
                _sec.Increment();
            }
            
            // Display the random starting time AFTER it's been set
            Console.WriteLine($"Clock started at random time: {GetTime()}");
        }

        public void Tick()
        {
            // Increment seconds first
            _sec.Increment();
            
            // Check if seconds reached 60 (1 minute)
            if (_sec.Ticks >= 60)
            {
                _sec.Reset();      // Reset seconds to 0
                _min.Increment();  // Increment minutes
                
                // Check if minutes reached 60 (1 hour)
                if (_min.Ticks >= 60)
                {
                    _min.Reset();      // Reset minutes to 0
                    _hour.Increment(); // Increment hours
                    
                    // Check if hours reached 24 (24-hour format)
                    if (_hour.Ticks >= 24)
                    {
                        _hour.Reset(); // Reset to 0 (00:00:00)
                    }
                }
            }
        }

        public string GetTime()
        {
            // 24-hour format: hh:mm:ss
            return string.Format("{0:D2}:{1:D2}:{2:D2}", 
                _hour.Ticks, _min.Ticks, _sec.Ticks);
        }

        public void Reset()
        {
            _hour.Reset();
            _min.Reset();
            _sec.Reset();
        }
    }
}