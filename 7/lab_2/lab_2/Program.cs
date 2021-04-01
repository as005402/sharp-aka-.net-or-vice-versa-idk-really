using System;
using System.Threading;

namespace lab_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Ping ping = new Ping();
            Pong pong = new Pong();

            Ping.hit pingHitted = pong.receive;
            Pong.hit pongHitted = ping.receive;

            ping.pong += pingHitted;
            pong.ping += pongHitted;

            ping.receive();
        }
        
    }

    class Ping
    {
        public delegate void hit();
        public event hit pong; 

        public void receive()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Ping received Pong.");
            Thread.Sleep(300);
            pong?.Invoke();
            Console.ResetColor();
        }
    }

    class Pong
    {
        public delegate void hit();
        public event hit ping;

        public void receive()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\tPong received Ping.");
            Thread.Sleep(300);
            ping?.Invoke();
            Console.ResetColor();
        }
    }
}
