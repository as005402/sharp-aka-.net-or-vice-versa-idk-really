using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace lab_2_v2._0
{
    class Graphic_Arts
    {
        int width;
        int heigth;
        Board board;
        Paddle paddle1;
        Paddle paddle2;
        ConsoleKeyInfo KeyInfo;
        ConsoleKey consoleKey;
        Ball ball;

        public Graphic_Arts(int width, int heigth)
        {
            this.width = width;
            this.heigth = heigth;
        }
        public void Setup()
        {
            board = new Board(width, heigth);
            ball = new Ball(width, heigth);
            paddle1 = new Paddle(1, heigth);
            paddle2 = new Paddle(width - 1, heigth);
            KeyInfo = new ConsoleKeyInfo();
            consoleKey = new ConsoleKey();
            ball.Napravlenie = 0;
        }
        void Input()
        {
            if (Console.KeyAvailable)
            {
                KeyInfo = Console.ReadKey(true);
                consoleKey = KeyInfo.Key;
            }
        }
        public void Run()
        {
            while (true)
            {
                Console.Clear();
                Setup();
                board.Write();
                paddle1.Write();
                paddle2.Write();
                ball.Write();
                while (ball.X > 1 && ball.X < width - 1)
                {
                    Input();
                    switch (consoleKey)
                    {
                        case ConsoleKey.UpArrow:
                            paddle1.Up();
                            paddle2.Up();
                            break;
                        case ConsoleKey.DownArrow:
                            paddle1.Down();
                            paddle2.Down();
                            break;
                        case ConsoleKey.W:
                            paddle1.Up();
                            paddle2.Up();
                            break;
                        case ConsoleKey.S:
                            paddle1.Down();
                            paddle2.Down();
                            break;
                    }
                    consoleKey = ConsoleKey.A;
                    ball.Logic(paddle1, paddle2);
                    ball.Write();
                    Thread.Sleep(100);
                }
                Thread.Sleep(360);
            }

        }
    }
    class Ball
    {
        public int X { get; set; }
        public int Y { get; set; }
        int povorotX;
        int povorotY;
        int boardHeigth;
        int boardWidth;
        public int Napravlenie { get; set; }
        public Ball(int boardWidth, int boardHeigth)
        {
            X = boardWidth / 2;
            Y = boardHeigth / 2;
            this.boardHeigth = boardHeigth;
            this.boardWidth = boardWidth;
            povorotX = -1;
            povorotY = 1;
        }
        public void Logic(Paddle paddle1, Paddle paddle2)
        {
            Console.SetCursorPosition(X, Y);
            Console.Write(" ");
            if (Y <= 1 || Y >= boardHeigth)
            {
                povorotY *= -1;
            }
            if (((X == 2 || X == (boardWidth - 2)) && (paddle1.Y - (paddle1.Length / 2)) <= Y && (paddle1.Y + (paddle1.Length / 2)) > Y))
            {
                povorotX *= -1;
                if (Y == paddle1.Y)
                {
                    Napravlenie = 0;
                }
                if ((Y >= (paddle1.Y - (paddle1.Length / 2)) && Y < paddle1.Y) || (Y > paddle1.Y && Y < (paddle1.Y + (paddle1.Length / 2))))
                {
                    Napravlenie = 1;
                }
            }
            switch (Napravlenie)
            {
                case 0:
                    X += povorotX;
                    break;
                case 1:
                    X += povorotX;
                    Y += povorotY;
                    break;
            }

        }
        public void Write()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(X, Y);
            Console.Write("o");
        }
    }
    class Paddle
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Length { get; set; }
        int boardHeigth;

        public Paddle(int x, int boardHeigth)
        {
            this.boardHeigth = boardHeigth;
            X = x;
            Y = boardHeigth / 10 * 3;
            Length = boardHeigth / 10 * 3;
        }

        public void Up()
        {
            if ((Y - 1 - (Length / 2)) != 0)
            {
                Console.SetCursorPosition(X, (Y + (Length / 2)) - 1);
                Console.Write(" ");
                Y--;
                Write();
            }
        }

        public void Down()
        {
            if ((Y + 1 + (Length / 2)) != boardHeigth + 2)
            {
                Console.SetCursorPosition(X, (Y - (Length / 2)));
                Console.Write(" ");
                Y++;
                Write();
            }
        }

        public void Write()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            for (int i = (Y - (Length / 2)); i < (Y + (Length / 2)); i++)
            {
                Console.SetCursorPosition(X, i);
                Console.Write("│");
            }
        }
    }
    public class Board
    {
        public int Height { get; set; }
        public int Width { get; set; }

        public Board()
        {
            Width = 20;
            Height = 20;
        }

        public Board(int width, int height)
        {
            Width = width;
            Height = height;
        }
        public void Write()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            for (int i = 1; i <= Width; i++)
            {
                Console.SetCursorPosition(i, 0);
                Console.Write("─");
            }
            for (int i = 1; i <= Width; i++)
            {
                Console.SetCursorPosition(i, (Height + 1));
                Console.Write("─");
            }
            for (int i = 1; i <= (Height); i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write("║");
            }
            for (int i = 1; i <= Height; i++)
            {
                Console.SetCursorPosition((Width + 1), i);
                Console.Write("║");
            }

            Console.SetCursorPosition(0, 0);
            Console.Write("╓");
            Console.SetCursorPosition(Width + 1, 0);
            Console.Write("╖");
            Console.SetCursorPosition(0, Height + 1);
            Console.Write("╙");
            Console.SetCursorPosition(Width + 1, Height + 1);
            Console.Write("╜");
        }
    }
}
