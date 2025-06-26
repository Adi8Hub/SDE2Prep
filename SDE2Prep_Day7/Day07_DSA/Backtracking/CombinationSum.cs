// using System;
using System.Collections.Generic;
using Internal;

int[] candidates = [2, 3, 6, 7];
int target = 7;
var lists = Program.CombinationSum(candidates, target);

foreach (var subList in lists)
{
    Console.WriteLine($"[{string.Join(",", subList)}]");
}
public class Program
{

    public static IList<IList<int>> CombinationSum(int[] candidates, int target)
    {
        List<IList<int>> res = new();
        solve(candidates, target, 0, new List<int>(), res);
        return res;
    }

    static void solve(int[] candidates, int target, int idx, List<int> temp, List<IList<int>> res)
    {
        if (target == 0)
        {
            res.Add(new List<int>(temp));
            return;
        }

        if (target < 0 || idx >= candidates.Length)
            return;

        //Pick
        temp.Add(candidates[idx]);

        solve(candidates, target - candidates[idx], idx, temp, res);
        temp.RemoveAt(temp.Count - 1);
        //Skip
        solve(candidates, target, idx + 1, temp, res);
    }
}


/*
Given an array of distinct integers candidates and a target integer target, return a list of all unique combinations of candidates where the chosen numbers sum to target. You may return the combinations in any order.

The same number may be chosen from candidates an unlimited number of times. Two combinations are unique if the frequency of at least one of the chosen numbers is different.

The test cases are generated such that the number of unique combinations that sum up to target is less than 150 combinations for the given input.

 

Example 1:

Input: candidates = [2,3,6,7], target = 7
Output: [[2,2,3],[7]]
Explanation:
2 and 3 are candidates, and 2 + 2 + 3 = 7. Note that 2 can be used multiple times.
7 is a candidate, and 7 = 7.
These are the only two combinations.
Example 2:

Input: candidates = [2,3,5], target = 8
Output: [[2,2,2,2],[2,3,3],[3,5]]
Example 3:

Input: candidates = [2], target = 1
Output: []
 

Constraints:

1 <= candidates.length <= 30
2 <= candidates[i] <= 40
All elements of candidates are distinct.
1 <= target <= 40
*/