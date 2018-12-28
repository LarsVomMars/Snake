using System;
using System.Windows;

namespace Snake
{
    public class Food
    {
        private int xMax, yMax;
        private Random r = new Random();
        private Point f;
        
        public Food(int width, int height)
        {
            xMax = width;
            yMax = height;
        }

        public void New()
        {
            // get new food position
            f.X = r.Next(1, xMax - 1);
            f.Y = r.Next(1, yMax - 1);
        }

        public void Show()
        {
            // display it
            Console.SetCursorPosition((int)f.X, (int)f.Y);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write('X');
            Console.ResetColor();
        }

        public bool FoodEaten(Point p)
        {
            if (f.X == p.X && f.Y == p.Y) return true;
            return false;
        }
    }
}