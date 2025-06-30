# Find the Odd Occurrence

🔗 [GeeksforGeeks Problem Link](https://www.geeksforgeeks.org/problems/find-the-odd-occurence4820/1)

## Problem Statement

You are given an array of N integers. All numbers occur even number of times except one. Find that number which occurs odd number of times.

---

## 🧠 Approaches

### ✅ 1. XOR Trick (Optimal)
- **Time:** O(N)
- **Space:** O(1)
- **Logic:** All even-count numbers cancel out with XOR, the result is the odd one.

### ✅ 2. HashMap Frequency Count
- **Time:** O(N)
- **Space:** O(N)
- **Logic:** Count occurrences of each number using a dictionary and return the one with odd count.

### ✅ 3. Sorting
- **Time:** O(N log N)
- **Space:** O(1)
- **Logic:** Group and count adjacent elements post-sort.

---

## 📦 Files

- `FindOddOccurrence_XOR.cs` → Optimal solution using XOR
- `FindOddOccurrence_HashMap.cs` → Frequency dictionary approach
- `FindOddOccurrence_Sorting.cs` → Sort-based solution
