using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.IO;


namespace Advent_of_Code.Day_07
{
    class Day_07
    {
        public void Run()
        {
            List<int> program = SharedLibrary.FileParser.GetIntCodeFromFile(@"Inputs\Day07Input.txt");
            AmplifierTuner tuner = new AmplifierTuner(program);
            tuner.Run();

            FeedbackAmplifierTuner feedbackTuner = new FeedbackAmplifierTuner(program);
            feedbackTuner.Run();
            
            Console.WriteLine($"=====Day 7, part 1=====");
            Console.WriteLine($"Best Tune = {string.Join(',', tuner.OptimalTune)} with a value of {tuner.HighestOutput}");

            Console.WriteLine($"=====Day 7, part 2=====");
            Console.WriteLine($"Best Tune = {string.Join(',', feedbackTuner.OptimalTune)} with a value of {feedbackTuner.HighestOutput}");

        }


    }
}
