using System;

int[] nums = { 1, 2, 3, 2, 3, 1, 3 };
int ans = FindOdd.GetOddOccurence(nums);
System.Console.WriteLine($"{ans}");
class FindOdd
{
    public static int GetOddOccurence(int[] nums)
    {
        Array.Sort(nums);
        int count = 1;

        for (int i = 1; i < nums.Length; i++)
        {
            if (nums[i] == nums[i - 1])
            {
                count++;
            }
            else
            {
                if (count % 2 != 0)//Odd
                    return nums[i - 1];

                count = 1;
            }
        }
        return nums[nums.Length - 1];
    }
}