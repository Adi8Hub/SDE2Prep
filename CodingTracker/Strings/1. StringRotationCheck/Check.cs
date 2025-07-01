string s1 = "abcd", s2 = "cdab";

// string s1 = "abcd", s2 = "acbd";
bool ans = RotationCheck.AreRotations(s1, s2);
System.Console.WriteLine($"{ans}");

class RotationCheck
{
    // // Using Built In Methods
    // public static bool AreRotations(string s1, string s2)
    // {
    //     string temp = s1 + s1;
    //     return temp.Contains(s2);
    // }

    // // 2. Brute - w/0 in-built
    // public static bool AreRotations(string s1, string s2)
    // {
    //     if (s2.Length > s1.Length) return false;
    //     string temp = s1 + s1;
    //     return Check(temp, s2);
    // }

    // // 2.1 Brute - Helper method
    // static bool Check(string text, string pattern)
    // {
    //     int n = text.Length;
    //     int m = pattern.Length;

    //     for (int i = 0; i < n; i++)
    //     {
    //         int j = 0;

    //         while (j < m && text[i + j] == pattern[j])
    //         {

    //             j++;
    //         }

    //         if (j == m)
    //             return true;
    //     }
    //     return false;
    // }

    // 3. KMP
    public static bool AreRotations(string s1, string s2)
    {
        if (s2.Length > s1.Length) return false;
        string temp = s1 + s1;
        return KMP(temp, s2);
    }

    static bool KMP(string text, string pattern)
    {
        int[] lps = BuildLPS(pattern);
        int i = 0, j = 0;
        int n = text.Length;
        int m = pattern.Length;

        while (i < n)
        {
            if (text[i] == pattern[j])
            {
                i++;
                j++;

                if (j == m)
                {
                    System.Console.WriteLine($"ROtation Starts at index: {i - j}");
                    return true;
                }
            }
            else
            {
                if (j != 0)//if j not at the start
                {
                    j = lps[j - 1];
                }
                else
                {
                    i++;//j==0, no match found , hence move to next char
                }
            }
        }
        return false;
    }

    static int[] BuildLPS(string pattern)
    {
        int n = pattern.Length;
        int[] lps = new int[n];

        int len = 0;
        int i = 1;//0th index will have no prefix-suffix

        while (i < n)
        {
            if (pattern[i] == pattern[len])
            {
                lps[i] = len + 1;
                len++;
                i++;
            }
            else
            {
                if (len != 0)
                {
                    len = lps[len - 1];
                }
                else
                {
                    lps[i] = 0;
                    i++;
                }
            }
        }
        return lps;
    }

}