using System;
using System.Security.Cryptography;

Console.WriteLine("TODO: Run // TODO: Leetcode 53 - Maximum Subarray");

int[] nums = [-2, 1, -3, 4, -1, 2, 1, -5, 4];
// int[] nums = [5, 4, -1, 7, 8];
var ans = Program.MaxSubArray(nums);
System.Console.WriteLine($"{ans}");
System.Console.WriteLine();
var arr = Program.MaxSumSubArray(nums);
System.Console.WriteLine($"Array is: {string.Join(",", arr)}");


public class Program
{

    public static int MaxSubArray(int[] nums)
    {
        #region 1
        // int n = nums.Length;
        // int maxSum = int.MinValue;
        // for (int i = 0; i < n; i++)
        // {
        //     int currSum = 0;
        //     for (int j = i; j < n; j++)
        //     {
        //         currSum += nums[j];
        //         maxSum = Math.Max(maxSum, currSum);
        //     }
        // }
        // return maxSum;
        #endregion

        #region 2
        // int currSum = nums[0];
        // int maxSum = nums[0];

        // int n = nums.Length;

        // for (int i = 1; i < n; i++)
        // {
        //     currSum = Math.Max(currSum + nums[i], nums[i]);
        //     maxSum = Math.Max(maxSum, currSum);
        // }
        // return maxSum;
        #endregion

        #region 3
        // return DnC(nums, 0, nums.Length - 1);
        #endregion

        #region 4
        // Similar to Kadane - here dp[] is used to maintain running sum max
        int n = nums.Length;
        int[] dp = new int[nums.Length];
        dp[0] = nums[0];
        int maxSum = nums[0];


        for (int i = 1; i < n; i++)
        {
            dp[i] = Math.Max(dp[i - 1] + nums[i], nums[i]);
            maxSum = Math.Max(maxSum, dp[i]);
        }
        return maxSum;
        #endregion


    }

    #region 3.1
    // static int DnC(int[] nums, int left, int right)
    // {
    //     if (left == right) return nums[left];

    //     int mid = (left + right) / 2;
    //     int leftSum = DnC(nums, left, mid);
    //     int rightSum = DnC(nums, mid + 1, right);
    //     int crossSum = CrossSum(nums, left, mid, right);

    //     return Math.Max(leftSum, Math.Max(rightSum, crossSum));
    // }

    // static int CrossSum(int[] nums, int left, int mid, int right)
    // {
    //     //Cross Sum : some parts in left and some parts in right half
    //     //ie. crossum max would include mid points
    //     //hence while calculating leftSum Max, it must have mid,thus starting from mid
    //     int leftMax = int.MinValue;
    //     int currSum = 0;
    //     for (int i = mid; i >= 0; i--)
    //     {
    //         currSum += nums[i];
    //         leftMax = Math.Max(leftMax, currSum);
    //     }

    //     int rightMax = int.MinValue;
    //     currSum = 0;
    //     for (int j = mid + 1; j <= right; j++)
    //     {
    //         currSum += nums[j];
    //         rightMax = Math.Max(rightMax, currSum);
    //     }

    //     return leftMax + rightMax;
    // }

    #endregion

    #region 5 -- Returns the max size subarray of max sum
    public static int[] MaxSumSubArray(int[] nums)
    {
        int currSum = nums[0];
        int maxSum = nums[0];

        int start = 0, end = 0;
        int tempStart = 0;

        for (int i = 1; i < nums.Length; i++)
        {
            currSum += nums[i];

            if (currSum < nums[i])//we need larger sum, so curr value is larger than currSum till previous element
            {
                currSum = nums[i];
                tempStart = i;//start resets to this point

            }


            if (currSum > maxSum)
            {
                maxSum = currSum;
                start = tempStart;
                end = i;
            }
        }
        return nums[start..(end + 1)];
    }

    #endregion
}


///// 1. Brute - n^2
////// 2. Kadane - n
////// 3. DnC - nlogn
////// 4. DP - n
////// 5. To return the maxSubarraySum


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