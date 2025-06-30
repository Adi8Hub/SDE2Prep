public class Solution
{
    public void SortColors(int[] nums)
    {
        int n = nums.Length;
        int low = 0, mid = 0, high = n - 1;

        while (mid <= high)
        {
            if (nums[mid] == 0)
            {
                (nums[low], nums[mid]) = (nums[mid], nums[low]);
                low++; mid++;
            }
            else if (nums[mid] == 1) mid++;
            else
            {
                (nums[high], nums[mid]) = (nums[mid], nums[high]);
                high--;
            }
        }
    }
}