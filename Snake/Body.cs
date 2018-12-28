using System;
using System.Windows;

namespace Snake
{
    public class Body
    {
        public Point pos;
        public bool head;
        
        public Body(Point _pos, bool _head = false)
        {
            pos = _pos;
            head = _head;
        }

        public void Move(Vector v)
        {
            pos = Point.Add(pos, v);
        }

        public void Clear()
        {
            Console.SetCursorPosition((int)pos.X, (int)pos.Y);
            Console.Write(' ');
        }

        public void Show()
        {
            Console.SetCursorPosition((int)pos.X, (int)pos.Y);
            if (head)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write('O');
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write('o');
                Console.ResetColor();
            }
        }
    }
}