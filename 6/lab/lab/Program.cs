using System;

namespace lab
{
    class Program
    {
        static void Main(string[] args)
        {
            ProgramConverter[] check = new ProgramConverter[2];
            check[0] = new ProgramConverter();
            check[1] = new ProgramHelper();
            for (int i = 0; i < check.Length; i++)
            {
                if (check[i] is ICodeChecker)
                {
                    ICodeChecker codeCheck = check[i] as ProgramHelper;
                    if (codeCheck.CheckCodeSyntax("lol", "haha")) Console.WriteLine(check[i].ConvertToCSharp("lol"));
                    else Console.WriteLine(check[i].ConvertToVB("lol"));
                } else
                {
                    IConvertible convert = check[i] as ProgramConverter;
                    Console.WriteLine(convert.ConvertToCSharp("lol"));
                    Console.WriteLine(convert.ConvertToVB("lol"));
                }
            }
        }
    }

    interface IConvertible
    {
        string ConvertToCSharp(string toSharp);
        string ConvertToVB(string toVB);
    }

    interface ICodeChecker
    {
        bool CheckCodeSyntax(string str1, string str2);
    }
    class ProgramHelper : ProgramConverter, ICodeChecker
    {
        public string ConvertToCSharp(string toSharp)
        {
            return "ProgHelper_toCSharp";
        }

        public string ConvertToVB(string toVB)
        {
            return "ProgHelper_toVB";
        }

        public bool CheckCodeSyntax(string str, string lang)
        {
            return true;
        }
    }

    public class ProgramConverter : IConvertible
    {
        public string ConvertToCSharp(string toSharp)
        {
            return "ProgConverter_toCSharp";
        }

        public string ConvertToVB(string toVB)
        {
            return "ProgConverter_toVB";
        }
    }
}
