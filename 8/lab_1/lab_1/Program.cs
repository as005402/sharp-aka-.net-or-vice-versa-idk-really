using System;
using System.Collections;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;

namespace lab
{
    class Program
    {
        static void Main(string[] args)
        {
            CollectionType<circle_segment>[] t = new CollectionType<circle_segment>[4];

            t[0] = new CollectionType<circle_segment>();
            t[0].add(new circle_segment(5, 45));
            t[0].add(new circle_segment(10, 40));
            t[0].add(new circle_segment(8, 55));
            t[0].add(new circle_segment(5, 65));

            t[1] = new CollectionType<circle_segment>();
            t[1].add(new circle_segment(1, 1));
            t[1].add(new circle_segment(1, 69));

            t[2] = new CollectionType<circle_segment>();
            t[2].add(new circle_segment(5, 55));

            t[3] = new CollectionType<circle_segment>();
            t[3].add(new circle_segment(5, 55));
            t[3].add(new circle_segment(14, 10));
            t[3].add(new circle_segment(4, 20));

            foreach (CollectionType<circle_segment> z in t)                     //sort
            {
                circle_segment tmp;
                for (int i = 0; i < z.Length; i++)
                {
                    for (int j = i + 1; j < z.Length; j++)
                    {
                        if (z[i].CompareTo(z[j]) == 1)
                        {
                            tmp = z[i];
                            z.update(z[j], i);
                            z.update(tmp, j);
                        }
                    }
                }
            }

            var twoElems = t.Where(t => t.Length == 2);
            if (twoElems.Count() != 0)
            {
                Console.WriteLine("Collection with 2 elements exist!!");
                //foreach (var elem in twoElems) Console.WriteLine(elem);
            }
            
            var maxR = (from x in t select (from circle_segment z in x select z.R).Max()).Max();
            Console.WriteLine($"Greatest radius in the collection = {maxR}");

            var minR = (from x in t select (from circle_segment z in x select z.R).Min()).Min();
            Console.WriteLine($"Largest radius in the collection = {minR}");

            #region task3
            var sumOfLengthsLessThanThree = t.Where(t => t.Length < 3).Select(t => t.Length).Sum(); //1.where + select + sum()
            var groupByRAndCountThem = from circle_segment z in t[0]                                //2.group by + select + count()
                       group z by z.R into g
                       select new
                       {
                           r = g.Key,
                           count = g.Count()
                       };
            //foreach (var z in groupByRAndCountThem) Console.WriteLine($"{z.r} {z.count}");
            var greaterThanAverage = from x in t                                                    //3.where + average() + select
                          from circle_segment z in x
                          where z.area() > (from b in t from circle_segment a in b select a.area()).Average()
                          select z;
            var orderedByDescending = from circle_segment z in t[0]                                 //4.where + orderby descending + select
                          where z.Th > 0
                          orderby z.area() descending 
                          select new { r = z.R, th = z.Th, area = z.area() };
            #endregion
        }
    }

    public class CollectionType<T>: IEnumerable
    {
        T[] arr;
        public int Length { get { return arr.Length; } }

        public CollectionType()
        {
            arr = new T[0];
        }

        ~CollectionType()
        {
            Console.WriteLine($"Collection of type {typeof(T)} with {arr.Length} elements was deleted");
        }

        public T this[int ind]
        {
            get
            {
                return arr[ind];
            }
            set
            {

            }
        }

        public void add(T elem, int ind)
        {
            Array.Resize(ref arr, arr.Length + 1);
            int i = arr.Length - 1;
            while (i >= ind)
            {
                arr[i] = arr[i - 1];
                i--;
                if (i == ind) arr[i] = elem;
            }
            
        }

        public void add(T elem)
        {
            Array.Resize(ref arr, arr.Length + 1);
            arr[arr.Length - 1] = elem;
        }

        public void delete(int ind)
        {
            try
            {
                if (ind >= arr.Length) throw new IndexOutOfRangeException();
                while (ind < arr.Length - 1)
                {
                    arr[ind] = arr[ind + 1];
                    ind++;
                }
                Array.Resize(ref arr, arr.Length - 1);
            } catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e.Message + "\nTry again\n");
            }
        }

        public void delete(T elem)
        {
            try
            {
                for (int i = 0; i <= arr.Length; i++)
                {
                    if (arr[i].Equals(elem)) { this.delete(i); break; }
                }
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("No such element\nTry again\n");
            }
            
        }

        public void update(T elem, int ind)
        {
            this.arr[ind] = elem;
        }

        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < arr.Length; i++)
                yield return arr[i];
        }
    }

    class circle_segment: IComparable<circle_segment>
    {
        private double r, S, th;

        public circle_segment(double r, double th)
        {
            this.R = r;
            this.Th = th;
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

        public double area()
        {
            S = 0.5 * Math.Pow(r, 2) * (th - Math.Sin(th));
            return S;
        }

        public int CompareTo(circle_segment other)
        {
            return this.area().CompareTo(other.area());
        }

    }

}
