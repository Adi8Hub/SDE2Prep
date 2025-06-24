// using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using Internal;


Console.WriteLine("TODO: Run // TODO: Leetcode 310 - Minimum Height Trees (BFS Pruning)");


// int n = 4;
// int[][] edges = [[1, 0], [1, 2], [1, 3]];
int n = 6;
int[][] edges = [[3, 0], [3, 1], [3, 2], [3, 4], [5, 4]];
var ans = Program.FindMHT(n, edges);

Console.WriteLine($"{string.Join(",", ans)}");

public class Program
{
    public static IList<int> FindMHT(int n, int[][] edges)
    {
        if (n == 1) return new List<int> { 0 };

        // 1. Build Graph
        List<HashSet<int>> graph = new();
        for (int i = 0; i < n; i++)
        {
            graph.Add(new HashSet<int>());

        }

        foreach (var edge in edges)
        {
            var from = edge[0];
            var to = edge[1];
            graph[from].Add(to);
            graph[to].Add(from);
        }
        ///

        ///     Add initial leaves. Nodes containing only 1 nbr are leaves
        ///     /// NOn -leaves will have nbr = 2 or 3
        List<int> leaves = new();
        for (int i = 0; i < n; i++)
        {
            if (graph[i].Count == 1)
                leaves.Add(i);
        }

        // WOrk on first layer of leaves
        // Get the nbr of leaf node, Unlink it
        //if the nbr now has pnly 1 nbr , then it is part of next layer of leaf nodes
        int remainingNodes = n;
        while (remainingNodes > 2)
        {
            List<int> newLeaves = new();
            foreach (var leaf in leaves)
            {
                // if (graph[leaf].Count == 0) continue;

                var nbr = graph[leaf].First();
                graph[nbr].Remove(leaf);
                // graph[leaf].Clear();

                if (graph[nbr].Count == 1)
                {
                    newLeaves.Add(nbr);
                }
            }
            remainingNodes -= leaves.Count;
            leaves = newLeaves;
        }

        //Last remaining node or last 2 nodes are MHTs
        return leaves;
    }


}


/*      APPROACH
To get roots with minimum height:
1. Get all the leaf nodes, unlink them, then do the same for the new leaf nodes
*/



/*
A tree is an undirected graph in which any two vertices are connected by exactly one path. In other words, any connected graph without simple cycles is a tree.

Given a tree of n nodes labelled from 0 to n - 1, and an array of n - 1 edges where edges[i] = [ai, bi] indicates that there is an undirected edge between the two nodes ai and bi in the tree, you can choose any node of the tree as the root. When you select a node x as the root, the result tree has height h. Among all possible rooted trees, those with minimum height (i.e. min(h))  are called minimum height trees (MHTs).

Return a list of all MHTs' root labels. You can return the answer in any order.

The height of a rooted tree is the number of edges on the longest downward path between the root and a leaf.

 

Example 1:


Input: n = 4, edges = [[1,0],[1,2],[1,3]]
Output: [1]
Explanation: As shown, the height of the tree is 1 when the root is the node with label 1 which is the only MHT.
Example 2:


Input: n = 6, edges = [[3,0],[3,1],[3,2],[3,4],[5,4]]
Output: [3,4]
 

Constraints:

1 <= n <= 2 * 104
edges.length == n - 1
0 <= ai, bi < n
ai != bi
All the pairs (ai, bi) are distinct.
The given input is guaranteed to be a tree and there will be no repeated edges.
*/