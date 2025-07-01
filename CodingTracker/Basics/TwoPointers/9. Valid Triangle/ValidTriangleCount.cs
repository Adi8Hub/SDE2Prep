public class Solution
{
    public int TriangleNumber(int[] nums)
    {
        int n = nums.Length;
        int count = 0;
        Array.Sort(nums);

        for (int k = n - 1; k >= 2; k--)//Fix 3rd and work on 1st & 2nd element using 2 pointers
        {
            int i = 0, j = k - 1;
            while (i < j)
            {
                if (nums[i] + nums[j] > nums[k])//sum is more, then shrink from right
                {
                    // as this is valid oncdition for triangle
                    // all nos within i to j-1 make valid pair with j
                    count += j - i;
                    j--;
                }
                else
                    i++;
            }
        }
        return count;
    }
}

/*
For Valid Triangle : a+b>c
Fix c from the end, use 2 pointers left and right which satisfies above condition

if match then all nos within left to right-1 will make valid pair with right, so right-left will be added to the count
and since sum is more, then reduce by shrinking right
else shrink left to get more sum

NOTE: to use pointers, sort the array first

*/