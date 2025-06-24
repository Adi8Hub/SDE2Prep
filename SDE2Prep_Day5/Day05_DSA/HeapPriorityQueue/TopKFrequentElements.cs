// using System;
using System.Collections.Generic;
using Internal;


Console.WriteLine("TODO: Run // TODO: Leetcode 347 - Top K Frequent Elements");
int[] nums = [1, 1, 1, 2, 2, 3]; int k = 2;
int[] ans = Program.TopKFrequent(nums, k);
Console.WriteLine($"{string.Join(",", ans)}");
public class Program
{
    public static int[] TopKFrequent(int[] nums, int k)
    {
        var map = new Dictionary<int, int>();
        foreach (var num in nums)
        {
            if (!map.ContainsKey(num)) map[num] = 0;
            map[num]++;
        }

        var pq = new PriorityQueue<int, int>();

        foreach (var entry in map)
        {
            pq.Enqueue(entry.Key, entry.Value);

            if (pq.Count > k)
            {
                pq.Dequeue();
            }
        }

        var res = new List<int>();
        while (pq.Count > 0)
        {
            res.Add(pq.Dequeue());
        }
        return res.ToArray();
    }
}

/*
Given an integer array nums and an integer k, return the k most frequent elements. You may return the answer in any order.

 

Example 1:

Input: nums = [1,1,1,2,2,3], k = 2
Output: [1,2]
Example 2:

Input: nums = [1], k = 1
Output: [1]
 

Constraints:

1 <= nums.length <= 105
-104 <= nums[i] <= 104
k is in the range [1, the number of unique elements in the array].
It is guaranteed that the answer is unique.
 

Follow up: Your algorithm's time complexity must be better than O(n log n), where n is the array's size.
*/