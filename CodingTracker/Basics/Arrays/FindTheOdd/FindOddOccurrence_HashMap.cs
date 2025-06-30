using System;
using System.Collections.Generic;

int n = 9;
int[] nums = { 1, 2, 3, 2, 3, 1, 3, 3, 1 };
int ans = FindOdd.GetOddOccurence(nums, n);
System.Console.WriteLine($"{ans}");
class FindOdd
{
    public static int GetOddOccurence(int[] nums, int n)
    {
        var map = new Dictionary<int, int>();

        for (int i = 0; i < n; i++)
        {
            if (!map.ContainsKey(nums[i]))
            {
                map[nums[i]] = 0;
            }
            map[nums[i]]++;
        }

        foreach (var item in map)
        {
            if (item.Value % 2 != 0)//Odd
            {
                return item.Key;
            }
        }
        return -1;
    }
}