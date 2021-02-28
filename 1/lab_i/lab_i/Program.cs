using System;

namespace lab_i
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a, b and accuracy");
            string[] s = Console.ReadLine().Split();
            int a = Convert.ToInt32(s[0]);
            int b = Convert.ToInt32(s[1]);
            double acc = Convert.ToDouble(s[2]);
            double x0 = 0.5, xi, xi1;

            if (f(a) * f2(a) > 0) x0 = a;
            else if (f(b) * f2(b) > 0) x0 = b;

            xi = x0 - f(x0) / f(x0);

            while (Math.Abs(f(xi)) > acc)
            {
                xi1 = xi - f(xi) / f1(x0);
                xi = xi1;
            }
            Console.WriteLine("Answer = {0}", xi);
        }

        static double f(double x)
        {
            return Math.Pow(Math.Sin(x), 2) + 0.99 * Math.Pow(Math.Cos(x), 2) - 10 * x;
        }

        static double f1(double x)
        {
            return 0.02 * Math.Sin(x) * Math.Cos(x) - 10;
        }

        static double f2(double x)
        {
            return 0.02 * Math.Pow(Math.Cos(x), 2) - 0.02 * Math.Pow(Math.Sin(x), 2);
        }
    }
}
