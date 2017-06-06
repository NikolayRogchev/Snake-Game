using Snake.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake.Engine.Envoirment
{
    public class AppleHandler
    {
        public AppleHandler()
        {
            Apples = new List<Apple>();
        }
        public List<Apple> Apples { get; set; }
        public void GenerateApple()
        {
            Random random = new Random();
            Point applePosition = new Point(random.Next(1, Window.Width - 1), random.Next(2, Window.Height - 1));
            Apple newApple = new Apple(applePosition);
            if (IsAppleUnique(newApple))
            {
                Apples.Add(newApple);
            }
            else
            {
                GenerateApple();
            }
        }

        public void RemoveApple(Point applePosition)
        {
            Apples.Remove(Apples.Where(a => a.Position.X == applePosition.X && a.Position.Y == applePosition.Y).FirstOrDefault());
        }

        private bool IsAppleUnique(Apple apple)
        {
            return Apples.Where(a => a.Position.X == apple.Position.X && a.Position.Y == apple.Position.Y).FirstOrDefault() == null;
        }
    }
}
