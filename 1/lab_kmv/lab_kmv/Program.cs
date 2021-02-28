using System;

namespace lab_kmv
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1. Find sum with some accuracy.\nEnter x (-1 < x < 1) and accuracy:");
            string[] s = Console.ReadLine().Split();
            double x = Convert.ToDouble(s[0]);
            double err = Convert.ToDouble(s[1]);
            double sum = 0;
            int n = 0;
            while (Math.Abs(Math.Pow(2 * x, 2 * n) / fact(2 * n)) > err)
            {
                sum += Math.Pow(-1, n) * (Math.Pow(2 * x, 2 * n) / fact(2 * n));
                n++;
            }
            Console.WriteLine("Answer = {0}\n\n", sum);

            Console.WriteLine("2. Find sum with some accuracy. (variant 1)\nEnter accuracy:");
            err = Convert.ToDouble(Console.ReadLine());
            sum = 0;
            n = 1;
            while (Math.Abs(n / fact(2 * n - 1)) > err)
            {
                sum += n / fact(2 * n - 1);
                n++;
            }
            Console.WriteLine("Answer = {0}\n\n", sum);

            Console.WriteLine("3. Find sum with some accuracy. (variant 10)\nEnter accuracy, x and y:");
            string[] s1 = Console.ReadLine().Split();
            err = Convert.ToDouble(s1[0]);
            double an = Convert.ToDouble(s1[1]), an1;
            double bn = Convert.ToDouble(s1[2]), bn1;
            sum = an + bn;
            double suma = an, sumb = bn;
            while (Math.Abs(an - bn) > err)
            {
                an1 = 0.5 * (an + bn);
                bn1 = Math.Sqrt(an * bn);
                an = an1; bn = bn1;
                sum += an + bn;
                suma += an;
                sumb += bn;
            }
            Console.WriteLine("Sum = {0}\nSum of an = {1}\nSum of bn = {2}\n", sum, suma, sumb);
        }

        static double fact(int num)
        {
            if (num == 0) return 1;
            else
            {
                int res = 1;
                for (int i = num; i > 1; i--) res *= i;
                return res;
            }
        }
    }
}
