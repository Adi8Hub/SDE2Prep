/*
1. Using Split and Reverse Methods

2. Init with start and end pointer
Loop till you find ' '
After this add from ' ' - 1, index till start in the result string

*/

public class Solution
{
    public string ReverseWords(string s)
    {
        int n = s.Length;
        int i = 0;
        StringBuilder res = new();
        while (i < n)
        {
            int j = i;
            while (j < n && s[j] != ' ')
            {
                j++;
            }
            //After above loop, we have found a ' '

            for (int k = j - 1; k >= i; k--)//Append in reverse
            {
                res.Append(s[k]);
            }
            i = j + 1;

            if (j < n) res.Append(' ');

        }
        return res.ToString();
    }
}