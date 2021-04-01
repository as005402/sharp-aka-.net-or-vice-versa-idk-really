using System;

namespace lab_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<Func<int>, char> act = delegate (Func<int> fun, char ch) { Console.WriteLine($"This action delegate gets Func<int>, that has no parameters but returns int value so it returns random number {fun.Invoke()}, and char that I can't connect with Func so it also returns random character {ch}.\nBut it works!!!"); };
            Func<int> fun = () => { return 21 * 12; };

            act?.Invoke(fun, 'F');
        }
    }
}
