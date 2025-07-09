public class Solution
{
    public IList<int> MajorityElement(int[] nums)
    {
        int n = nums.Length;

        int c1 = 0, c2 = 0;
        int el1 = -1, el2 = -1;

        foreach (var num in nums)
        {
            if (num == el1) c1++;
            else if (num == el2) c2++;
            else if (c1 == 0)
            {
                el1 = num;
                c1 = 1;
            }
            else if (c2 == 0)
            {
                el2 = num;
                c2 = 1;
            }
            else
            {
                c1--;
                c2--;
            }
        }

        List<int> res = new();
        c1 = 0; c2 = 0;
        foreach (var num in nums)
        {
            if (num == el1) c1++;
            else if (num == el2) c2++;

        }

        if (c1 > n / 3) res.Add(el1);
        if (c2 > n / 3) res.Add(el2);

        return res;
    }
}

// Always match candidate first, then reset only if you have no match and count is 0.