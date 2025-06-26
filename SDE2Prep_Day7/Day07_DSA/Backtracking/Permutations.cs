public class Solution
{
    public IList<IList<int>> Permute(int[] nums) // n * n!
    {
        IList<IList<int>> res = new List<IList<int>>();
        List<int> temp = new();

        bool[] visited = new bool[nums.Length];
        solve(nums, temp, res, visited);
        return res;
    }

    void solve(int[] nums, List<int> temp, IList<IList<int>> res, bool[] visited)
    {
        if (temp.Count >= nums.Length)
        {
            res.Add(new List<int>(temp));
        }

        for (int i = 0; i < nums.Length; i++)
        {
            if (visited[i]) continue;

            visited[i] = true;
            temp.Add(nums[i]);
            solve(nums, temp, res, visited);
            temp.RemoveAt(temp.Count - 1);
            visited[i] = false;
        }
    }
}

///////////////////                 IN Place , SWAP
////// 
public class Solution
{
    public IList<IList<int>> Permute(int[] nums)
    {
        IList<IList<int>> res = new List<IList<int>>();

        solve(nums, 0, res);
        return res;
    }

    void solve(int[] nums, int idx, IList<IList<int>> res)
    {
        if (idx >= nums.Length)
        {
            res.Add(new List<int>(nums));
        }

        for (int i = idx; i < nums.Length; i++)
        {
            (nums[i], nums[idx]) = (nums[idx], nums[i]);
            solve(nums, idx + 1, res);
            (nums[i], nums[idx]) = (nums[idx], nums[i]);
        }
    }
}




/*              LC 48 ---- ALSO SIMILAR TO PERMUTATIONS OF A GIVEN STRING
Given an array nums of distinct integers, return all the possible permutations. You can return the answer in any order.

 

Example 1:

Input: nums = [1,2,3]
Output: [[1,2,3],[1,3,2],[2,1,3],[2,3,1],[3,1,2],[3,2,1]]
Example 2:

Input: nums = [0,1]
Output: [[0,1],[1,0]]
Example 3:

Input: nums = [1]
Output: [[1]]
 

Constraints:

1 <= nums.length <= 6
-10 <= nums[i] <= 10
All the integers of nums are unique.
*/