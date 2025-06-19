// TODO: Use sliding window with hashset
/*
Given a string s, find the length of the longest substring without duplicate characters.

Example 1:

Input: s = "abcabcbb"
Output: 3
Explanation: The answer is "abc", with the length of 3.
Example 2:

Input: s = "bbbbb"
Output: 1
Explanation: The answer is "b", with the length of 1.
Example 3:

Input: s = "pwwkew"
Output: 3
Explanation: The answer is "wke", with the length of 3.
Notice that the answer must be a substring, "pwke" is a subsequence and not a substring.
 
Constraints:

0 <= s.length <= 5 * 104
s consists of English letters, digits, symbols and spaces.
*/
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Internal;


// string s = "abcabcbb";
string s = "pwwkew";
// string s = "bbbbb";
int ans = Solution.LengthOfLongestSubstring(s);
System.Console.WriteLine($"Longest SUbstring without repeating characters: {ans}");

public class Solution
{
    public static int LengthOfLongestSubstring(string s)
    {
        int[] lastSeen = new int[128];
        Array.Fill(lastSeen, -1);
        int left = 0, right = 0;
        int n = s.Length;
        int maxLen = 0;

        while (right < n)
        {
            if (lastSeen[s[right]] != -1)
            {
                left = Math.Max(left, lastSeen[s[right]] + 1);
            }
            lastSeen[s[right]] = right;
            maxLen = Math.Max(maxLen, right - left + 1);
            right++;
        }
        return maxLen;
    }
}