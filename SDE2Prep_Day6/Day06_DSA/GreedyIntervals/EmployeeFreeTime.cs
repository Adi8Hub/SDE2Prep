/**
 * Definition of Interval:
 * public class Interval {
 *     public int start, end;
 *     Interval(int start, int end) {
 *         this.start = start;
 *         this.end = end;
 *     }
 * }
 */

using System;
using System.Collections;
using System.Collections.Generic;

namespace lintcode
{
    class Solution
    {
        /**
         * @param schedule: a list schedule of employees
         * @return: Return a list of finite intervals 
         */
        public List<Interval> EmployeeFreeTime(int[][] schedule)
        {
            // Write your code here
            List<Interval> allBusy = new List<Interval>();

            // Convert 1D intervals to Interval objects
            foreach (var emp in schedule)
            {
                for (int i = 0; i < emp.Length; i += 2)
                {
                    allBusy.Add(new Interval(emp[i], emp[i + 1]));
                }
            }

            // Sort by start time
            allBusy.Sort((a, b) => a.start.CompareTo(b.start));

            // Merge overlapping busy intervals
            List<Interval> result = new List<Interval>();
            var prevEnd = allBusy[0].end;

            for (int i = 1; i < allBusy.Count; i++)
            {
                Interval curr = allBusy[i];
                if (prevEnd < curr.start)
                {
                    result.Add(new Interval(prevEnd, curr.start));
                }
                prevEnd = Math.Max(prevEnd, curr.end);
            }
            return result;
        }
    }
}

/* 
Description
We are given a list schedule of employees, which represents the working time for each employee.

Each employee has a list of non-overlapping Intervals, and these intervals are in sorted order.

Return the list of finite intervals representing common, positive-length free time for all employees, also in sorted order.

The Intervals is an 1d-array. Each two numbers shows an interval. For example, [1,2,8,10] represents that the employee works in [1,2] and [8,10].

Also, we wouldn't include intervals like [5, 5] in our answer, as they have zero length.

1.schedule and schedule[i] are lists with lengths in range [1, 100].
2.0 <= schedule[i].start < schedule[i].end <= 10^8.

Example
Example 1:

Input：schedule = [[1,2,5,6],[1,3],[4,10]]
Output：[(3,4)]
Explanation:
There are a total of three employees, and all common
free time intervals would be [-inf, 1], [3, 4], [10, inf].
We discard any intervals that contain inf as they aren't finite.
Example 2:

Input：schedule = [[1,3,6,7],[2,4],[2,5,9,12]]
Output：[(5,6),(7,9)]
Explanation：
There are a total of three employees, and all common
free time intervals would be [-inf, 1], [5, 6], [7, 9],[12,inf].
We discard any intervals that contain inf as they aren't finite.
*/