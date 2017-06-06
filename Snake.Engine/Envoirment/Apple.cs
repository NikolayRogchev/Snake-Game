using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake.Engine
{
    public class Apple
    {
        public Apple(Point position)
        {
            Position = position;
        }
        public int Value { get; set; }
        public Point Position { get; set; }
        public char Symbol { get; } = '@';
    }
}
