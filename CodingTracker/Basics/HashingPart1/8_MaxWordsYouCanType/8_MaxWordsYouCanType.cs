using System;
using System.Collections.Generic;

Console.WriteLine(CanBeTypedWords("hello world", "ad")); // Output: 1
class Solution
{
    public static int CanBeTypedWords(string text, string brokenLetters)
    {
        HashSet<char> broken = new HashSet<char>(brokenLetters);
        string[] words = text.Split(' ');
        int count = 0;

        foreach (var word in words)
        {
            bool canType = true;
            foreach (char c in word)
            {
                if (broken.Contains(c))
                {
                    canType = false;
                    break;
                }
            }
            if (canType) count++;
        }

        return count;
    }
}
