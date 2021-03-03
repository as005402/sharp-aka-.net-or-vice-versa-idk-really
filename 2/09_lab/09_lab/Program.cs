using System;
using System.IO;

namespace _09_lab
{
    class Program
    {

        static StreamReader fileIn = new StreamReader("Inlet.in");
        static StreamWriter fileOut = new StreamWriter("Outlet.out");
        static void Main(string[] args)
        {
            string[][] a = new string[1][];
            int i = 1;
            a[0] = fileIn.ReadLine().Split(' ');

            while (!fileIn.EndOfStream)
            {
                Array.Resize(ref a, a.Length + 1);
                a[i] = fileIn.ReadLine().Split(' ');
                i++;
            }
            fileIn.Close();

            string check = a[i - 1][a[i - 1].Length - 1];
            a[i - 1][a[i - 1].Length - 1] = "";
            int k = 0;

            foreach (string[] ai in a)
                foreach (string aj in ai)
                    if (aj.LastIndexOf(check) == aj.Length - check.Length) k++;

            if (k == 0) k = -1;

            fileOut.WriteLine(Convert.ToString(k));
            fileOut.Close();
        }
    }
}
