/*
Fix i and use 
j & k pointers from i+1 to n-1

Init closestSum with first 3 nos.

get their sum and check if the diff b/w target and this sum < diff b/w target and closestSum
- if yes, update closest sum to this sum

now, for moving the pointers
- if sum < target move j
else move k

--also numbers can be duplicate, so move j & k till we cross respective duplicate elements
*/