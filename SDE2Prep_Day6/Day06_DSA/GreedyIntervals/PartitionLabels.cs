//                      USING MAP       

public class Solution
{
    public IList<int> PartitionLabels(string s)
    {

        var lastSeen = new Dictionary<char, int>();
        int n = s.Length;

        //Get the last occurenece of character
        for (int i = 0; i < n; i++)
        {
            lastSeen[s[i]] = i;
        }

        var result = new List<int>();
        int start = 0, end = 0;

        // Get the end point , if curr Char is before than keep it as it is,else update with curr last seen
        for (int i = 0; i < n; i++)
        {
            end = Math.Max(end, lastSeen[s[i]]);

            // if curr char reaches end point, then add this substring part length to the result set
            // Move start point to the next of current end 
            if (i == end)
            {
                result.Add(end - start + 1);
                start = i + 1;
            }
        }
        return result;
    }
}

//                          USING FIXED ARRAY
public class Solution
{
    public IList<int> PartitionLabels(string s)
    {

        var lastSeen = new int[26];
        int n = s.Length;

        //Get the last occurenece of character
        for (int i = 0; i < n; i++)
        {
            lastSeen[s[i] - 'a'] = i;
        }

        var result = new List<int>();
        int start = 0, end = 0;

        // Get the end point , if curr Char is before than keep it as it is,else update with curr last seen
        for (int i = 0; i < n; i++)
        {
            end = Math.Max(end, lastSeen[s[i] - 'a']);

            // if curr char reaches end point, then add this substring part length to the result set
            // Move start point to the next of current end 
            if (i == end)
            {
                result.Add(end - start + 1);
                start = i + 1;
            }
        }
        return result;
    }
}