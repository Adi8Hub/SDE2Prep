class Solution
{
    public int MissingNum(int[] arr)
    {
        int n = arr.Length + 1;
        int xorArr = 0;
        for (int i = 0; i < n - 1; i++)
        {
            xorArr ^= arr[i];
        }

        int xorAll = 0;
        for (int i = 1; i <= n; i++)
        {
            xorArr ^= i;
        }

        return xorArr ^ xorAll;
    }
}

// ANother approach:
// Take SUm of all from 1 to n and Sum of the array.
// Return the diff
