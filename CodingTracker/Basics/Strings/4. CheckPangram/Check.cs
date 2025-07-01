public class Solution
{
    public bool CheckIfPangram(string sentence)
    {
        int n = sentence.Length;

        if (n < 26) return false;

        int[] freq = new int[26];
        int count = 0;

        foreach (var c in sentence)
        {
            if (freq[c - 'a'] == 0)
            {
                count++;
                freq[c - 'a']++;
            }
        }

        if (count == 26) return true;
        return false;
    }
}