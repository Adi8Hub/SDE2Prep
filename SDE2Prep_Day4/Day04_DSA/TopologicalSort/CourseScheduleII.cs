using System;
using System.Collections.Generic;

// int numCourses = 2;
// int[][] prerequisites = [[1, 0]];
int numCourses = 4;
int[][] prerequisites = [[1, 0], [2, 0], [3, 1], [3, 2]];

int[] ans = Program.Order(numCourses, prerequisites);
Console.WriteLine($"{string.Join(",", ans)}");

public class Program
{
    public static int[] Order(int numCourses, int[][] prereq)
    {
        List<int>[] adj = new List<int>[numCourses];
        for (int i = 0; i < numCourses; i++)
        {
            adj[i] = new List<int>();
        }

        int[] inDegree = new int[numCourses];

        foreach (var edge in prereq)
        {
            var from = edge[1];
            var to = edge[0];
            adj[from].Add(to);
            inDegree[to]++;
        }

        Queue<int> q = new();

        for (int i = 0; i < numCourses; i++)
        {
            if (inDegree[i] == 0)
                q.Enqueue(i);
        }

        int totalCourses = 0;
        var res = new List<int>();

        while (q.Count > 0)
        {
            var curr = q.Dequeue();
            totalCourses++;
            res.Add(curr);

            foreach (var nbr in adj[curr])
            {
                inDegree[nbr]--;
                if (inDegree[nbr] == 0) q.Enqueue(nbr);
            }
        }

        if (totalCourses == numCourses)
            return res.ToArray();
        else
            return new int[] { };

    }
}


/*                                              210. Course Schedule II

There are a total of numCourses courses you have to take, labeled from 0 to numCourses - 1. You are given an array prerequisites where prerequisites[i] = [ai, bi] indicates that you must take course bi first if you want to take course ai.

For example, the pair [0, 1], indicates that to take course 0 you have to first take course 1.
Return the ordering of courses you should take to finish all courses. If there are many valid answers, return any of them. If it is impossible to finish all courses, return an empty array.

 

Example 1:

Input: numCourses = 2, prerequisites = [[1,0]]
Output: [0,1]
Explanation: There are a total of 2 courses to take. To take course 1 you should have finished course 0. So the correct course order is [0,1].
Example 2:

Input: numCourses = 4, prerequisites = [[1,0],[2,0],[3,1],[3,2]]
Output: [0,2,1,3]
Explanation: There are a total of 4 courses to take. To take course 3 you should have finished both courses 1 and 2. Both courses 1 and 2 should be taken after you finished course 0.
So one correct course order is [0,1,2,3]. Another correct ordering is [0,2,1,3].
Example 3:

Input: numCourses = 1, prerequisites = []
Output: [0]
 

Constraints:

1 <= numCourses <= 2000
0 <= prerequisites.length <= numCourses * (numCourses - 1)
prerequisites[i].length == 2
0 <= ai, bi < numCourses
ai != bi
All the pairs [ai, bi] are distinct.
*/