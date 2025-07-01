public class Solution
{
    public int[] TwoSum(int[] nums, int target)
    {
        int n = nums.Length;

        int left = 0, right = n - 1;

        while (left < right)
        {
            int sum = nums[left] + nums[right];

            if (sum == target)
                return new int[] { left + 1, right + 1 };
            else if (sum < target)
                left++;
            else
                right--;
        }
        return new int[0];
    }
}

// Using 2 pointers
// O(n)


// Another approach could be Binary Search
// O(nlogn)
// Loop over all the elements
// Within the above selected element perform Binary search with search spacec , +1 of the above and last index
// for target, use complement of the selected element