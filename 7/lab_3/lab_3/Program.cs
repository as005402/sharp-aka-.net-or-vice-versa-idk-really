using System;
using System.Threading;

namespace lab_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Number of events:");
            int count = Convert.ToInt32(Console.ReadLine());
            eventGenerator generator = new eventGenerator(count);
            generator.generation += (object sender, EventArgs e) => { Console.WriteLine("Event generated"); };
            generator.generate();
        }
    }
    public class eventGenerator
    {
        public event EventHandler generation;
        int count { get; set; }

        public eventGenerator(int count)
        {
            this.count = count;
        }
        public void generate()
        {
            while (count > 0)
            {
                generation?.Invoke(this, EventArgs.Empty);
                count--;
                Thread.Sleep(1000);
            }

        }
    }
}
