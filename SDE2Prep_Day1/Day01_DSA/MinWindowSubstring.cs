// TODO: Sliding window with hashmaps
/* 76.Minimum Window Substring

Given two strings s and t of lengths m and n respectively, return the minimum window substring of s such that every character in t (including duplicates) is included in the window. If there is no such substring, return the empty string "".

The testcases will be generated such that the answer is unique.

Example 1:

Input: s = "ADOBECODEBANC", t = "ABC"
Output: "BANC"
Explanation: The minimum window substring "BANC" includes 'A', 'B', and 'C' from string t.
Example 2:

Input: s = "a", t = "a"
Output: "a"
Explanation: The entire string s is the minimum window.
Example 3:

Input: s = "a", t = "aa"
Output: ""
Explanation: Both 'a's from t must be included in the window.
Since the largest window of s only has one 'a', return empty string.
 
Constraints:

m == s.length
n == t.length
1 <= m, n <= 105
s and t consist of uppercase and lowercase English letters.
 
Follow up: Could you find an algorithm that runs in O(m + n) time?
*/


/*
Edge Cases to Consider:
- Empty Inputs
- s = "", t = "abc" → Expected output: "" (no possible substring)
- s = "abc", t = "" → Expected output: "" (no requirement to fulfill)
- No Matching Substring
- s = "abcdef", t = "xyz" → Expected output: "" (none of the characters of t exist in s)
- String t Larger Than s
- s = "abc", t = "abcd" → Expected output: "" (not possible to find t in s)
- Single Character Strings
- s = "a", t = "a" → Expected output: "a" (only one character matches)
- s = "b", t = "a" → Expected output: "" (no match possible)
- Characters of t Repeated in s
- s = "abacbad", t = "abc" → Expected output: "bac" (smallest substring containing a, b, and c)
- Multiple Valid Substrings
- s = "aaabcbcabb", t = "abc" → Expected output: "bca" (or "cba", depending on implementation)
- Case Sensitivity
- s = "ABCabc", t = "abc" → Expected output: "abc" (assuming case-sensitive search)
*/
var s = "ADOBECODEBANC";
var t = "ABC";
var ans = Solution.MinWindowSubstring(s, t);
Console.WriteLine($"Minimum Window Substring is: {ans}");

public class Solution
{
    //Optimal - Using Sliding Window
    // Calculate t char count in its map
    //Start sliding window in 's'
    //if char is in t, reduce the count and move to next char
    //if all char count of t becomes zero, we have found a window
    // shrink from left and if the left char is in t, increase the count in the map.
    public static string MinWindowSubstring(string s, string t)
    {
        // var tMap = new Dictionary<char, int>();
        var tMap = new int[128];
        foreach (var c in t)
        {
            tMap[c]++;
        }

        int left = 0, right = 0;
        int sLen = s.Length;
        int required = t.Length;
        int minWindow = int.MaxValue;
        int minStart = 0;

        var sMap = new int[128];
        int found = 0; // char of t, found in s
        while (right < s.Length)
        {
            char ch = s[right];

            if (tMap[ch] > 0)//if char is in t, then inc its count in sMap
            {
                sMap[ch]++;
                if (sMap[ch] <= tMap[ch]) found++;
            }

            //All chars of t are exhausted, calculate window size and the string and then shrink
            while (required == found)
            {
                if (right - left + 1 < minWindow)
                {
                    minWindow = right - left + 1;
                    minStart = left;
                }

                char leftMost = s[left];
                if (tMap[leftMost] > 0)
                {
                    // if (tMap[leftMost] == 0)
                    //     tCount++;
                    // tMap[leftMost]++;

                    if (sMap[leftMost] <= tMap[leftMost])
                        found--;
                    sMap[leftMost]--;
                }
                left++;
            }
            right++;
        }

        if (minWindow == int.MaxValue)
            return "";

        return s.Substring(minStart, minWindow);
    }


    //First get the substring
    //Check if substring contains t
    //AND, length of substring < minimum Length till now
    //update minimum length to length of substring and the resultant as this substring
    public static string MinWindowSubstring(string s, string t)
    {
        int sLen = s.Length;
        int minLen = int.MaxValue;
        string ans = "";

        for (int i = 0; i < sLen; i++)
        {
            for (int j = i; j < sLen; j++)
            {
                string subStr = s.Substring(i, j - i + 1);
                if (IsIncluded(subStr, t) && subStr.Length < minLen)
                {
                    minLen = subStr.Length;
                    ans = subStr;
                }
            }
        }
        return ans;
    }

    //Calculate char count in substring map
    //Calculate char count in t based on substring map
    private static bool IsIncluded(string subStr, string t)
    {
        var map = new Dictionary<char, int>();
        foreach (var ch in subStr)
        {
            map[ch] = map.GetValueOrDefault(ch, 0) + 1;
        }

        foreach (var c in t)
        {
            if (!map.ContainsKey(c) || map[c] <= 0) return false;
            map[c]--;
        }
        return true;
    }
}