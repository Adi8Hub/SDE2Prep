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