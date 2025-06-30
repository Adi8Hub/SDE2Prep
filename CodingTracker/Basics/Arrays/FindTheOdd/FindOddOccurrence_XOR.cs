using System;
using System.Collections.Generic;

int n = 9;
int[] nums = { 1, 2, 3, 2, 3, 1, 3, 3, 2 };
int ans = FindOdd.GetOddOccurence(nums, n);
System.Console.WriteLine($"{ans}");
class FindOdd
{
    public static int GetOddOccurence(int[] nums, int n)
    {
        int res = 0;

        foreach (var num in nums)
        {
            res ^= num;
        }

        return res;
    }
}