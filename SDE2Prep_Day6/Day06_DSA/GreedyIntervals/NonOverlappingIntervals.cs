public class Solution
{
    public int EraseOverlapIntervals(int[][] intervals)
    {

        Array.Sort(intervals, (a, b) => a[1].CompareTo(b[1]));
        int res = 0;
        int prevEnd = intervals[0][1];

        for (int i = 1; i < intervals.Length; i++)
        {
            int start = intervals[i][0];
            int end = intervals[i][1];
            if (start >= prevEnd)
            {//no overlap
                prevEnd = end;
            }
            else
            {
                res++;
                // prevEnd = Math.Min(end, prevEnd);
            }
        }
        return res;







        // Approach 1: Sort the arrays based onstarting time
        // Steps:
        // 1. Sort
        // 2. Set first element as last, and iterate from 1 o n-1
        // 3. if(last's end <= curr's start)// Non overlapping case
        //         move last and curr
        //     else if(last end <= curr end)//Overlapping
        //         delete interval which has later ending i.e., move curr
        //     else if(last end > curr end)
        //         move last to curr and move curr to it's next


        // Approach 2: Sort the arrays based on ending time

    }
}