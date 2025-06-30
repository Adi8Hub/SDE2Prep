
using System;

int[] arr = [1, 2, 3, 4, 5];
int d = 2;
RightRotate.RotateArr(arr, d);
System.Console.WriteLine($"{string.Join(",", arr)}");
// 4 5 1 2 3
class RightRotate
{
    //// 1. Using extra temp array
    // public static void RotateArr(int[] arr, int d)
    // {
    //     int n = arr.Length;
    //     d = d % n; //id d>n
    //     int[] temp = new int[d];

    //     for (int i = 0; i < d; i++)
    //         temp[i] = arr[n - d + i];// temp = 4 5

    //     for (int i = n - 1; i >= d; i--)
    //         arr[i] = arr[i - d];

    //     for (int i = 0; i < d; i++)
    //         arr[i] = temp[i];
    // }

    // 2. Using Reversal Method
    // 1 2 3 4 5
    // 3 2 1 5 4
    // 4 5 1 2 3
    public static void RotateArr(int[] arr, int d)
    {
        int n = arr.Length;
        d = d % n; //id (d > n)

        Array.Reverse(arr, 0, n - d);
        Array.Reverse(arr, n - d, d);
        Array.Reverse(arr);

    }

    //3. ROtate By One place d times
}

