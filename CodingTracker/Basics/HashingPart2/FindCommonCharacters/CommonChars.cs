public class Solution
{
    public IList<string> CommonChars(string[] words)
    {
        int[] commonLetterFreq = new int[26];
        Array.Fill(commonLetterFreq, int.MaxValue);

        foreach (var word in words)
        {
            int[] currWordFreq = new int[26];
            foreach (var w in word)
            {
                currWordFreq[w - 'a']++;
            }

            for (int i = 0; i < 26; i++)
                commonLetterFreq[i] = Math.Min(commonLetterFreq[i], currWordFreq[i]);
        }

        List<string> res = new();
        for (int i = 0; i < 26; i++)
        {
            while (commonLetterFreq[i]-- > 0)
            {
                res.Add(((char)(i + 'a')).ToString());
            }
        }
        return res;
    }
}

/*
Loop over each word

Maintain a common Letter freq array
and within the loop create another freq[] for that individual word

Now take the minimum of the two and store back to common freq. Do it for each word

Loop over common freq[], get the index convert to char by adding 'a' and convert it using (char) and since the result needs string.
then convert it to string
*/