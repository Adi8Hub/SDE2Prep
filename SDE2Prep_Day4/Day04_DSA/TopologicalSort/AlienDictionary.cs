// using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Internal;

string[] input = ["wrt", "wrf", "er", "ett", "rftt"];
var ans = Program.AlienOrder(input);
Console.WriteLine($"{ans}");

public class Program
{
    public static string AlienOrder(string[] words)
    {
        // Build Directed Graph for character nodes
        // Perform Kahn's algo and store the chars in a string

        Dictionary<char, List<char>> graph = new Dictionary<char, List<char>>();
        var inDegree = new Dictionary<char, int>();

        //1.Init graph
        foreach (string word in words)
        {
            foreach (char w in word)
            {
                if (!graph.ContainsKey(w)) graph[w] = new List<char>();

                if (!inDegree.ContainsKey(w)) inDegree[w] = 0;
            }
        }


        // Iterate over the input array, take 2 words out of it at a time
        // Compare first differenet char between them.
        // first diff char from 1st word should then be linked to the second word's char
        // also calculate indegree while doing tha above

        // Add links and neighbors to the graph nodes
        for (int i = 0; i < words.Length - 1; i++)
        {
            string w1 = words[i], w2 = words[i + 1];

            // first word(not the character) is bigger and smaller second word is prefix
            // then its invalid
            if (w1.Length > w2.Length && w1.StartsWith(w2)) return "";

            int len = Math.Min(w1.Length, w2.Length);

            for (int j = 0; j < len; j++)
            {
                if (w1[j] != w2[j])
                {
                    graph[w1[j]].Add(w2[j]);
                    inDegree[w2[j]]++;
                }
            }
        }

        // Perform Kahn's algo
        Queue<char> q = new();
        foreach (var keyVal in inDegree)
        {
            if (keyVal.Value == 0)
            {
                q.Enqueue(keyVal.Key);
            }
        }

        StringBuilder res = new();
        while (q.Count > 0)
        {
            var curr = q.Dequeue();
            res.Append(curr);

            foreach (var nbr in graph[curr])
            {
                inDegree[nbr]--;
                if (inDegree[nbr] == 0)
                {
                    q.Enqueue(nbr);
                }
            }
        }

        if (inDegree.Count == res.Length)
            return res.ToString();
        else
            return "";
    }
}

/*
Description
There is a new alien language which uses the latin alphabet. However, the order among letters are unknown to you. You receive a list of non-empty words from the dictionary, where words are sorted lexicographically by the rules of this new language. Derive the order of letters in this language.

You may assume all letters are in lowercase
At first different letter, if the letter in s precedes the letter in t in the given list order, then the dictionary order of s is less than t
The dictionary is invalid, if string a is prefix of string b and b is appear before a
If the order is invalid, return an empty string
There may be multiple valid order of letters, return the smallest in normal lexicographical order
The letters in one string are of the same rank by default and are sorted in Human dictionary order
Example
Example 1:

Input：["wrt","wrf","er","ett","rftt"]
Output："wertf"
Explanation：
from "wrt"and"wrf" ,we can get 't'<'f'
from "wrt"and"er" ,we can get 'w'<'e'
from "er"and"ett" ,we can get 'r'<'t'
from "ett"and"rftt" ,we can get 'e'<'r'
So return "wertf"
Example 2:

Input：["z","x"]
Output："zx"
Explanation：
from "z" and "x"，we can get 'z' < 'x'
So return "zx"
*/