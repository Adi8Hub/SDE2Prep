using System;
// using Internal;
using System.Collections;
using System.Collections.Generic;

System.Console.WriteLine("TODO: Run // TODO: Leetcode 200 - Number of Islands");
// char[][] grid = [
//             ['1', '1', '1', '1', '0'],
//             ['1', '1', '0', '1', '0'],
//             ['1', '1', '0', '0', '0'],
//             ['0', '0', '0', '0', '0']
//           ];

char[][] grid = [
          ['1','1','0','0','0'],
            ['1','1','0','0','0'],
            ['0','0','1','0','0'],
            ['0','0','0','1','1']
          ];

int ans = Program.Numslands(grid);
System.Console.WriteLine($"Number of Islands : {ans}");


public class Program
{
    public static int Numslands(char[][] grid)
    {
        int m = grid.Length;
        int n = grid[0].Length;
        bool[,] visited = new bool[m, n];
        int count = 0;

        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (grid[i][j] == '1' && !visited[i, j])
                {
                    recurAndCount(grid, visited, i, j);
                    count++;

                }
            }
        }
        return count;
    }

    // **********************       BFS     *************************************
    private static void recurAndCount(char[][] grid, bool[,] visited, int i, int j)
    {
        Queue<(int row, int col)> q = new();
        q.Enqueue((i, j));

        int[,] dirs = new int[,]{
          {-1,0},{0,-1},{0,1}, {1,0}
        };

        while (q.Count > 0)
        {
            var (row, col) = q.Dequeue();
            for (int dir = 0; dir < dirs.GetLength(0); dir++)
            {
                var newRow = dirs[dir, 0] + row;
                var newCol = dirs[dir, 1] + col;

                if (newRow >= 0 && newRow < grid.Length &&
                newCol >= 0 && newCol < grid[0].Length && grid[newRow][newCol] == '1' && !visited[newRow, newCol])
                {
                    q.Enqueue((newRow, newCol));
                    visited[newRow, newCol] = true;
                }
            }
        }
    }

    // *************************          DFS       *******************************
    // private static void recurAndCount(char[][] grid, bool[,] visited, int i, int j)
    // {
    //     if (i < 0 || j < 0 || i >= grid.Length || j >= grid[0].Length || grid[i][j] == '0' || visited[i, j]) return;

    //     visited[i, j] = true;

    //     recurAndCount(grid, visited, i + 1, j);
    //     recurAndCount(grid, visited, i - 1, j);
    //     recurAndCount(grid, visited, i, j + 1);
    //     recurAndCount(grid, visited, i, j - 1);

    // }
}


/*
Given an m x n 2D binary grid grid which represents a map of '1's (land) and '0's (water), return the number of islands.

An island is surrounded by water and is formed by connecting adjacent lands horizontally or vertically. You may assume all four edges of the grid are all surrounded by water.

 

Example 1:

Input: grid = [
  ["1","1","1","1","0"],
  ["1","1","0","1","0"],
  ["1","1","0","0","0"],
  ["0","0","0","0","0"]
]
Output: 1
Example 2:

Input: grid = [
  ["1","1","0","0","0"],
  ["1","1","0","0","0"],
  ["0","0","1","0","0"],
  ["0","0","0","1","1"]
]
Output: 3
 

Constraints:

m == grid.length
n == grid[i].length
1 <= m, n <= 300
grid[i][j] is '0' or '1'.
*/