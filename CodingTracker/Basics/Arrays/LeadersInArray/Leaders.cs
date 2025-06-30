
using System.Collections.Generic;

int[] arr = [16, 17, 4, 3, 5, 2];
List<int> ans = LeadersInArray.Leaders(arr);
System.Console.WriteLine($"{string.Join(",", ans)}");

class LeadersInArray
{
    public static List<int> Leaders(int[] arr)
    {
        // // Brute:
        int n = arr.Length;
        List<int> res = new();

        for (int i = 0; i < n; i++)
        {
            bool isLeader = true;
            for (int j = i + 1; j < n; j++)
            {
                if (arr[i] < arr[j])//current is not a leader
                {
                    isLeader = false;
                    break;
                }
            }

            if (isLeader)
                res.Add(arr[i]);
        }
        return res;

        // **********************************************************************
        // // RightToLeft

        int n = arr.Length;
        List<int> res = new();
        res.Add(arr[n - 1]);

        int maxAtRight = arr[n - 1];
        for (int i = n - 2; i >= 0; i--)
        {
            if (arr[i] >= maxAtRight)
            {
                maxAtRight = arr[i];
                res.Add(arr[i]);
            }
        }

        res.Reverse();
        return res;

        //////////////////////////////////////////////////////////////////////////////
        // Stack Based
        int n = arr.Length;
        Stack<int> res = new();
        res.Push(arr[n - 1]);

        int maxAtRight = arr[n - 1];
        for (int i = n - 2; i >= 0; i--)
        {
            if (arr[i] >= maxAtRight)
            {
                maxAtRight = arr[i];
                res.Push(arr[i]);
            }
        }

        return new List<int>(res);
    }
}