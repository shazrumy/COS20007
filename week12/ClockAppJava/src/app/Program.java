package app;

import java.util.Scanner;

public class Program {

    public static void main(String[] args) {
        Clock clock = new Clock();
        Scanner scanner = new Scanner(System.in);
        
        System.out.println("Clock Interactive Demo");
        System.out.println("======================");
        System.out.println("Commands:");
        System.out.println("t - Tick (advance 1 second)");
        System.out.println("r - Reset clock to 00:00:00");
        System.out.println("s - Show current time");
        System.out.println("p - Performance test (10,000 ticks)");
        System.out.println("q - Quit");
        System.out.println();
        
        while (true) {
            System.out.print("Enter command: ");
            String input = scanner.nextLine().toLowerCase();
            
            switch (input) {
                case "t":
                    clock.tick();
                    System.out.println("Ticked! Current time: " + clock.getTime());
                    break;
                    
                case "r":
                    clock.reset();
                    System.out.println("Reset! Current time: " + clock.getTime());
                    break;
                    
                case "s":
                    System.out.println("Current time: " + clock.getTime());
                    break;
                    
                case "p":
                    System.out.println("Running performance test...");
                    long startTime = System.currentTimeMillis();
                    
                    for (int i = 0; i < 10000; i++) {
                        clock.tick();
                    }
                    
                    long endTime = System.currentTimeMillis();
                    System.out.println("Time after 10,000 ticks: " + clock.getTime());
                    System.out.println("Execution time: " + (endTime - startTime) + " ms");
                    
                    // Memory usage
                    Runtime runtime = Runtime.getRuntime();
                    runtime.gc(); // Suggest garbage collection
                    long memoryUsed = runtime.totalMemory() - runtime.freeMemory();
                    System.out.println("Memory used: " + memoryUsed + " bytes");
                    break;
                    
                case "q":
                    System.out.println("Goodbye!");
                    scanner.close();
                    return;
                    
                default:
                    System.out.println("Invalid command. Use t, r, s, p, or q");
                    break;
            }
            System.out.println();
        }
    }
}