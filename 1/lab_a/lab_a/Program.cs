using System;

namespace lab_a
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1. Find the sum of k-th terms\nEnter k:");
            int k = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter x:");
            double x = Convert.ToInt32(Console.ReadLine());
            double sum = 0;
            for (int i = 0; i <= k; i++)
            {
                sum += Math.Pow(-1, i) * ((2 * Math.Pow(i, 2) + 1) / fact(2 * i) * Math.Pow(x, 2 * i));
            }
            Console.WriteLine("Sum = {0}\n", sum);
        }

        static double fact(int num)
        {
            int res = 1;
            for (int i = num; i > 1; i--) res *= i;
            return res;
        }
    }
}
