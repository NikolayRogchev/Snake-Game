using System;
using Snake.Utilities;
using Snake.Engine;
using Snake.Display;
using System.Threading;
using Snake.Engine.Envoirment;

namespace Snake.Game
{
    public class Game
    {
        static void Main(string[] args)
        {
            InitialSetup.InitializeWindow();
            SnakePlayer snakePlayer = new SnakePlayer("Nikolay");
            AppleHandler appleHandler = new AppleHandler();
            Timer timer = new Timer(x => appleHandler.GenerateApple(), null, 1000, 3000);
            Print.PrintWindow(snakePlayer);
            while (true)
            {
                if (!snakePlayer.IsAlive)
                {
                    Print.PrintEndGame(snakePlayer);
                    break;
                }
                Print.ClearSnake(snakePlayer);
                if (!Console.KeyAvailable)
                {
                    snakePlayer.Move(appleHandler);
                }
                else
                {
                    ConsoleKeyInfo keyPressed = Console.ReadKey();
                    snakePlayer.Move(keyPressed, appleHandler);
                }
                Print.PrintApples(appleHandler);
                Print.PrintSnake(snakePlayer);
                Thread.Sleep(100);
            }
        }
    }
}
