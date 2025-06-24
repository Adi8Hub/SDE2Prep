using System;
int numCourses = 2;
int[][] prerequisites = [[1, 0]];
// int numCourses = 2;
// int[][] prerequisites = [[1, 0], [0, 1]];

bool ans = Program.CanFinish(numCourses, prerequisites);
Console.WriteLine($"Can Finish: {ans}");
public class Program
{
    public static bool CanFinish(int numCourses, int[][] prereq)
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
        while (q.Count > 0)
        {
            var curr = q.Dequeue();
            totalCourses++;
            foreach (var nbr in adj[curr])
            {
                inDegree[nbr]--;
                if (inDegree[nbr] == 0) q.Enqueue(nbr);
            }
        }

        if (totalCourses == numCourses) return true;
        else return false;

    }
}
