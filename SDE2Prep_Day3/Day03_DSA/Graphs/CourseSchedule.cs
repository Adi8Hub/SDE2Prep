// using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Internal;


Console.WriteLine("TODO: Run // TODO: Leetcode 207 - Course Schedule");
int numCourses = 2;
int[][] prerequisites = [[1, 0]];
// int numCourses = 2;
// int[][] prerequisites = [[1, 0], [0, 1]];

bool ans = Program.CanFinish(numCourses, prerequisites);
Console.WriteLine($"Can Finish: {ans}");

public class Program
{
    // DFS
    public static bool CanFinish(int numCourses, int[][] prereq)
    {
        List<int>[] adj = new List<int>[numCourses];
        for (int i = 0; i < numCourses; i++)
        {
            adj[i] = new List<int>();
        }

        foreach (var edge in prereq)
        {
            var from = edge[1];
            var to = edge[0];
            adj[from].Add(to);
        }

        bool[] visited = new bool[numCourses];
        bool[] recStack = new bool[numCourses];

        for (int i = 0; i < numCourses; i++)
        {
            if (!visited[i])
            {
                if (HasCycle(adj, visited, recStack, i))
                    return false;
            }
        }
        return true;
    }

    private static bool HasCycle(List<int>[] adj, bool[] visited, bool[] recStack, int i)
    {
        visited[i] = true;
        recStack[i] = true;

        foreach (var nbr in adj[i])
        {
            if (!visited[nbr])
            {
                if (HasCycle(adj, visited, recStack, nbr))
                    return true;
            }
            else if (recStack[i])
                return true;
        }
        recStack[i] = false;
        return false;
    }



    // BFS - Kahn's algorithm - 
    // This sorts the courses in order it's taken, if cycle exists then it can't be sorted

    // public static bool CanFinish(int numCourses, int[][] prereq)
    // {
    //     List<int>[] adj = new List<int>[numCourses];
    //     for (int i = 0; i < numCourses; i++)
    //     {
    //         adj[i] = new List<int>();
    //     }

    //     int[] inDegree = new int[numCourses];

    //     foreach (var edge in prereq)
    //     {
    //         var from = edge[1];
    //         var to = edge[0];
    //         adj[from].Add(to);
    //         inDegree[to]++;
    //     }

    //     Queue<int> q = new();

    //     for (int i = 0; i < numCourses; i++)
    //     {
    //         if (inDegree[i] == 0)
    //             q.Enqueue(i);
    //     }

    //     int totalCourses = 0;
    //     while (q.Count > 0)
    //     {
    //         var curr = q.Dequeue();
    //         totalCourses++;
    //         foreach (var nbr in adj[curr])
    //         {
    //             inDegree[nbr]--;
    //             if (inDegree[nbr] == 0) q.Enqueue(nbr);
    //         }
    //     }

    //     if (totalCourses == numCourses) return true;
    //     else return false;

    // }
}

/*      Approach
COnvert the array to adjList graph
Calculate Toposort using Kahn's algo/DFS
if sort count != numCourses, return false else true

*/

/*
There are a total of numCourses courses you have to take, labeled from 0 to numCourses - 1. You are given an array prerequisites where prerequisites[i] = [ai, bi] indicates that you must take course bi first if you want to take course ai.

For example, the pair [0, 1], indicates that to take course 0 you have to first take course 1.
Return true if you can finish all courses. Otherwise, return false.

 

Example 1:

Input: numCourses = 2, prerequisites = [[1,0]]
Output: true
Explanation: There are a total of 2 courses to take. 
To take course 1 you should have finished course 0. So it is possible.
Example 2:

Input: numCourses = 2, prerequisites = [[1,0],[0,1]]
Output: false
Explanation: There are a total of 2 courses to take. 
To take course 1 you should have finished course 0, and to take course 0 you should also have finished course 1. So it is impossible.
 

Constraints:

1 <= numCourses <= 2000
0 <= prerequisites.length <= 5000
prerequisites[i].length == 2
0 <= ai, bi < numCourses
All the pairs prerequisites[i] are unique.
*/