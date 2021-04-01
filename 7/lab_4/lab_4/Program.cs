using System;
using System.Threading;

namespace lab_4
{
    class Program
    {
        static void Main(string[] args)
        {
            ICutDownNotifier[] classes = new ICutDownNotifier[3];
            timer[] t = new timer[3];

            Console.WriteLine("Name of the 1st timer:");
            t[0] = new timer(Console.ReadLine());
            Console.WriteLine("Time to wait (seconds)");
            classes[0] = new one(Convert.ToInt32(Console.ReadLine()));

            Console.WriteLine("Name of the 2nd timer:");
            t[1] = new timer(Console.ReadLine());
            Console.WriteLine("Time to wait (seconds)");
            classes[1] = new one(Convert.ToInt32(Console.ReadLine()));

            Console.WriteLine("Name of the 3rd timer:");
            t[2] = new timer(Console.ReadLine());
            Console.WriteLine("Time to wait (seconds)");
            classes[2] = new one(Convert.ToInt32(Console.ReadLine()));
            Console.WriteLine();

            for (int i = 0; i < classes.Length; i++)
            {
                classes[i].init(t[i]);
                classes[i].run(t[i]);
                Console.WriteLine();
            }

        }
    }

    public class timer
    {
        public delegate void timerStart(string source, string name);
        public event timerStart start;

        public delegate void timerLeft(string source, string name, int remain);
        public event timerLeft left;

        public delegate void timerEnd(string source, string name);
        public event timerEnd end;

        public string name { get; set; }

        public timer(string name)
        {
            this.name = name;
        }
        public void go(int wait)
        {
            start?.Invoke("timer", this.name);
            for (int i = wait; i > 0; i--)
            {
                //Console.WriteLine(i);
                Thread.Sleep(1000);
                left?.Invoke("timer", this.name, i);
            }
            end?.Invoke("timer", this.name);
            //Console.WriteLine($"Timer {this.name} is over");
        }
    }

    public interface ICutDownNotifier
    {
        void init(timer t);
        void run(timer t);
    }

    class one : ICutDownNotifier
    {
        int time;
        public one(int time)
        {
            this.time = time;
        }
        public void init(timer t)
        {
            t.start += toStart;
            t.left += toLeft;
            t.end += toEnd;
        }

        public void run(timer t) {
            t.go(time);
        }

        public void toStart(string source, string name)
        {
            Console.WriteLine($"Timer {name} (source: {source}) stareted");
        }

        private void toLeft(string source, string name, int remain)
        {
            Console.WriteLine($"Timer {name} (source: {source}) time left: {remain}");
        }

        private void toEnd(string source, string name)
        {
            Console.WriteLine($"Timer {name} (source: {source}) ended work");
        }

    }

    class two : ICutDownNotifier
    {
        int time;
        public two(int time)
        {
            this.time = time;
        }
        public void init(timer t)
        {
            t.start += delegate (string source, string name) { Console.WriteLine($"Timer {name} (source: {source}) stareted"); };
            t.left += delegate (string source, string name, int remain) { Console.WriteLine($"Timer {name} (source: {source}) time left: {remain}"); };
            t.end += delegate (string source, string name) { Console.WriteLine($"Timer {name} (source: {source}) ended work"); };
        }

        public void run(timer t)
        {
            t.go(time);
        }

    }

    class three : ICutDownNotifier
    {
        int time;
        public three(int time)
        {
            this.time = time;
        }
        public void init(timer t)
        {
            t.start += (string source, string name) => { Console.WriteLine($"Timer {name} (source: {source}) stareted"); };
            t.left += (string source, string name, int remain) => { Console.WriteLine($"Timer {name} (source: {source}) time left: {remain}"); };
            t.end += (string source, string name) => { Console.WriteLine($"Timer {name} (source: {source}) ended work"); };
        }

        public void run(timer t)
        {
            t.go(time);
        }

    }
}
