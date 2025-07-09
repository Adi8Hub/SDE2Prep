// Range Sum Query using Prefix Sum Array
using System;

try
{
    // Read n and q
    Console.WriteLine("Enter space separated number of elements and number of query you want to perform! (\"Press Enter when you are done\")");
    string firstLineInput = Console.ReadLine();
    if (string.IsNullOrEmpty(firstLineInput)) return;
    string[] firstLine = firstLineInput.Split();
    int n = int.Parse(firstLine[0]);
    int q = int.Parse(firstLine[1]);

    // Read the array elements
    Console.WriteLine("Provide all the space separated elements within the array! (\"Press Enter when you are done\")");
    string elementLineInput = Console.ReadLine();
    if (string.IsNullOrEmpty(elementLineInput)) return;
    string[] elements = elementLineInput.Split();
    int[] arr = new int[n + 1]; // 1-indexed array

    // Compute prefix sums
    long[] prefixSum = new long[n + 1];
    for (int i = 1; i <= n; i++)
    {
        arr[i] = int.Parse(elements[i - 1]);
        prefixSum[i] = prefixSum[i - 1] + arr[i];
    }

    // Answer each query in O(1)
    Console.WriteLine("Provide space separated Left & Right Range! (\"Press Enter when you are done\")");
    for (int i = 0; i < q; i++)
    {
        string rangeLine = Console.ReadLine();
        if (string.IsNullOrEmpty(rangeLine)) continue;
        string[] range = rangeLine.Split();
        int L = int.Parse(range[0]);
        int R = int.Parse(range[1]);

        long sum = prefixSum[R] - prefixSum[L - 1];
        Console.WriteLine(sum);
    }
}
catch (Exception ex)
{
    Console.WriteLine("Error: " + ex.Message);
}



