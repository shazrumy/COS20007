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
        }

        public string GetTime()
        {
            string h = _hour.Ticks.ToString("D2");
            string m = _min.Ticks.ToString("D2");
            string s = _sec.Ticks.ToString("D2");
            string time = h + ":" + m + ":" + s;

            return time;
        }

        public void Restart()
        {
            _hour.Reset();
            _min.Reset();
            _sec.Reset();
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
                    
                    // Check if hours reached 24 (1 day) - reset to 00:00:00
                    if (_hour.Ticks >= 24)
                    {
                        _hour.Reset(); // Reset hours to 0
                    }
                }
            }
        }
    }
}