using System;
using System.Collections.Generic;

// int[] arr = [9, 9, 9];
int[] arr = [5, 6, 7, 8];

System.Console.WriteLine($"{string.Join(",", AddOne.Add(arr))}");

class AddOne
{
    public static int[] Add(int[] arr)
    {
        int n = arr.Length;
        int carry = 1;
        List<int> res = new();

        for (int i = n - 1; i >= 0; i--)
        {
            int curr = arr[i] + carry;
            res.Insert(0, curr % 10);
            carry = curr / 10;
        }

        if (carry > 0)
            res.Insert(0, carry);

        return res.ToArray();
    }
}