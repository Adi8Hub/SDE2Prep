
using System;

int[] arr = [1, 2, 3, 4, 5];
int d = 2;
LeftRotate.RotateArr(arr, d);
System.Console.WriteLine($"{string.Join(",", arr)}");

class LeftRotate
{
    // 1. Using extra temp array
    // public static void RotateArr(int[] arr, int d)
    // {
    //     int n = arr.Length;
    //     int[] temp = new int[d];
    //     Array.Copy(arr, temp, d);

    //     for (int i = 0; i < n - d; i++)
    //     {
    //         arr[i] = arr[i + d];
    //     }

    //     for (int i = n - d; i < n; i++)
    //     {
    //         arr[i] = temp[i - (n - d)];
    //     }
    // }

    // 2. Using Reversal Method
    // 5 4 3 2 1 -- 345 21 -- 345 12
    public static void RotateArr(int[] arr, int d)
    {
        int n = arr.Length;
        d = d % n; //id (d > n)

        Array.Reverse(arr);
        Array.Reverse(arr, 0, n - d);
        Array.Reverse(arr, n - d, d);

    }

    //3. ROtate By One place d times
}

