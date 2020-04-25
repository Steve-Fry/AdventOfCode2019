using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Advent_of_Code.Day_08
{
    class Day_08
    {
        SIFImage _imageParser;



        public void Run()
        {
            Stopwatch stopWatch = Stopwatch.StartNew();

            _imageParser = new SIFImage(@"Inputs\Day8Input.txt", 25, 6);


            Console.WriteLine($"=====Day 8, part 1=====");
            Console.WriteLine($"For the layer with fewest 0's, the count of 1 digits multiplied by the number of 2 digits = {_imageParser.Checksum}");

            Console.WriteLine($"=====Day 8, part 2=====");
            _imageParser.RenderImageToConsole();

            stopWatch.Stop();
            Console.WriteLine();
            Console.WriteLine($"Day 8 completed in {stopWatch.ElapsedMilliseconds} ms");
            Console.WriteLine();
            Console.WriteLine();

        }

        public int GetProductOfOneAndTwoForLayerWithLeastZeros() =>
            _imageParser.Layers
                .Select(x => (Zeros: x.Count(y => y == 0),
                              Ones: x.Count(z => z == 1),
                              Twos: x.Count(w => w == 2)))
                .OrderBy(x => x.Zeros)
                .Select(x => x.Ones * x.Twos)
                .First();
    }
}
