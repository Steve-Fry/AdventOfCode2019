# Day 12

## Part 1
This seemed easy enough, seperating out the three phases of applying the acceleration, 
velocity, position updates.

Although this needed some thought, it went relatively smoothly. 

## Part 2
This took a while! 

I tried the naive approach first, and quickly recognised that even on a compiled language the 
brute force solution was not workable. 

After this I wasted a bunch of time with a List\<T\> in a HashSet - eventually I realised my error and hardcoded 
the positions/velocities into an tuple. 

It would have been nice so we could scale to more bodies - but it is time to move on! 
