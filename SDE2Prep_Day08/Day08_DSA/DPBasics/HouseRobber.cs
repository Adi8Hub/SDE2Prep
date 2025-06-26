using System;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("TODO: Run // TODO: Leetcode 198 - House Robber");
    }

    public int Rob(int[] nums)
    {
        if (nums.Length == 0) return 0;
        if (nums.Length == 1) return nums[0];

        int[] dp = new int[nums.Length];
        dp[0] = nums[0];
        dp[1] = Math.Max(nums[0], nums[1]);

        for (int i = 2; i < nums.Length; i++)
        {
            dp[i] = Math.Max(dp[i - 1], dp[i - 2] + nums[i]);
        }

        return dp[nums.Length - 1];
    }


    // Space - optimised
    public int Rob(int[] nums)
    {
        if (nums.Length == 0) return 0;
        if (nums.Length == 1) return nums[0];


        int prev2 = nums[0];
        int prev1 = Math.Max(nums[0], nums[1]);

        for (int i = 2; i < nums.Length; i++)
        {
            dp[i] = Math.Max(prev1, prev2 + nums[i]);
        }

        return dp[nums.Length - 1];
    }

}
