using Snake.Engine.Envoirment;
using Snake.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake.Engine
{
    public class SnakePlayer
    {
        public SnakePlayer(string name, char headSymbol, char bodySymbol)
            : this(name)
        {
            HeadSymbol = headSymbol;
            BodySymbol = bodySymbol;
        }
        public SnakePlayer(string name)
        {
            Name = name;
            HeadPosition = new Point(Window.StartPositionX, Window.StartPositionY);
            TailPosition = new Point(Window.StartPositionX + 1, Window.StartPositionY);
            Body = new List<Point>() { HeadPosition, TailPosition };
        }
        public string Name { get; set; } = "Unknown";
        public int Score { get; } = 0;
        public char HeadSymbol { get; } = 'o';
        public char BodySymbol { get; } = 'x';
        public Point HeadPosition { get; set; }
        public Point TailPosition { get; set; }
        public int Size { get; } = 1;
        public Direction Direction { get; set; } = Direction.Left;
        public List<Point> Body { get; set; }
        public bool IsAlive { get; private set; } = true;


        public void Move(AppleHandler appleHandler)
        {
            UpdatePlayerPosition(this.Direction, appleHandler);
        }
        public void Move(ConsoleKeyInfo keyPressed, AppleHandler appleHandler)
        {
            Direction newDirection = SwitchDirection(keyPressed);
            UpdatePlayerPosition(newDirection, appleHandler);
        }
        private Direction SwitchDirection(ConsoleKeyInfo keyPressed)
        {
            Direction newDirection = this.Direction;
            switch (keyPressed.Key)
            {
                case ConsoleKey.UpArrow:
                    if (Direction != Direction.Down)
                    {
                        newDirection = Direction.Up;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if (Direction != Direction.Up)
                    {
                        newDirection = Direction.Down;
                    }
                    break;
                case ConsoleKey.LeftArrow:
                    if (Direction != Direction.Right)
                    {
                        newDirection = Direction.Left;
                    }
                    break;
                case ConsoleKey.RightArrow:
                    if (Direction != Direction.Left)
                    {
                        newDirection = Direction.Right;
                    }
                    break;
            }
            return newDirection;
        }
        private void UpdatePlayerPosition(Direction direction, AppleHandler appleHandler)
        {
            Direction = direction;
            Point newHeadPosition = new Point(HeadPosition.X, HeadPosition.Y);

            switch (direction)
            {
                case Direction.Left:
                    newHeadPosition.X--;
                    break;
                case Direction.Right:
                    newHeadPosition.X++;
                    break;
                case Direction.Up:
                    newHeadPosition.Y--;
                    break;
                case Direction.Down:
                    newHeadPosition.Y++;
                    break;
                default:
                    break;
            }

            if (HasCollidedWithWall())
            {
                Die();
                return;
            }

            HeadPosition = newHeadPosition;
            if (HasCollidedWithApple(appleHandler.Apples))
            {
                EatApple(HeadPosition, appleHandler);
            }
            else
            {
                Body.Insert(0, newHeadPosition);
                Body.RemoveAt(Body.Count() - 1);
            }

        }
        private void EatApple(Point position, AppleHandler appleHandler)
        {
            Body.Insert(0, position);
            appleHandler.RemoveApple(position);
        }
        private void Die()
        {
            IsAlive = false;
        }
        private bool HasCollidedWithWall()
        {
            bool hasCollidedTop = HeadPosition.Y <= 1;
            bool hasCollidedBottom = HeadPosition.Y >= Window.Height - 1;
            bool hasCollidedLeft = HeadPosition.X <= 0;
            bool hasCollidedRight = HeadPosition.X >= Window.Width;

            return hasCollidedTop || hasCollidedBottom || hasCollidedLeft || hasCollidedRight;
        }
        private bool HasCollidedWithApple(IEnumerable<Apple> apples)
        {
            bool hasCollided = false;
            foreach (Apple apple in apples)
            {
                if (apple.Position.X == HeadPosition.X && apple.Position.Y == HeadPosition.Y)
                {
                    hasCollided = true;
                    break;
                }
            }
            return hasCollided;
        }
    }

    public enum Direction
    {
        Left, Right, Up, Down
    }
}
