using System;

namespace lab
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Console.WriteLine("Enter coordinates of 1st point:");
            string[] s = Console.ReadLine().Trim().Split();
            double[] v = new double[s.Length];
            for (int i = 0; i < s.Length; i++) v[i] = Convert.ToDouble(s[i]);
            vector v1 = new vector(v[0], v[1], v[2]);
            Console.WriteLine($"\tFirst vector's equation = {v1}");

            Console.WriteLine("Enter coordinates of 2nd point:");
            s = Console.ReadLine().Trim().Split();
            for (int i = 0; i < s.Length; i++) v[i] = Convert.ToDouble(s[i]);
            vector v2 = new vector(v[0], v[1], v[2]);
            Console.WriteLine($"\tSecond vector's equation = {v2}");

            Console.WriteLine($"\tv1 + v2 = {v1 + v2}");
            Console.WriteLine($"\tv1  v2 = {v1 - v2}");
            Console.WriteLine($"\tv1 * v2 = {v1 * v2} (scalar)\nEnter any number:");
            double n = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine($"\tv1 * {n} = {v1 * n}");
            Console.WriteLine($"\tv1 / {n} = {v1 / n}");
            Console.WriteLine($"\tMagnitude of v1 = {v1.magnitude()}");
            Console.WriteLine($"\tUnit vector in the direction of v1 = {v1.unit()}");*/

            Console.WriteLine("Enter first polinomial:\t\t(Ex. -4x^2 + 12)");
            polinom p1 = new polinom(Console.ReadLine());
            Console.WriteLine("Enter second polinomial:");
            polinom p2 = new polinom(Console.ReadLine());
            Console.WriteLine($"p1 + p2 = {p1 + p2}");
            Console.WriteLine($"p1 * p2 = {p1 * p2}");
        }
    }

    class vector
    {
        public double x, y, z;

        public vector(double x = 0, double y = 0, double z = 0)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public override string ToString()
        {
            return Convert.ToString(x) + "i" + (y >= 0 ? " + " + Convert.ToString(y) : " - " + Convert.ToString(y * -1)) + "j" + (z >= 0 ? " + " + Convert.ToString(z) : " - " + Convert.ToString(z * -1)) + "k";
        }

        public static vector operator +(vector v1, vector v2)
        {
            vector v = new vector();
            v.x = v1.x + v2.x;
            v.y = v1.y + v2.y;
            v.z = v1.z + v2.z;
            return v;
        }

        public static vector operator -(vector v1, vector v2)
        {
            vector v = new vector();
            v.x = v1.x - v2.x;
            v.y = v1.y - v2.y;
            v.z = v1.z - v2.z;
            return v;
        }

        public static vector operator *(vector v1, double n)
        {
            vector v = new vector();
            v.x = v1.x * n;
            v.y = v1.y * n;
            v.z = v1.z * n;
            return v;
        }

        public static vector operator *(vector v1, vector v2)
        {
            vector v = new vector();
            v.x = v1.x * v2.x;
            v.y = v1.y * v2.y;
            v.z = v1.z * v2.z;
            return v;
        }

        public static vector operator /(vector v1, double n)
        {
            vector v = new vector();
            v.x = v1.x / n;
            v.y = v1.y / n;
            v.z = v1.z / n;
            return v;
        }

        public double magnitude()
        {
            return Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2) + Math.Pow(z, 2));
        }

        public vector unit()
        {
            return this / magnitude();
        }

    }



    class polinom
    {
        string[] s, s1;
        double[][] x = new double[0][];

        public polinom(double[][] x)
        {
            for (int i = 0; i < x.Length; i++)
            {
                Array.Resize(ref this.x, this.x.Length + 1);
                this.x[i] = new double[2];

                this.x[i][0] = x[i][0];
                this.x[i][1] = x[i][1];
            }
        }
        public polinom(string s)
        {
            this.s = s.Split("+");
            int z = 0;

            for (int i = 0; i < this.s.Length; i++)
            {
                this.s[i] = this.s[i].Trim();

                if (this.s[i].IndexOf('-') == -1)
                {
                    if (this.s[i].IndexOf('x') == -1)
                    {
                        Array.Resize(ref x, x.Length + 1);
                        x[z] = new double[2];

                        x[z][0] = Convert.ToDouble(this.s[i]);
                        x[z][1] = 0;
                        z++;
                    }
                    else
                    {
                        Array.Resize(ref x, x.Length + 1);
                        x[z] = new double[2];

                        if (this.s[i].IndexOf('x') == 0) x[z][0] = 1;
                        else x[z][0] = Convert.ToDouble(this.s[i].Substring(0, this.s[i].IndexOf('x')));

                        if (this.s[i].IndexOf('^') == -1) x[z][1] = 1;
                        else x[z][1] = Convert.ToDouble(this.s[i].Substring(this.s[i].IndexOf('^') + 1));

                        z++;
                    }

                }
                else
                {

                    s1 = this.s[i].Split('-');
                    s1[0] = s1[0].Trim();

                    if (s1[0].IndexOf('x') == -1)
                    {
                        if (s1[0] != " " && s1[0] != "")
                        {
                            Array.Resize(ref x, x.Length + 1);
                            x[z] = new double[2];
                            x[z][0] = Convert.ToDouble(s1[0]);
                            x[z][1] = 0;
                            z++;
                        }
                        
                    }
                    else
                    {
                        Array.Resize(ref x, x.Length + 1);
                        x[z] = new double[2];
                        if (s1[0].IndexOf('x') == 0) x[z][0] = 1;
                        else x[z][0] = Convert.ToDouble(s1[0].Substring(0, s1[0].IndexOf('x')));

                        if (s1[0].IndexOf('^') == -1) x[z][1] = 1;
                        else x[z][1] = Convert.ToDouble(s1[0].Substring(s1[0].IndexOf('^') + 1));

                        z++;
                    }

                    for (int j = 1; j < s1.Length; j++)
                    {
                        if (s1[j].IndexOf('x') == -1)
                        {
                            Array.Resize(ref x, x.Length + 1);
                            x[z] = new double[2];
                            x[z][0] = Convert.ToDouble(s1[j]) * -1;
                            x[z][1] = 0;
                            z++;
                        }
                        else
                        {
                            s1[j] = s1[j].Trim();
                            Array.Resize(ref x, x.Length + 1);
                            x[z] = new double[2];

                            if (s1[j].IndexOf('x') == 0) x[z][0] = -1;
                            else x[z][0] = Convert.ToDouble(s1[j].Substring(0, s1[j].IndexOf('x'))) * -1;

                            if (s1[j].IndexOf('^') == -1) x[z][1] = 1;
                            else x[z][1] = Convert.ToDouble(s1[j].Substring(s1[j].IndexOf('^') + 1));

                            z++;
                        }
                    }

                }
            }
        }

        public static polinom operator *(polinom p1, polinom p2)
        {
            double[][] z = new double[0][];
            int n = 0;

            for (int i = 0; i < p1.x.Length; i++)
            {
                for (int j = 0; j < p2.x.Length; j++)
                {
                    Array.Resize(ref z, z.Length + 1);
                    z[n] = new double[2];
                    
                    z[n][0] = p1.x[i][0] * p2.x[j][0];
                    z[n][1] = p1.x[i][1] + p2.x[j][1];

                    n++;
                }
            }

            polinom p = new polinom(z);
            return p;
        }

        public static polinom operator +(polinom p1, polinom p2)
        {
            double[][] z = new double[0][];
            int n = 0;
            bool f1 = false;
            bool[] f2 = new bool[p2.x.Length];
            for (int i = 0; i < f2.Length; i++) f2[i] = false;


            for (int i = 0; i < p1.x.Length; i++)
            {
                for (int j = 0; j < p2.x.Length; j++)
                {
                    if (p1.x[i][1] == p2.x[j][1])
                    {
                        Array.Resize(ref z, z.Length + 1);
                        z[n] = new double[2];

                        z[n][0] = p1.x[i][0] + p2.x[j][0];
                        z[n][1] = p1.x[i][1];

                        n++;
                        f1 = true;
                        f2[j] = true;
                        break;
                    }
                    
                }
                if (!f1) {
                    Array.Resize(ref z, z.Length + 1);
                    z[n] = new double[2];
                    z[n][0] = p1.x[i][0]; 
                    z[n][1] = p1.x[i][1];
                    n++;
                } else f1 = false;
                
            }
            for (int i = 0; i < f2.Length; i++)
            {
                if (f2[i] == false)
                {
                    Array.Resize(ref z, z.Length + 1);
                    z[n] = new double[2];
                    z[n][0] = p2.x[i][0];
                    z[n][1] = p2.x[i][1];
                    n++;
                }
            }

            polinom p = new polinom(z);
            return p;
        }


        public override string ToString()
        {
            string str = "";
            for (int i = 0; i < x.Length; i++)
            {
                str += $"{(x[i][0] == 1 && x[i][1] != 0 ? "" : Convert.ToString(x[i][0]))}{(x[i][1] == 0? "" : "x")}{( x[i][1] == 0 || x[i][1] == 1 ? "" : "^" + Convert.ToString(x[i][1]))} + ";
            }
            return str.Substring(0, str.Length - 3);
        }
    }
}
