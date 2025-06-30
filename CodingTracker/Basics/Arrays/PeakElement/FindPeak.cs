public class Solution
{
    public int FindPeakElement(int[] nums)
    {
        int n = nums.Length;

        int left = 0, right = n - 1;

        while (left < right)
        {
            int mid = left + (right - left) / 2;

            if (nums[mid] < nums[mid + 1]) // Mid is less than its next, increasing graph
            {
                left = mid + 1;
            }
            else // mid is larger than its next, decreasing graph, could be an answer
            {
                right = mid;
            }
        }
        return right;
    }
}