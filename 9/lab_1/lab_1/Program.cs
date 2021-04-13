using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace lab_1
{
    class Program
    {
        static void Main(string[] args)
        {
            #region task1
            XDocument xdoc = new XDocument();
            XElement root = new XElement("root");

            StreamReader fileIn = new StreamReader("file.txt");
            string str; int[] nums = { 0, 0 };

            while ((str = fileIn.ReadLine()) != null)
            {
                XElement line = new XElement("line");
                XAttribute num1 = new XAttribute("num", nums[0].ToString());
                line.Add(num1);

                string[] s1 = str.Trim().Split(); nums[1] = 0;
                foreach (string s in s1)
                {
                    XElement word = new XElement("word");
                    XAttribute num2 = new XAttribute("num", nums[1].ToString());
                    XText text = new XText(s);
                    word.Add(num2);
                    word.Add(text);
                    line.Add(word);
                    nums[1]++;
                }
                root.Add(line);
                nums[0]++;
            }
            fileIn.Close();
            xdoc.Add(root);
            xdoc.Save("xmlFile");
            Console.WriteLine(xdoc + "\n");
            #endregion

            #region task2
            XDocument xdoc1 = XDocument.Load("xmlFile");

            var countOfNames = xdoc1.Descendants().GroupBy(z => z.Name).Select(elems => new { name = elems.Key, count = elems.Count()});

            Console.WriteLine("Names of elements with their count according to their order in file:");
            foreach (var z in countOfNames)
            {
                Console.WriteLine($"{z.name}: {z.count}");
            }


            #endregion

        }
    }
}
