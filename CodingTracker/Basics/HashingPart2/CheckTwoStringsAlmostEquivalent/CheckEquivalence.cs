public class Solution
{
    public bool CheckAlmostEquivalent(string word1, string word2)
    {
        int[] count = new int[26];

        foreach (char c in word1)
            count[c - 'a']++;

        foreach (char c in word2)
            count[c - 'a']--;

        foreach (int diff in count)
        {
            if (Math.Abs(diff) > 3)
                return false;
        }

        return true;
    }
}
