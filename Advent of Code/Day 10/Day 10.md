# Day 10

## Part 1
I very quickly found the Atan2 and Atan function, but foolishly went off on a false start based on 
the slope of the line made between origin and target (DeltaY / DeltaX). Needless to say once I came back to 
ATan2 this went much more smoothly. 

I just chucked all angles values into a HashSet and then counted to see how many were left (after the hashset 
de-duped)


## Part 2
This went fairly smoothly, and I ended up using powershell to build the test cases (transcribing from the 
documentation is so boring!).

I ended up using the SortedDictionary and SortedList, these seem to provide some benefit - although on the 
small datasets here I suspect the performance benefits are minimunal. 

I'm going to be interested to see other responses to this - I considered just sweeping theta through -PI --> PI 
with small jumps. However unless you have a clever data structure to storing the asteroids locations it seems 
inefficient having to traverse all asteroids for each step of the laser? 

For me I liked the solution I came up with (until I see other solutions and realise how much better it could 
have been...)