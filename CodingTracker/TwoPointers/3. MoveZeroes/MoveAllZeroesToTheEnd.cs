public class Solution
{
    public static void MoveZeroes(int[] arr)
    {
        int n = arr.Length;
        int lastNonZeroIndex = 0;

        // Move all non-zero elements forward
        for (int i = 0; i < n; i++)
        {
            if (arr[i] != 0)
            {
                arr[lastNonZeroIndex++] = arr[i];
            }
        }

        // Fill remaining positions with zeros
        for (int i = lastNonZeroIndex; i < n; i++)
        {
            arr[i] = 0;
        }
    }
}

/*
Loop over the array, and maintain a nonZeroIndex
use this index to store nonZero value and then only move it

if zero then do nothing,
if non-Zero, then insert regular iteration value at nonZeroIndex and increment this index

*/

//Time Complexity: O(n) — one full pass + one fill pass.

// Space Complexity: O(1) — done in-place without auxiliary data structures.