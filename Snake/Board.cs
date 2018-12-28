using System;

namespace Snake
{
    public class Board
    {
        public Board(int xSize, int ySize)
        {
            // border color
            Console.ForegroundColor = ConsoleColor.DarkRed;
            
            // creating outlines of game field
            for (int i = 0; i < ySize; i++)
            {
                if (i == 0 || i == ySize - 1)
                {
                    for (int j = 0; j < xSize; j++)
                    {
                        Console.SetCursorPosition(j, i);
                        Console.Write('#');
                    }
                }
                else
                {
                    Console.SetCursorPosition(0, i);
                    Console.Write('#');
                    Console.SetCursorPosition(xSize - 1, i);
                    Console.Write('#');            
                }
            }

            Console.ResetColor();
        }
    }
}