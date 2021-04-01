using System;

namespace lab_2_v2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\n\n\n\n\n\n\t       _" +
                "\n\t   ___|_|___ ___    ___ ___ ___ ___" +
                "\n\t  | . | |   | . |  | . | . |   | . |" +
                "\n\t  |  _|_|_|_|__ |  |  _|___|_|_|__ |" +
                "\n\t  |_|       |___|  |_|         |___| \n\n");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\t\tPress enter to start...");
            Console.SetCursorPosition(0, 0);
            Board b = new Board(50, 20);
            b.Write();
            Console.ReadLine();
            
            Console.CursorVisible = false;
            Graphic_Arts graphic_arts = new Graphic_Arts(50, 20);
            graphic_arts.Run();
            Console.ReadKey();
        }
    }
}
