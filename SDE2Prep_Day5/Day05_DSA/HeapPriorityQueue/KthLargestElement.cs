// using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Internal;

Console.WriteLine("TODO: Run // TODO: Leetcode 215 - Kth Largest Element in an Array");
// int[] nums = [3, 2, 3, 1, 2, 4, 5, 5, 6];
// int k = 4;
int[] nums = [3, 2, 1, 5, 6, 4];
int k = 2;
int ans = Program.FindKthLargest(nums, k);
Console.WriteLine($"{ans}");
public class Program
{

    public static int FindKthLargest(int[] nums, int k)
    {
        return QuickSelect(nums, 0, nums.Length - 1, nums.Length - k);
    }

    static int QuickSelect(int[] nums, int left, int right, int k)
    {
        if (left == right) return nums[left] = nums[right];

        int pivotIdx = Partition(nums, left, right);
        if (pivotIdx == k) return nums[pivotIdx];
        else if (pivotIdx < k)
            return QuickSelect(nums, pivotIdx + 1, right, k);
        else
            return QuickSelect(nums, left, pivotIdx - 1, k);
    }

    static int Partition(int[] nums, int left, int right)
    {
        int pivot = nums[right];
        int i = left;

        for (int j = left; j < right; j++)
        {
            if (nums[j] <= pivot)
            {
                (nums[i], nums[j]) = (nums[j], nums[i]);
                i++;
            }
        }

        (nums[i], nums[right]) = (nums[right], nums[i]);
        return i;
    }
}

/*
Given an integer array nums and an integer k, return the kth largest element in the array.

Note that it is the kth largest element in the sorted order, not the kth distinct element.

Can you solve it without sorting?

 

Example 1:

Input: nums = [3,2,1,5,6,4], k = 2
Output: 5
Example 2:

Input: nums = [3,2,3,1,2,4,5,5,6], k = 4
Output: 4
 

Constraints:

1 <= k <= nums.length <= 105
-104 <= nums[i] <= 104
*/