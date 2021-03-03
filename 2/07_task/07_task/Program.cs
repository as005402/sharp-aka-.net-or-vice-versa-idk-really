using System;
using System.IO;

namespace _07_task
{
    class Program
    {

        static void Main(string[] args)
        {
            int n, c;
            int[] a, b;

            StreamReader fileIn = new StreamReader("Inlet.in");
            StreamWriter fileOut = new StreamWriter("Outlet.out");

            string[] s = fileIn.ReadLine().Split(' ');
            n = Convert.ToInt32(s[0]);
            c = Convert.ToInt32(s[1]);
            a = new int[n];
            for (int i = 0; i < n; i++) a[i] = Convert.ToInt32(fileIn.ReadLine());
            fileIn.Close();
            
            b = new int[1];
            for (int i = 1; i < a.Length; i++)
                if (c % i == 0) { Array.Resize(ref b, b.Length + 1); b[b.Length - 1] = a[i]; }

            s[0] = "";
            for (int i = 0; i < b.Length; i++)
                s[0] += " " + b[i];
            s[0] = s[0].Trim();
            fileOut.Write(s[0]);
            fileOut.Close();


        }
    }
}
