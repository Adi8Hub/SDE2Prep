using System;


int[] arr = [5, 6, 1, 2, 3, 4];
int target = 4;
int ans = SearchRotatedSortedArray.Search(arr, target);

Console.WriteLine($"{ans}");


class SearchRotatedSortedArray
{
    public static int Search(int[] arr, int key)
    {
        int n = arr.Length;

        int left = 0, right = n - 1;

        while (left <= right)
        {
            int mid = left + (right - left) / 2;

            if (arr[mid] == key) return mid;

            if (arr[left] <= arr[mid])
            {
                if (arr[left] <= key && key < arr[mid])
                {
                    right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                }
            }
            else
            {
                if (arr[mid] < key && key <= arr[right])
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }
        }

        return -1;

    }
}