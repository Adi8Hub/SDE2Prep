
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
        var pq = new PriorityQueue<int, int>();

        foreach (var num in nums)
        {
            pq.Enqueue(num, num);

            if (pq.Count > k) pq.Dequeue();

        }

        return pq.Dequeue();
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