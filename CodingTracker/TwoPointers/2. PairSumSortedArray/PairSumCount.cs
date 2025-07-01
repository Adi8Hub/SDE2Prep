int[] arr = [-1, 1, 5, 5, 7];
int target = 6;

int ans = PairSumTargetCount.CountPairs(arr, target);
System.Console.WriteLine($"{ans}");
class PairSumTargetCount
{
    public static int CountPairs(int[] arr, int target)
    {
        int n = arr.Length;
        int left = 0, right = n - 1;
        int count = 0;

        while (left < right)
        {
            int sum = arr[left] + arr[right];

            if (sum < target) left++;
            else if (sum > target) right--;
            else
            {
                // if sum achieved, count occurences of left & right number , as duplicates may be present
                int cnt1 = 0, cnt2 = 0;
                int leftVal = arr[left];
                int rightVal = arr[right];

                while (left < n && leftVal == arr[left])
                {
                    left++;
                    cnt1++;
                }
                while (right >= 0 && rightVal == arr[right])
                {
                    right--;
                    cnt2++;
                }

                //if left & right numbers are same,
                // we need to select 2 out of these
                // apply combinations: n choose k
                if (arr[left] == arr[right])
                    count += cnt1 * (cnt1 - 1) / 2;
                else
                    count += cnt1 * cnt2;//if differnet get all combinations by multiplying


            }
        }
        return count;
    }
}