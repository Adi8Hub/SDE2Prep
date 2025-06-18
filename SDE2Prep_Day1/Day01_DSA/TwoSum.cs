using System;
using System.Collections.Generic;

var sol = new Solution();
int[] nums = { 2, 7, 11, 15 };
int target = 9;
var res = sol.TwoSum(nums, target);
Console.WriteLine($"[{res[0]}, {res[1]}]");

public class Solution
{
    public int[] TwoSum(int[] nums, int target)
    {
        Dictionary<int, int> map = new();
        for (int i = 0; i < nums.Length; i++)
        {
            int complement = target - nums[i];
            if (map.ContainsKey(complement))
                return new int[] { map[complement], i };
            map[nums[i]] = i;
        }
        return new int[] { -1, -1 };
    }
}

///*******Moved Main outside *********

// public class Program
// {
//     public static void Main(string[] args)
//     {
//         var sol = new Solution();
//         int[] nums = { 2, 7, 11, 15 };
//         int target = 9;
//         var res = sol.TwoSum(nums, target);
//         Console.WriteLine($"[{res[0]}, {res[1]}]");
//     }
// }


