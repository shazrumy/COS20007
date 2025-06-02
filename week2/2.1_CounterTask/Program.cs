using System;


namespace CounterTask
{

    public class Mainclass
    {

        private static void PrintCounters(Counter[] counters)
        {

            foreach (Counter c in counters)
            {
                Console.WriteLine("{0} is {1}", c.Name, c.Ticks);
            }

        }
        public static void Main(string[] args)
        {
            
            Counter[] myCounter = new Counter[3];
            int i;

            myCounter[0] = new Counter("Counter 1");
            myCounter[1] = new Counter("Counter 2");
            myCounter[2] = myCounter[0];

            for(i=0; i <=9; i++)
            {
                myCounter[0].Increment();
            }
            for (i=0
                ; i <=14; i++)
            {
                myCounter[1].Increment();
            }
            PrintCounters(myCounter);

            Console.ReadLine();
            
            myCounter[2].Reset();

            PrintCounters(myCounter);


            Console.ReadLine();
        }
    }
}