using Snake.Engine;
using Snake.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Snake.Engine.Envoirment;

namespace Snake.Display
{
    public class Print
    {
        public static void PrintWindow(SnakePlayer player)
        {
            Console.CursorVisible = false;
            PrintInfo(player.Name, player.Score);
            PrintFrame();
        }
        public static void PrintFrame()
        {
            for (int i = 1; i < Window.Height - 1; i++)
            {
                switch (i)
                {
                    case 1:
                        Console.Write(Window.BorderLeftTopCorner);
                        PrintHorizontalLine(Window.Width - 2, Window.BorderHorizontal);
                        Console.Write(Window.BorderRightTopCorner);
                        break;
                    case (Window.Height - 2):
                        Console.Write(Window.BorderLeftBottomCorner);
                        PrintHorizontalLine(Window.Width - 2, Window.BorderHorizontal);
                        Console.Write(Window.BorderRightBottomCorner);
                        break;
                    default:
                        Console.Write(Window.BorderVertical);
                        PrintHorizontalLine(Window.Width - 2, ' ');
                        Console.Write(Window.BorderVertical);
                        break;
                }
            }
        }
        public static void PrintApples(AppleHandler appleHandler)
        {
            foreach (Apple apple in appleHandler.Apples)
            {
                Console.SetCursorPosition(apple.Position.X, apple.Position.Y);
                Console.Write(apple.Symbol);
            }
        }
        public static void PrintSnake(SnakePlayer player)
        {
            //int bodyCount = 0;
            //foreach (Point bodyPart in player.Body)
            //{
            //    Console.SetCursorPosition(bodyPart.X, bodyPart.Y);
            //    if (bodyCount == 0)
            //    {
            //        Console.Write(player.HeadSymbol);
            //    }
            //    else
            //    {
            //        Console.Write(player.BodySymbol);
            //    }
            //    bodyCount++;
            //}
            Console.SetCursorPosition(player.HeadPosition.X, player.HeadPosition.Y);
            Console.Write(player.HeadSymbol);
            Console.SetCursorPosition(player.Body[1].X, player.Body[1].Y);
            Console.Write(player.BodySymbol);
        }
        public static void ClearSnake(SnakePlayer player)
        {
            //foreach (Point bodyPart in player.Body)
            //{
            //    Console.SetCursorPosition(bodyPart.X, bodyPart.Y);
            //    Console.Write(" ");
            //}
            Point tail = player.Body[player.Body.Count() - 1];
            Console.SetCursorPosition(tail.X, tail.Y);
            Console.Write(" ");
        }
        public static void PrintEndGame(SnakePlayer player)
        {
            string endMessage = "Game Over! Score: " + player.Score;
            Console.SetCursorPosition((Window.Width - endMessage.Length - 2) / 2, Window.Height / 2);
            Console.Write(endMessage);
            Console.SetCursorPosition((Window.Width - endMessage.Length - 2) / 2, (Window.Height / 2) + 1);
        }
        private static void PrintInfo(string playerName, int playerPoints)
        {
            Console.SetCursorPosition(0, 0);
            Console.WriteLine($"Player {playerName}: {playerPoints} points");
        }
        private static void PrintHorizontalLine(int count, char symbol)
        {
            Console.Write("{0}", new string(symbol, count));
        }
    }
}
