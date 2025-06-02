using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CounterTask
{
    public class Counter
    {
        // enables Counter object to know its count and name values
        private long _count;
        private string _name;

        public Counter(string name)
        {
            _name = name;
            _count = 0;
        }

        public void Increment()
        {
            _count += 5;
            // step 13 change -> increase count value by 5
            // the code still runs without any bugs or crashed because I used += operator because it 
            // updates a variable by incrementing its value and reassigning it

        }

        public void Reset()
        {
            _count = 0;
        }
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        public long Ticks
        {
            get { return _count; }
        }
        public void ResetByDefault()
        {
            this._count = 21478360247;
            // ResetByDefault method for step 12. 1041000247 last digits of student ID are 0247. 
            // steps to implement this method; 
            // 1. added the ResetByDefault class, made into a public void so it can be accessed anywhere from the program
            // 2. changed the value of _count from int to long since the number 21478360247 is above capacity for int to be used. 
            // 3. used the this._count method to assign the value 21478360247 to the _count field 
        }

    }
}