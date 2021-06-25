﻿using System;
using System.IO;

namespace WordPuzzle
{
    class Program
    {
        static int R, C;

        //8 direction for searching
        static int[] x = { -1, -1, -1, 0, 0, 1, 1, 1 };
        static int[] y = { -1, 0, 1, -1, 1, -1, 0, 1 };

        static void Main(string[] args)
        {
            R = 5;
            C = 5;
            char[,] grid = { { 'R', 'I', 'O', 'T', 'F'},
                             { 'E', 'L', 'C', 'U', 'P'},
                             { 'P', 'R', 'A', 'L', 'U'},
                             { 'L', 'S', 'E', 'S', 'O'},
                             { 'W', 'B', 'E', 'A', 'D'}
            };

            //Input file from C drive
            StreamReader myReader = new StreamReader("C:/words.txt");

            string line;

            while ((line = myReader.ReadLine()) != null)
            {
                patternSearch(grid, line.ToUpper());
            }
            Console.WriteLine();

        }

        static void patternSearch(char[,] grid, String word)
        {
            // Consider every point as starting
            // point and search given word
            for (int row = 0; row < R; row++)
            {
                for (int col = 0; col < C; col++)
                {
                    if (search2D(grid, row, col, word))
                    {
                        //Console.WriteLine("pattern found at " + row + ", " + col);
                        Console.WriteLine("word is " + word);
                    }
                }
            }
        }

        static bool search2D(char[,] grid, int row, int col, String word)
        {
            // If first character of word doesn't match
            // with given starting point in grid.
            if (grid[row, col] != word[0])
            {
                return false;
            }

            int len = word.Length;

            // Search word in all 8 directions
            for (int dir = 0; dir < 8; dir++)
            {
                // Initialize starting point
                // for current direction
                int k, rd = row + x[dir], cd = col + y[dir];

                // First character is already checked,
                // match remaining characters
                for (k = 1; k < len; k++)
                {
                    // If out of bound break
                    if (rd >= R || rd < 0 || cd >= C || cd < 0)
                    {
                        break;
                    }

                    // If not matched, break
                    if (grid[rd, cd] != word[k])
                    {
                        break;
                    }

                    // Moving in particular direction
                    rd += x[dir];
                    cd += y[dir];
                }

                // If all character matched, then value of k
                // must be equal to length of word
                if (k == len)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
