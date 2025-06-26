using System;
using System.Collections.Generic;

public class Solution
{
    //                               USING BIT MASKING
    public IList<IList<int>> Subsets(int[] nums)
    {
        IList<IList<int>> res = new List<IList<int>>();

        int n = nums.Length;
        int totalSubs = 1 << n;

        for (int i = 0; i < totalSubs; i++)
        {
            List<int> subList = new();

            for (int j = 0; j < n; j++)
            {
                if (((i >> j) & 1) == 1)
                    subList.Add(nums[j]);//add the num which are set i.e. gives 1 after ANDing with 1
            }
            res.Add(subList);
        }

        return res;
    }

    //                          USING BACKTRACKING with FOR-LOOP
    public IList<IList<int>> Subsets(int[] nums)
    {
        IList<IList<int>> res = new List<IList<int>>();
        List<int> temp = new();

        solve(nums, 0, temp, res);
        return res;
    }

    void solve(int[] nums, int idx, List<int> temp, IList<IList<int>> res)
    {
        res.Add(new List<int>(temp));

        for (int i = idx; i < nums.Length; i++)
        {
            temp.Add(nums[i]);
            solve(nums, i + 1, temp, res);
            temp.RemoveAt(temp.Count - 1);
        }
    }
}


/*                                  LC-78 Subsets
Given an integer array nums of unique elements, return all possible subsets (the power set).

The solution set must not contain duplicate subsets. Return the solution in any order.

 

Example 1:

Input: nums = [1,2,3]
Output: [[],[1],[2],[1,2],[3],[1,3],[2,3],[1,2,3]]
Example 2:

Input: nums = [0]
Output: [[],[0]]
 

Constraints:

1 <= nums.length <= 10
-10 <= nums[i] <= 10
All the numbers of nums are unique.
*/