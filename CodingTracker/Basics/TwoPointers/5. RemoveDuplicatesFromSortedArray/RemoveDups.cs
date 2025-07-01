class DuplicatesRemoval
{
    public static int RemoveDuplicates(int[] arr)
    {
        if (arr == null || arr.Length == 0) return 0;

        int writeIndex = 1;  // Next position to write a unique element

        for (int readIndex = 1; readIndex < arr.Length; readIndex++)
        {
            if (arr[readIndex] != arr[readIndex - 1])
            {
                arr[writeIndex] = arr[readIndex];
                writeIndex++;
            }
        }

        return writeIndex;  // Number of unique elements
    }

}

/*
Constraint mentions returned array will have atleast 1 element. Then that would be first element
Hence start from index 1

if this index and its previous elements are not same, then store the number at this index and move it

At the end , return this index as that will denote the size of the modified array
*/