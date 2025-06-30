public class Solution
{
    public static int MaxProfit(int[] prices)
    {
        int minPrice = int.MaxValue;
        int maxProfit = 0;

        foreach (int price in prices)
        {
            if (price < minPrice)
                minPrice = price;
            else
                maxProfit = Math.Max(maxProfit, price - minPrice);
        }

        return maxProfit;
    }
}

//////////  *****************************************************
////// 


public class Solution
{
    public static int MaxProfit(int[] prices)
    {
        int maxProfit = 0;

        for (int i = 0; i < prices.Length; i++)
        {
            for (int j = i + 1; j < prices.Length; j++)
            {
                int profit = prices[j] - prices[i];
                if (profit > maxProfit)
                    maxProfit = profit;
            }
        }

        return maxProfit;
    }
}
