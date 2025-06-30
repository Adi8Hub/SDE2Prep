You are given an array arr of positive integers. Your task is to find all the leaders in the array. An element is considered a leader if it is greater than or equal to all elements to its right. The rightmost element is always a leader.

Examples:

Input: arr = [16, 17, 4, 3, 5, 2]
Output: [17, 5, 2]
Explanation: Note that there is nothing greater on the right side of 17, 5 and, 2.
Input: arr = [10, 4, 2, 4, 1]
Output: [10, 4, 4, 1]
Explanation: Note that both of the 4s are in output, as to be a leader an equal element is also allowed on the right. side
Input: arr = [5, 10, 20, 40]
Output: [40]
Explanation: When an array is sorted in increasing order, only the rightmost element is leader.
Input: arr = [30, 10, 10, 5]
Output: [30, 10, 10, 5]
Explanation: When an array is sorted in non-increasing order, all elements are leaders.
Constraints:
1 <= arr.size() <= 106
0 <= arr[i] <= 106

------------------------------------------------------------------


# Leaders in an Array

🔗 [GeeksforGeeks Problem Link](https://www.geeksforgeeks.org/problems/leaders-in-an-array-1587115620/1)

## Problem Statement

In an array A of size n, a leader is an element which is greater than or equal to all the elements to its right side.

---

## Approaches

### ✅ 1. Right-to-Left Traversal
- **Time:** O(n)
- **Space:** O(n)
- **Logic:** Keep track of the current maximum from the right and add it if the current value is ≥ max.

### ✅ 2. Brute Force
- **Time:** O(n²)
- **Space:** O(n)
- **Logic:** For each element, check all elements to the right.

### ✅ 3. Stack Based
- **Time:** O(n)
- **Space:** O(n)
- **Logic:** Avoid `Reverse()` call by using a stack to collect leaders in correct order.

---

## File Structure

- `Leaders_RightToLeft.cs` → Optimal solution using right-to-left traversal and reverse
- `Leaders_BruteForce.cs` → Naive solution
- `Leaders_StackBased.cs` → Uses a stack to maintain output order

