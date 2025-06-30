# Problem:
Given a non-negative integer(without leading zeroes) represented as an array arr. Your task is to add 1 to the number (increment the number by 1). The digits are stored such that the most significant digit is at the starting index of the array.

Examples:

Input: arr[] = [5, 6, 7, 8]
Output: [5, 6, 7, 9]
Explanation: 5678 + 1 = 5679
Input: arr[] = [9, 9, 9]
Output: [1, 0, 0, 0]
Explanation: 999 + 1 = 1000
Constraints:
1 ≤ arr.size() ≤ 106
0 ≤ arr[i] ≤ 9
There are no leading zeros in the input number. 

---------------------------------------------------------------------------

---

## Approaches

### ✅ 1. Traverse from Right (Carry)
- Time: O(n)
- Space: O(n)
- Add 1 from right, manage carry, insert results from front.

### ✅ 2. In-place with Resize
- Time: O(n)
- Space: O(n)
- Update original array, handle leading carry separately.

### 🚫 3. String Conversion (Not recommended)
- Time: O(n)
- Space: O(n)
- Convert array to number string, use BigInteger for addition.

---

## Files

- `AddOne_Optimal.cs` → Cleanest logic using carry
- `AddOne_Inplace.cs` → Space-efficient variation
- `AddOne_StringMethod.cs` → Avoid this in interviews
