using System;

namespace EventWithArgs
{
    public static class EventWithArgs
    {
        public static void RunIt(string[] args)
        {
            Counter c = new Counter(new Random().Next(10));
            c.ThresholdReached += C_ThresholdReached;

            Console.WriteLine("press 'a' key to increase total");
            while (Console.ReadKey(true).KeyChar == 'a')
            {
                Console.WriteLine("adding one");
                c.Add(1);
            }
        }

        static void C_ThresholdReached(object sender, ThresholdReachedEventArgs e)
        {
            Console.WriteLine("The threshold of {0} was reached at {1}.", e.Threshold, e.TimeReached);
            Environment.Exit(0);
        }
    }

    class Counter
    {
        public event EventHandler<ThresholdReachedEventArgs> ThresholdReached;

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
                ThresholdReachedEventArgs args = new ThresholdReachedEventArgs
                {
                    Threshold = threshold,
                    TimeReached = DateTime.Now
                };
                OnThresholdReached(args);
            }
        }

        protected virtual void OnThresholdReached(ThresholdReachedEventArgs e)
        {
            ThresholdReached?.Invoke(this, e);
        }

        
    }

    public class ThresholdReachedEventArgs : EventArgs
    {
        public int Threshold { get; set; }
        public DateTime TimeReached { get; set; }
    }
}

