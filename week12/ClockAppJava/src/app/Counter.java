package app;

public class Counter {
    private int count;
    private String name;

    public Counter(String name) {
        this.name = name;
        this.count = 0;
    }

    public void increment() {
        count++;
    }

    public void reset() {
        count = 0;
    }

    public int getTicks() {
        return count;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }
}