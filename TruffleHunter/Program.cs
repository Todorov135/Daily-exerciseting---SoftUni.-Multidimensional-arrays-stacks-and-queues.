using System;
using System.Collections.Generic;
using System.Linq;

namespace TruffleHunter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());
            int eatenByBoar = 0;
            char[,] matrix = new char[matrixSize, matrixSize];
            Dictionary<char, int> colectingTruffle = new Dictionary<char, int>()
            {
                { 'B',0 },
                { 'S', 0},
                { 'W',0}
            };

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] inputRow = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = inputRow[col];
                }

            }
            string commands = "";
            while ((commands = Console.ReadLine()) != "Stop the hunt")
            {
                string[] tokens = commands.Split();
                string action = tokens[0];
                int row = int.Parse(tokens[1]);
                int col = int.Parse(tokens[2]);

                if (action == "Collect")
                {
                    char currPosition = matrix[row, col];
                    if (currPosition == 'B')
                    {
                        colectingTruffle['B']++;
                    }
                    else if (currPosition == 'S')
                    {
                        colectingTruffle['S']++;
                    }
                    else if (currPosition == 'W')
                    {
                        colectingTruffle['W']++;
                    }
                    matrix[row, col] = '-';
                }
                else if (action == "Wild_Boar")
                {
                    string direction = tokens[3];
                    char boarPosition = matrix[row, col];

                    if (direction == "up")
                    {

                        for (int rows = row; rows >= 0; rows -= 2)
                        {
                            char currChar = matrix[rows, col];
                            if (currChar == 'B'|| currChar == 'S'|| currChar == 'W')
                            {
                                eatenByBoar++;
                                matrix[rows, col] = '-';
                            }
                        }
                    }
                    else if (direction == "down")
                    {
                        for (int rows = row; rows <matrix.GetLength(0); rows += 2)
                        {
                            char currChar = matrix[rows, col];
                            if (currChar == 'B' || currChar == 'S' || currChar == 'W')
                            {
                                eatenByBoar++;
                                matrix[rows, col] = '-';
                            }
                        }


                    }
                    else if (direction == "left")
                    {
                        for (int cols = col; cols >=0; cols -= 2)
                        {
                            char currChar = matrix[row, cols];
                            if (currChar == 'B' || currChar == 'S' || currChar == 'W')
                            {
                                eatenByBoar++;
                                matrix[row, cols] = '-';
                            }
                        }


                    }
                    else if (direction == "right")
                    {
                        for (int cols = col; cols < matrix.GetLength(1); cols += 2)
                        {
                            char currChar = matrix[row, cols];
                            if (currChar == 'B' || currChar == 'S' || currChar == 'W')
                            {
                                eatenByBoar++;
                                matrix[row, cols] = '-';
                            }
                        }

                    }

                }
            }
            Console.WriteLine($"Peter manages to harvest {colectingTruffle['B']} black, {colectingTruffle['S']} summer, and {colectingTruffle['W']} white truffles.");
            Console.WriteLine($"The wild boar has eaten {eatenByBoar} truffles.");
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row,col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}






