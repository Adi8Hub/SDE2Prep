/*
    Acc to Q: |nums[i]-nums[j]| == K

    Can be written as:
    1.  nums[i]-nums[j] == K
    ==> nums[j] = nums[i] - K

    2.  nums[j]-nums[i] == K
    ==> nums[j] = nums[i] + K

    Using map, we can put curr element in the map
    Before putting it, check if (num-K) , (num + K) exists in the map

    if yes, increase the count by its value

*/

public class Solution
{
    public int CountKDifference(int[] nums, int k)
    {
        Dictionary<int, int> freq = new Dictionary<int, int>();
        int count = 0;

        foreach (int num in nums)
        {
            if (freq.ContainsKey(num - k))
                count += freq[num - k];

            if (freq.ContainsKey(num + k))
                count += freq[num + k];

            if (!freq.ContainsKey(num))
                freq[num] = 0;

            freq[num]++;
        }

        return count;
    }
}
