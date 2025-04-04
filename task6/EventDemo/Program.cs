using System;

namespace EventDemo
{
    // Should ask about this to my mentor, "is it like kafka? "

    // 1. Define a delegate 
    // are these like (Kafka topics?)
    public delegate void ThresholdReachedEventHandler(object sender, EventArgs e);

    // 2. Create a class that raises the event
    class Counter
    {
        private int count;
        public int Threshold { get; }

        // 3. Declare the event using the delegate
        public event ThresholdReachedEventHandler ThresholdReached;

        public Counter(int threshold)
        {
            Threshold = threshold;
        }

        public void Increment()
        {
            count++;
            Console.WriteLine($"Counter: {count}");

            // 4. Raise the event if threshold reached
            if (count == Threshold)
            {
                OnThresholdReached();
            }
        }

        protected virtual void OnThresholdReached()
        {
            // Raise event safely (check if anyone subscribed)
            ThresholdReached?.Invoke(this, EventArgs.Empty);
        }
    }

    class Program
    {
        static void Main()
        {
            Counter counter = new Counter(5);

            // 5. Subscribe event handlers
            counter.ThresholdReached += OnThresholdReached;
            counter.ThresholdReached += AnotherReaction;

            for (int i = 0; i < 10; i++)
            {
                counter.Increment();
                System.Threading.Thread.Sleep(500); // pause for visibility
            }
        }

        // 6. Event handler methods
        static void OnThresholdReached(object sender, EventArgs e)
        {
            Console.WriteLine("Threshold reached! Action 1 triggered.");
        }

        static void AnotherReaction(object sender, EventArgs e)
        {
            Console.WriteLine("Threshold reached! Action 2 triggered.");
        }
    }
}
