using System;

namespace EventWithoutArgs
{
    class EventWithoutArgs
    {
        public static void RunIt(string[] args)
        {
            Counter counter = new Counter(new Random().Next(10));
            // register a function
            counter.ThresholdReached += C_ThresholdReached;
            // register a lambda
            counter.ThresholdReached += (o, i) => {
                Console.WriteLine("The threshold was reached.");
                Environment.Exit(0);
            };


            Console.WriteLine("press 'a' key to increase total");
            while (Console.ReadKey(true).KeyChar == 'a')
            {
                Console.WriteLine("adding one");
                counter.Add(1);
            }
        }

        static void C_ThresholdReached(object sender, EventArgs e)
        {
            Console.WriteLine("The threshold was reached.");
            Environment.Exit(0);
        }
    }

    class Counter
    {

        public event EventHandler ThresholdReached;

        private int threshold;
        private int total;

        public Counter(int passedThreshold)
        {
            threshold = passedThreshold;
        }

        public void Add(int x)
        {
            total += x;
            if (total >= threshold)
            {
                OnThresholdReached(EventArgs.Empty);
            }
        }

        protected virtual void OnThresholdReached(EventArgs e)
        {
            ThresholdReached?.Invoke(this, e);
        }


    }
}
