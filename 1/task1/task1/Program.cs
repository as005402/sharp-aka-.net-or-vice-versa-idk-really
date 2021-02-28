using System;
using System.Collections.Generic;

namespace task1
{
    class Program
    {
        class Type1
        {
            private double num, xk, xk1;

            public Type1(double num)
            {
                this.num = num;

            }

            public double RootN(double n, double err)
            {
                xk = num / 2;
                while (true)
                {
                    xk1 = 1 / n * ((n - 1) * xk + num / Math.Pow(xk, n - 1));
                    if (Math.Abs(xk1 - xk) < err) break;
                    xk = xk1;
                }
                return xk1;
            }

            public double CheckRootN(double n)
            {
                return Math.Pow(num, 1 / n);
            }
        }



        class Type2
        {
            private int num;
            private string bin, bin1;
            List<int> b = new List<int> { };

            public Type2(int num)
            {
                this.num = num;
                bin1 = Convert.ToString(num, 2);
            }

            public string Binary()
            {
                return bin1;
            }

            public string MyBinary()
            {
                bin = "";
                while (num >= 1)
                {
                    b.Add(num % 2);
                    num /= 2;
                }
                for (int i = b.Count - 1; i >= 0; i--) bin += b[i];
                return bin;
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("1. Root of n-th power by Newton's method.\nEnter the number: ");
            double num = Convert.ToDouble(Console.ReadLine());
            Type1 n = new Type1(num);
            Console.WriteLine("Enter power and accuracy: ");
            string[] s = Console.ReadLine().Split(" ");
            double[] settings = new double[2];
            if (s.Length == 2) { settings[0] = double.Parse(s[0]); settings[1] = double.Parse(s[1]); }
            else { Array.Resize(ref s, 2); s[1] = Console.ReadLine(); settings[0] = double.Parse(s[0]); settings[1] = double.Parse(s[1]); }
            Console.WriteLine("{0} power root from {1} with accuracy {2} = {3}", num, settings[0], settings[1], n.RootN(settings[0], settings[1]));
            Console.WriteLine("//Real root = {0}\n", n.CheckRootN(settings[0]));


            Console.WriteLine("\n2. Binary representation of a number.\nEnter the number:");
            int num1 = Convert.ToInt32(Console.ReadLine());
            Type2 n1 = new Type2(num1);
            Console.WriteLine("{0} (10) = {1} (2)", num1, n1.MyBinary());
            Console.WriteLine("{0} (10) = {1} (2) /Check/\n", num1, n1.Binary());
        }
    }
}
