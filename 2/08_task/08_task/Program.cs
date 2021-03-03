using System;
using System.IO;

namespace _08_task
{
    class Program
    {
        static StreamReader fileIn = new StreamReader("Inlet.in");
        static StreamWriter fileOut = new StreamWriter("Outlet.out");
        static void inp(out int n, out int m, out int[][] a)
        {
            string[] num = fileIn.ReadLine().Split(' ');
            n = Convert.ToInt32(num[0]);
            m = Convert.ToInt32(num[1]);
            a = new int[n][];
            for (int i = 0; i < n; i++)
                a[i] = new int[m];
            for (int i = 0; i < n; i++)
            {
                num = fileIn.ReadLine().Trim().Split(' ');
                int[] tmp = new int[m];
                for (int j = 0; j < m; j++)
                    tmp[j] = Convert.ToInt32(num[j]);
                a[i] = tmp;
            }
            fileIn.Close();
        }
        static int minElemRow(int i, int[][] a)
        {
            int min1 = a[i][0];
            int minRow = i;
            for (int j = i + 1; j < a.Length; j++)
                if (min1 > a[j][0])
                {
                    min1 = a[j][0];
                    minRow = j;
                }
            return minRow;
        }
        static void fix(ref int[][] a)
        {
            int[] b = new int[a[0].Length];
            for (int i = 0; i < a.Length - 1; i++)
            {
                int j = minElemRow(i, a);
                if (i != j)
                {
                    b = a[i];
                    a[i] = a[j];
                    a[j] = b;
                }
            }
        }
        static void outp(int[][] b)
        {
            for (int i = 0; i < b.Length; i++)
            {
                string s = "";
                for (int j = 0; j < b[i].Length; j++)
                    s += " " + b[i][j];
                s = s.Trim();
                fileOut.WriteLine(s);
            }
            fileOut.Close();
        }
        static void Main(string[] args)
        {
            int n, m;
            int[][] a;
            inp(out n, out m, out a);
            fix(ref a);
            outp(a);
        }
    }
}
