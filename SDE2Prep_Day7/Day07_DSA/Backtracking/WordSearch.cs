using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;

// char[][] board = [['A', 'B', 'C', 'E'], ['S', 'F', 'C', 'S'], ['A', 'D', 'E', 'E']];
// string word = "ABCCED";
char[][] board = [['A', 'B', 'C', 'E'], ['S', 'F', 'C', 'S'], ['A', 'D', 'E', 'E']];
string word = "ABCB";
var isExist = Program.Exists(board, word);
Console.WriteLine($"{isExist}");

public class Program
{

    public static bool Exists(char[][] board, string word)
    {
        int m = board.Length;
        int n = board[0].Length;

        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (word[0] == board[i][j] && solve(board, word, i, j, 0))
                    return true;
            }

        }
        return false;
    }

    static bool solve(char[][] board, string word, int i, int j, int idx)
    {
        if (idx >= word.Length) return true;

        if (i < 0 || j < 0 || i >= board.Length || j >= board[0].Length || board[i][j] != word[idx])
            return false;


        var orig = board[i][j];
        board[i][j] = '#';//use dummy char to imply that its been used
        //perform operation on other dirs
        var res = solve(board, word, i + 1, j, idx + 1) || solve(board, word, i - 1, j, idx + 1) ||
                    solve(board, word, i, j - 1, idx + 1) || solve(board, word, i, j + 1, idx + 1);

        //revert back
        board[i][j] = orig;
        return res;
    }
}


/*
Given an m x n grid of characters board and a string word, return true if word exists in the grid.

The word can be constructed from letters of sequentially adjacent cells, where adjacent cells are horizontally or vertically neighboring. The same letter cell may not be used more than once.

 

Example 1:


Input: board = [["A","B","C","E"],["S","F","C","S"],["A","D","E","E"]], word = "ABCCED"
Output: true
Example 2:


Input: board = [["A","B","C","E"],["S","F","C","S"],["A","D","E","E"]], word = "SEE"
Output: true
Example 3:


Input: board = [["A","B","C","E"],["S","F","C","S"],["A","D","E","E"]], word = "ABCB"
Output: false
 

Constraints:

m == board.length
n = board[i].length
1 <= m, n <= 6
1 <= word.length <= 15
board and word consists of only lowercase and uppercase English letters.
 

Follow up: Could you use search pruning to make your solution faster with a larger board?


*/