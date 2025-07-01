public class Sum
{
    public static int MinAbsSumPair(int[] arr)
    {
        Array.Sort(arr);
        int i = 0, j = arr.Length - 1;
        int bestSum = arr[i] + arr[j];
        int bestAbsDiff = Math.Abs(bestSum);

        while (i < j)
        {
            int currentSum = arr[i] + arr[j];
            int currDiff = Math.Abs(currentSum);

            // Better if closer to zero, or equal but sum is larger
            if (currDiff < bestAbsDiff || (currDiff == bestAbsDiff && currentSum > bestSum))
            {
                bestAbsDiff = currDiff;
                bestSum = currentSum;
            }

            // Move pointers to potentially get closer to zero
            if (currentSum > 0)
            {
                j--;
            }
            else if (currentSum < 0)
            {
                i++;
            }
            else
            {
                return 0; // Perfect zero
            }
        }
        return bestSum;
    }
}