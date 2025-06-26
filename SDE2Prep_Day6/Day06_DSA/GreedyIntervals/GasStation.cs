public class Solution
{
    public int CanCompleteCircuit(int[] gas, int[] cost)
    {
        int currGain = 0;
        int totalGain = 0;
        int startPt = 0;
        int n = gas.Length;

        for (int i = 0; i < n; i++)
        {
            currGain += gas[i] - cost[i];
            totalGain += gas[i] - cost[i];

            if (currGain < 0)
            {
                currGain = 0;
                startPt = i + 1; // 1-based index
            }
        }
        if (totalGain >= 0)
            return startPt;

        return -1;
    }
}

// gas[]==>fill the tank using this
// cost[i]==> use this fuel to travel forward

// TO complete a circle, total gain would be SUM of filling the tank-burning the fuel
// pt at which gain is negative , make it zero, and keep track of this point as start 