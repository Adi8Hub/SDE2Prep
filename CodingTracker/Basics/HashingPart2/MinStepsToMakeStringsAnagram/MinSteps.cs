public class Solution
{
    public int MinSteps(string s, string t)
    {
        int[] freqS = new int[26];
        int[] freqT = new int[26];

        // count chr freq in both strings
        foreach (var c in s)
        {
            freqS[c - 'a']++;
        }
        foreach (var c in t)
        {
            freqT[c - 'a']++;
        }

        int count = 0;
        //coutn all the extra chars in t
        // if t has lesser char freq, just ignore, as that will be taken care by chars having more freq
        // e.g. s= "a" and  t="b", if we count for both then count=2, bit its wrong. Only 1 is correct that needs to be replaced 
        for (int i = 0; i < 26; i++)
        {
            if (freqT[i] > freqS[i])
                count += freqT[i] - freqS[i];
        }
        return count;
    }
}
// leetcode
// l=1
// e=3
// // t=1
// c=1
// o=1
// d=1

// practice
// p=1
// r=1
// a=1
// c=2
// // t=1
// i=1
// e=1

// //extra chars of 't' not in 's'
// count+= p=1 + r=1 + a=1 + (c=2 - c=1) + i=1
// = 5 