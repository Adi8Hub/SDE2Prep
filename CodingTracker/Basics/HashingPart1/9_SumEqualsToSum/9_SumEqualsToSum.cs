using System;
using System.Collections.Generic;

int[] A = { 3, 4, 7, 1, 2, 9, 8 };
Console.WriteLine(Solution.HasEqualSumPairs(A)); // Output: 1
class Solution
{
    public static bool HasEqualSumPairs(int[] A)
    {
        int n = A.Length;
        Dictionary<int, (int, int)> map = new Dictionary<int, (int, int)>();

        for (int i = 0; i < n; i++)
        {
            for (int j = i + 1; j < n; j++)
            {
                int sum = A[i] + A[j];

                if (map.ContainsKey(sum))
                {
                    var prev = map[sum];
                    // Ensure all four indices are distinct
                    if (prev.Item1 != i && prev.Item1 != j && prev.Item2 != i && prev.Item2 != j)
                        return true;
                }
                else
                {
                    map[sum] = (i, j);
                }
            }
        }

        return false;
    }


}
