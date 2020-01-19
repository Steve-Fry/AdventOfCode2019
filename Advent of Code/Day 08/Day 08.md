# Day 08

## Part 1
This appeared so simple but was made difficult by efforts to explore Linq instead of simply using a for loop.

*(It would be much easier to just work through some of the excellent Linq examples found at 
https://github.com/dotnet/try-samples.)*

Another issue I ran into was how to parse a `string` containing integer charatacters into an `List<int>` object. 
I was bitten by the different handling of char's compared to string's for a while. In the end I am quite happy with 
the approach I ended up with 
```
from s in stringimagedata
select int.Parse(s.ToString())
```



## Part 2
I started with quite a complex and convoluted approach, but thankfully this simplified down quite nicely in the 
refactor. (Although still with room for improvement).

In the end I chose to store the input string in its original format `List<int>` instead of converting 
this into an a multidimensional array. From there I expose the data partitioned into layers by via a property. 

Was this the right idea? It certainly reduces memory consumption, but at the expense of CPU when accessing
the property. 