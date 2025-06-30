Using Dutch National Flag,
- low points to where next 0 comes.
- mid scans and points to 1
- high points to where next 2 should be.

Init : low=mid=0 and high = n-1

Case: mid = 0, swap and do low++ and mid++
mid = 1, do mid++
mid=2, swap mid and high and do high--

## Note:
as mid started from left end , hence we can safely move mid when mid = 0, 
but when mid = 2, after swap, we are not sure what value exists in mid