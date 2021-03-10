using System;
using System.IO;

namespace _08_lab
{
    class Program
    {
        static StreamReader fileIn = new StreamReader("Inlet.in");
        static StreamWriter fileOut = new StreamWriter("Outlet.out");
        static void Main(string[] args)
        {
            int n, m;
            int[][] a;

            string[] s = fileIn.ReadLine().Split(' ');
            n = Convert.ToInt32(s[0]);
            m = Convert.ToInt32(s[1]);
            a = new int[n][];
            for (int i = 0; i < n; i++)
            {
                a[i] = new int[m];
                s = fileIn.ReadLine().Trim().Split(' ');
                int[] tmp = new int[m];
                for (int j = 0; j < m; j++)
                    tmp[j] = Convert.ToInt32(s[j]);
                a[i] = tmp;
            }
            fileIn.Close();

            int sum = 0;
            s[0] = "";

            for (int i = 1; i < a.Length; i += 2)
            {
                for (int j = 0; j < a[i].Length; j += 2) sum += a[i][j];
                s[0] += Convert.ToString(sum) + " ";
                sum = 0;
            }

            s[0] = s[0].Trim();
            fileOut.WriteLine(s[0]);
            fileOut.Close();
        }
    }
}
