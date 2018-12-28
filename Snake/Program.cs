using System;
using System.Collections;
using System.Text;
using System.Threading;
using System.Windows;

namespace Snake
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            // console settings
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;

            // Body[] snake;
            ArrayList snake = new ArrayList();
            Point center;
            Vector v = new Vector(0, 0);
            ConsoleKey k = ConsoleKey.F24;
            long score = 0;
            bool end = false;
            bool retry = false;

            int wSize;
            do
            {
                Console.Write("Game size (square): ");
                wSize = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter a number bigger than 50!");
            } while (wSize < 50);
            Console.Clear();

            int xMax = wSize;
            int yMax = wSize / 2;
            
            Console.SetWindowSize(xMax + 20, yMax);
            Console.Clear();
            Console.CursorVisible = false;
            
            Board b = new Board(xMax, yMax);
            Food f = new Food(xMax, yMax);
            f.New();
            f.Show();
            
            center = new Point(xMax / 2, yMax / 2);  // center point of game
            
            snake.Add(new Body(center, true));  // head; first index
          
            while (true)
            {
                if(!end)
                {
                    foreach(Body s in snake)
                    {
                        if(s != null)
                        {
                            s.Show();
                        }
                    }
                }

                ArrayList body = snake.GetRange(1, snake.Count - 1);
                foreach(Body bd in body)
                {
                    if(bd.pos == (snake[0] as Body).pos)
                    {
                        end = true;
                        break;
                    }
                }


                if (f.FoodEaten((snake[0] as Body).pos))
                {
                    f.New();
                    score++;
                    snake.Add(new Body(Point.Subtract((snake[(int)score - 1] as Body).pos, v)));
                }
                f.Show();
                
                while (Console.KeyAvailable) k = Console.ReadKey(true).Key;
                switch (k)
                {
                    case ConsoleKey.W:
                        if ((snake[0] as Body).pos.Y < 2) end = true;
                        else v = new Vector(0, -1);
                        break;
                    case ConsoleKey.S:
                        if ((snake[0] as Body).pos.Y > yMax - 3) end = true;
                        else v = new Vector(0, 1);
                        break;
                    case ConsoleKey.A:
                        if ((snake[0] as Body).pos.X < 2) end = true;
                        else v = new Vector(-1, 0);
                        break;
                    case ConsoleKey.D:
                        if ((snake[0] as Body).pos.X > xMax - 3) end = true;
                        else v = new Vector(1, 0);
                        break;
                    case ConsoleKey.Q:
                        end = true;
                        break;
                }

                if (!end)
                {
                    Thread.Sleep(200);
                    foreach (Body s in snake) if (s != null) s.Clear();
                    for (int i = snake.Count - 1; i > 0; i--)
                    {
                        if(snake[i] != null && snake[i - 1] != null) (snake[i] as Body).pos = (snake[i - 1] as Body).pos;
                    }
                    (snake[0] as Body).Move(v);
                }
                else if(end)
                {
                    Console.Clear();
                    Console.WriteLine("You lost!");
                    Console.WriteLine($"Score: {score}");
                    break;
                }
            }
            Console.ReadKey(true);
        }
    }
}