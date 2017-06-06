using System;
using System.Collections.Generic;
using System.Text;

namespace Snake.Utilities
{
    public class InitialSetup
    {
        
        public static void InitializeWindow()
        {
            Console.WindowHeight = Window.Height;
            Console.WindowWidth = Window.Width;
            Console.BufferHeight = Window.Height;
            Console.BufferWidth = Window.Width;
            Console.SetWindowSize(Window.Width, Window.Height);
        }
    }
}
