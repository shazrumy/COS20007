package app;

import java.util.Random;

public class Clock {
    private Counter hour;
    private Counter min;
    private Counter sec;

    public Clock() {
        hour = new Counter("Hours");
        min = new Counter("Minutes");
        sec = new Counter("Seconds");
        
        // Start at a randomized time
        Random random = new Random();
        int randomHours = random.nextInt(24);    // 0-23 hours (24-hour format)
        int randomMinutes = random.nextInt(60);  // 0-59 minutes
        int randomSeconds = random.nextInt(60);  // 0-59 seconds
        
        System.out.println("Generated random values: " + randomHours + "h " + randomMinutes + "m " + randomSeconds + "s");
        
        // Set the random starting time by incrementing counters
        for (int i = 0; i < randomHours; i++) {
            hour.increment();
        }
        
        for (int i = 0; i < randomMinutes; i++) {
            min.increment();
        }
        
        for (int i = 0; i < randomSeconds; i++) {
            sec.increment();
        }
        
        // Display the random starting time AFTER it's been set
        System.out.println("Clock started at random time: " + getTime());
    }

    public void tick() {
        sec.increment();
        if (sec.getTicks() >= 60) {
            sec.reset();
            min.increment();
            if (min.getTicks() >= 60) {
                min.reset();
                hour.increment();
                if (hour.getTicks() >= 24) {
                    hour.reset();
                }
            }
        }
    }

    public String getTime() {
        return String.format("%02d:%02d:%02d", hour.getTicks(), min.getTicks(), sec.getTicks());
    }

    public void reset() {
        hour.reset();
        min.reset();
        sec.reset();
    }
}
