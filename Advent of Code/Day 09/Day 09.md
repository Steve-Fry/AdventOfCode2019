# Day 09

## Part 1
I started by refactoring the intcodeVM, which was looking quite overly complex by this point. 
There is clearly still work to do, but I'm happier with the overall model model now. 

Implementing the large int was an exercise of repetitive copy-paste, I could have been kinder with 
respecting the API provided to the previous solutions, but just went for the (mostly) brute force approach. 

Once refactored, the implemention went smoothly with only a bit of debugging caused by misreading the instruction 
for how to modify the relative base. You should add the value of the first parameter, not replace the relative base 
with that value. 

Once the tests were passing part 1 didn't cause any problems. 

## Part 2
I was surprised by this one, it seemed suspiciously easy. 
