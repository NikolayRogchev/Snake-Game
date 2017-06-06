using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake.Utilities
{
    public class Window
    {
        public const int Width = 100;
        public const int Height = 20;
        public const int StartPositionX = Width / 2;
        public const int StartPositionY = Height / 2 - 1; // Subtract 1 row for top info
        public const char BorderHorizontal = '═';
        public const char BorderVertical = '║';
        public const char BorderLeftTopCorner = '╔';
        public const char BorderRightTopCorner = '╗';
        public const char BorderLeftBottomCorner = '╚';
        public const char BorderRightBottomCorner = '╝';
    }
}
