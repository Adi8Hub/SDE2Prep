using System;
using System.Collections.Generic;

var sol = new Solution();


// int[] nums = { 2, 7, 11, 15 };
// int target = 9;
int[] nums = [3, 2, 4];
int target = 6;


var res = sol.TwoSum(nums, target);
Console.WriteLine($"[{res[0]}, {res[1]}]");

public class Solution
{
    public int[] TwoSum(int[] nums, int target)
    {

        int n = nums.Length;

        for (int i = 0; i < n - 1; i++)
        {
            for (int j = i + 1; j < n; j++)
            {
                int sum = nums[i] + nums[j];
                if (sum == target)
                    return [i, j];
            }
        }
        return [];
    }

    // Brute
    /*
    public int[] TwoSum(int[] nums, int target)
    {

        int n = nums.Length;

        for (int i = 0; i < n - 1; i++)
        {
            for (int j = i + 1; j < n; j++)
            {
                int sum = nums[i] + nums[j];
                if (sum == target)
                    return [i, j];
            }
        }
        return [];
    }
    */
}

// LC 1
/*
Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.

You may assume that each input would have exactly one solution, and you may not use the same element twice.

You can return the answer in any order.

Example 1:

Input: nums = [2,7,11,15], target = 9
Output: [0,1]
Explanation: Because nums[0] + nums[1] == 9, we return [0, 1].
Example 2:

Input: nums = [3,2,4], target = 6
Output: [1,2]
*/