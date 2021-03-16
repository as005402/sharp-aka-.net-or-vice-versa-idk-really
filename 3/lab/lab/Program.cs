using System;

namespace lab
{
    class circle_segment
    {
        private double r, c, s, h, S, th;

        public circle_segment()
        {

        }

        public double R
        {
            set
            {
                while (value < 0) { Console.WriteLine("Invalid value of radius. Try Again :)"); value = Convert.ToDouble(Console.ReadLine()); }
                r = value;
            }
            get
            {
                return r;
            }
        }

        public double Th
        {
            set
            {
                while (value < 0) { Console.WriteLine("Invalid value of angle. Try Again :)"); value = Convert.ToDouble(Console.ReadLine()); }
                th = value * (Math.PI / 180.0);
            }
            get
            {
                return th;
            }
        }

        public double get_c()
        {
            c = 2 * r * Math.Sin(th / 2);
            return c;
        }

        public double get_s()
        {
            s = th * r;
            return s;
        } 

        public double get_h()
        {
            h = r * (1 - Math.Cos(th / 2));
            return h;
        }

        public double get_S()
        {
            S = 0.5 * Math.Pow(r, 2) * (th - Math.Sin(th));
            return S;
        }


    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter circle segment's radius and angle (degrees):");
            string[] inp = Console.ReadLine().Split();
            circle_segment circle = new circle_segment { R = Convert.ToDouble(inp[0]), Th = Convert.ToDouble(inp[1]) };
            Console.WriteLine("Length of this segment's chord: {0}", circle.get_c());
            Console.WriteLine("Length of this segment's arc: {0}", circle.get_s());
            Console.WriteLine("Height of this segment: {0}", circle.get_h());
            Console.WriteLine("Area of this segment: {0}", circle.get_S());
        }
    }
}
