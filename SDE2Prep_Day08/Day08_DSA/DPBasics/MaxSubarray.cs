using System;

Console.WriteLine("TODO: Run // TODO: Leetcode 53 - Maximum Subarray");
// int[] nums = [-2, 1, -3, 4, -1, 2, 1, -5, 4];
int[] nums = [5, 4, -1, 7, 8];
var ans = Program.MaxSubArray(nums);
System.Console.WriteLine($"{ans}");

public class Program
{

    public static int MaxSubArray(int[] nums)
    {
        int n = nums.Length;
        int maxSum = int.MinValue;
        for (int i = 0; i < n; i++)
        {
            int currSum = 0;
            for (int j = i; j < n; j++)
            {
                currSum += nums[j];
                maxSum = Math.Max(maxSum, currSum);
            }
        }
        return maxSum;
    }
}


///// 1. Brute - n^2
////// 2. Kadane
////// 3. DnC
////// 4. DP


/*
Given an integer array nums, find the subarray with the largest sum, and return its sum.

 

Example 1:

Input: nums = [-2,1,-3,4,-1,2,1,-5,4]
Output: 6
Explanation: The subarray [4,-1,2,1] has the largest sum 6.
Example 2:

Input: nums = [1]
Output: 1
Explanation: The subarray [1] has the largest sum 1.
Example 3:

Input: nums = [5,4,-1,7,8]
Output: 23
Explanation: The subarray [5,4,-1,7,8] has the largest sum 23.
 

Constraints:

1 <= nums.length <= 105
-104 <= nums[i] <= 104
 

Follow up: If you have figured out the O(n) solution, try coding another solution using the divide and conquer approach, which is more subtle.
*/