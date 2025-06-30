# Best Time to Buy and Sell Stock

🔗 [LeetCode Problem #121](https://leetcode.com/problems/best-time-to-buy-and-sell-stock/)

## 🧾 Problem Statement

You are given an array `prices` where `prices[i]` is the price of a given stock on the i-th day.

You want to maximize your profit by choosing a **single day to buy one stock and a different day in the future to sell that stock**.

Return the maximum profit you can achieve from this transaction. If no profit is possible, return `0`.

---

## 💡 Example

1:

Input: prices = [7,1,5,3,6,4]
Output: 5
Explanation: Buy on day 2 (price = 1) and sell on day 5 (price = 6), profit = 6-1 = 5.
Note that buying on day 2 and selling on day 1 is not allowed because you must buy before you sell.
Example 2:

Input: prices = [7,6,4,3,1]
Output: 0
Explanation: In this case, no transactions are done and the max profit = 0.
 

Constraints:

1 <= prices.length <= 105
0 <= prices[i] <= 104




-------------------------------------------------------------------
## ✅ Approaches

### 1. One-Pass Minimum Tracking (Optimal)

- **Time:** O(n)  
- **Space:** O(1)  
- **Logic:** Track the minimum price so far, and update the max profit on each day.


### 2. Brute Force (Inefficient)
- **Time:** O(n²)

- **Space:** O(1)

- **Logic:** Try all pairs (i, j) where j > i and compute profit.