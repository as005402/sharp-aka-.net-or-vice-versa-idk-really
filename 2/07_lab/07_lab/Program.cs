using System;
using System.IO;

namespace _07_lab
{
    class Program
    {
        static void Main(string[] args)
        {
            int n, c;
            int[] a, b;

            StreamReader fileIn = new StreamReader("Inlet.in");
            StreamWriter fileOut = new StreamWriter("Outlet.out");

            n = Convert.ToInt32(fileIn.ReadLine());
            a = new int[n];
            for (int i = 0; i < n; i++) a[i] = Convert.ToInt32(fileIn.ReadLine());
            fileIn.Close();

            int min = a[0];
            int max = a[0];
            foreach (int z in a)
            {
                if (z > max) max = z;
                if (z < min) min = z;
            }

            string s = Convert.ToString(Math.Abs(max - min));
            fileOut.Write(s);
            fileOut.Close();
        }
    }
}
