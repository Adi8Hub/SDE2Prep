//Using PQ or Heap
public class MedianFinder
{
    //stores left side of the sorted list i.e.,lesser values to the left and root contains max from the left side. this max could be median or one of the median.
    PriorityQueue<int, int> maxHeap;//left side

    //stores right side of the sorted list i.e.,larger values to the right and root contains min from the right side. this min could be median or one of the median.
    PriorityQueue<int, int> minHeap;//right side

    public MedianFinder()
    {
        minHeap = new PriorityQueue<int, int>();
        maxHeap = new PriorityQueue<int, int>(Comparer<int>.Create((a, b) => b.CompareTo(a)));
    }

    public void AddNum(int num)
    {
        maxHeap.Enqueue(num, num);

        // 1. Move from left to right heap,
        // maxHeap constitutes left half, minHeap constitutes right half
        // so element in maxHeap if larger should move to minHeap
        if (minHeap.Count > 0 && maxHeap.Peek() > minHeap.Peek())
        {
            var element = maxHeap.Dequeue();
            minHeap.Enqueue(element, element);
        }

        // 2. Re-balance
        // if size difference > 1, rebalance and move to minheap
        if (maxHeap.Count - minHeap.Count > 1)
        {
            var element = maxHeap.Dequeue();
            minHeap.Enqueue(element, element);
        }
        else if (minHeap.Count > maxHeap.Count)//if minHeap size > maxHeap size
        {
            var element = minHeap.Dequeue();
            maxHeap.Enqueue(element, element);
        }
    }

    public double FindMedian()
    {
        if (maxHeap.Count > minHeap.Count)
            return maxHeap.Peek();
        else
            return (maxHeap.Peek() + minHeap.Peek()) / 2.0;
    }
}

/**
 * Your MedianFinder object will be instantiated and called as such:
 * MedianFinder obj = new MedianFinder();
 * obj.AddNum(num);
 * double param_2 = obj.FindMedian();
 */

/*
The median is the middle value in an ordered integer list. If the size of the list is even, there is no middle value, and the median is the mean of the two middle values.

For example, for arr = [2,3,4], the median is 3.
For example, for arr = [2,3], the median is (2 + 3) / 2 = 2.5.
Implement the MedianFinder class:

MedianFinder() initializes the MedianFinder object.
void addNum(int num) adds the integer num from the data stream to the data structure.
double findMedian() returns the median of all elements so far. Answers within 10-5 of the actual answer will be accepted.
 

Example 1:

Input
["MedianFinder", "addNum", "addNum", "findMedian", "addNum", "findMedian"]
[[], [1], [2], [], [3], []]
Output
[null, null, null, 1.5, null, 2.0]

Explanation
MedianFinder medianFinder = new MedianFinder();
medianFinder.addNum(1);    // arr = [1]
medianFinder.addNum(2);    // arr = [1, 2]
medianFinder.findMedian(); // return 1.5 (i.e., (1 + 2) / 2)
medianFinder.addNum(3);    // arr[1, 2, 3]
medianFinder.findMedian(); // return 2.0
 

Constraints:

-105 <= num <= 105
There will be at least one element in the data structure before calling findMedian.
At most 5 * 104 calls will be made to addNum and findMedian.
 

Follow up:

If all integer numbers from the stream are in the range [0, 100], how would you optimize your solution?
If 99% of all integer numbers from the stream are in the range [0, 100], how would you optimize your solution?
*/