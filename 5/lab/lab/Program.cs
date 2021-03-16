using System;

namespace lab
{
    class Program
    {

        static double[][] formMatrix(int n1, int n2)
        {
            double[][] x = new double[n1][];
            for (int i = 0; i < n1; i++)
            {
                Console.WriteLine($"Enter the {i + 1} row of first matrix:");
                string[] str = Console.ReadLine().Trim().Split();
                x[i] = new double[str.Length];
                for (int j = 0; j < str.Length; j++)
                    x[i][j] = double.Parse(str[j]);
            }

            return x;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the size of first matrix:");
            string[] n1 = Console.ReadLine().Trim().Split();
            matrix m1 = new matrix(formMatrix(int.Parse(n1[0]), int.Parse(n1[1])));

            Console.WriteLine("\nEnter the size of second matrix:");
            string[] n2 = Console.ReadLine().Trim().Split();
            matrix m2 = new matrix(formMatrix(int.Parse(n2[0]), int.Parse(n2[1])));


            try
            {
                Console.WriteLine($"\nm1 + m2 = \n{m1 + m2}");
            } catch (WrongMatrixSizeException ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                Console.WriteLine($"m1 - m2 = \n{m1 - m2}");
            }
            catch (WrongMatrixSizeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            try
            {
                Console.WriteLine($"m1 * m2 = \n{m1 * m2}");
            }
            catch (WrongMatrixSizeException ex)
            {
                Console.WriteLine(ex.Message);
            }


        }
        }

        class matrix
        {
            private double[][] x;
            private int r, c;

            public matrix(double[][] x)
            {
                this.r = x.Length;
                this.c = x[0].Length;
                this.x = new double[r][];
                for (int i = 0; i < r; i++)
                {
                    this.x[i] = new double[c];
                    for (int j = 0; j < c; j++)
                        this.x[i][j] = x[i][j];
                }

            }

            static public matrix GetEmpty(int r, int c)
            {
                double[][] z = new double[r][];
                for (int i = 0; i < r; i++)
                {
                    z[i] = new double[c];
                    for (int j = 0; j < c; j++)
                        z[i][j] = 0;
                }
                matrix m = new matrix(z);
                return m;
            }

            public override string ToString()
            {
                string s = "";
                foreach (double[] b in x)
                {
                    foreach (double a in b)
                    {
                        s += Convert.ToString(a) + " ";
                    }
                    s += "\n";
                }
                return s;
            }

            static public matrix operator +(matrix m1, matrix m2)
            {
                if (m1.r != m2.r || m1.c != m2.c)
                {
                    throw new WrongMatrixSizeException($"\nError: \nCan't sum matricies with different sizes ({m1.r}x{m1.c} != {m2.r}x{m2.c})\n");
                }
                double[][] z = new double[m1.x.Length][];
                for (int i = 0; i < m1.r; i++)
                {
                    z[i] = new double[m1.c];
                    for (int j = 0; j < m1.c; j++) z[i][j] = m1.x[i][j] + m2.x[i][j];
                }
                matrix m = new matrix(z);
                return m;
            }

            static public matrix operator -(matrix m1, matrix m2)
            {
                if (m1.r != m2.r || m1.c != m2.c)
                {
                    throw new WrongMatrixSizeException($"\nError: \nCan't substract matricies with different sizes ({m1.r}x{m1.c} != {m2.r}x{m2.c})\n");
                }
                double[][] z = new double[m1.x.Length][];
                for (int i = 0; i < m1.r; i++)
                {
                    z[i] = new double[m1.c];
                    for (int j = 0; j < m1.c; j++) z[i][j] = m1.x[i][j] - m2.x[i][j];
                }
                matrix m = new matrix(z);
                return m;
            }

            static public matrix operator *(matrix m1, matrix m2)
            {
                if (m1.c != m2.r)
                {
                    throw new WrongMatrixSizeException($"\nError: \nCan't multiply matricies.\nThe number of columns of the first matrix must be equal to the number of rows of the second matrix ({m1.c} != {m2.r})\n");
                }
                double[][] z = new double[m1.x.Length][];
                for (int i = 0; i < m1.r; i++)
                {
                    z[i] = new double[m2.c];
                    for (int j = 0; j < m2.c; j++)
                    {
                        for (int k = 0; k < m1.c; k++)
                            z[i][j] += m1.x[i][k] * m2.x[k][j];
                    }
                }
                matrix m = new matrix(z);
                return m;
            }
        }
        [Serializable]
        public class WrongMatrixSizeException : ApplicationException
        {
            public WrongMatrixSizeException() { }
            public WrongMatrixSizeException(string message) : base(message) { }
            public WrongMatrixSizeException(string message, Exception ex) : base(message) { }

            protected WrongMatrixSizeException(System.Runtime.Serialization.SerializationInfo info,
                System.Runtime.Serialization.StreamingContext contex)
                : base(info, contex) { }
        }
    }