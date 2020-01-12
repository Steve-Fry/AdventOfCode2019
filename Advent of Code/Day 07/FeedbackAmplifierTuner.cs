using System.Collections.Generic;
using Advent_of_Code.SharedLibrary;
using System.Linq;

namespace Advent_of_Code.Day_07
{
    class FeedbackAmplifierTuner
    {
        private readonly List<int> _program;

        public List<int> OptimalTune { get; private set; }
        public int HighestOutput { get; private set; }

        public FeedbackAmplifierTuner(List<int> program)
        {
            _program = program;
        }

        public void Run()
        {
            IEnumerable<List<int>> permetations = Utilities.Permutate(new List<int> { 5, 6, 7, 8, 9 }, 5);

            foreach (var tune in permetations)
            {
                int input_output;

                input_output = RunFeedbackAmplifier(tune);

                UpdateBestResult(tune, input_output);

            }
        }

        private int RunFeedbackAmplifier(List<int> tune)
        {
            Queue<int> amplifierAOutputQueue = new Queue<int>();
            Queue<int> amplifierBOutputQueue = new Queue<int>();
            Queue<int> amplifierCOutputQueue = new Queue<int>();
            Queue<int> amplifierDOutputQueue = new Queue<int>();
            Queue<int> amplifierEOutputQueue = new Queue<int>();

            FeedbackAmplifier amplifierA = new FeedbackAmplifier(_program.GetRange(0, _program.Count), amplifierEOutputQueue, amplifierAOutputQueue);
            FeedbackAmplifier amplifierB = new FeedbackAmplifier(_program.GetRange(0, _program.Count), amplifierAOutputQueue, amplifierBOutputQueue);
            FeedbackAmplifier amplifierC = new FeedbackAmplifier(_program.GetRange(0, _program.Count), amplifierBOutputQueue, amplifierCOutputQueue);
            FeedbackAmplifier amplifierD = new FeedbackAmplifier(_program.GetRange(0, _program.Count), amplifierCOutputQueue, amplifierDOutputQueue);
            FeedbackAmplifier amplifierE = new FeedbackAmplifier(_program.GetRange(0, _program.Count), amplifierDOutputQueue, amplifierEOutputQueue);

            List<FeedbackAmplifier> amplifiers = new List<FeedbackAmplifier>();
            //List<Queue<int>> queues = new List<Queue<int>>();

            amplifiers.Add(amplifierA);
            amplifiers.Add(amplifierB);
            amplifiers.Add(amplifierC);
            amplifiers.Add(amplifierD);
            amplifiers.Add(amplifierE);

            //queues.Add(amplifierAOutputQueue);
            //queues.Add(amplifierBOutputQueue);
            //queues.Add(amplifierCOutputQueue);
            //queues.Add(amplifierDOutputQueue);
            //queues.Add(amplifierEOutputQueue);

            amplifierAOutputQueue.Enqueue(tune[1]);
            amplifierBOutputQueue.Enqueue(tune[2]);
            amplifierCOutputQueue.Enqueue(tune[3]);
            amplifierDOutputQueue.Enqueue(tune[4]);
            amplifierEOutputQueue.Enqueue(tune[0]);

            amplifierEOutputQueue.Enqueue(0);


            // Initialise Amplifiers
            foreach (var amplifier in amplifiers)
            {
                while (amplifier.InputQueue.Count > 0)
                {
                    amplifier.Step();
                }
            }

            while (true)
            {
                foreach (var amplifier in amplifiers)
                {
                    while (amplifier.OutputQueue.Count == 0 && amplifier.IsDone == false)
                    {
                        amplifier.Step();
                    }

                    if (amplifier.IsDone == true)
                    {
                        return amplifierE.OutputQueue.Dequeue();
                    }
                }
            }
        }

        private void UpdateBestResult(List<int> tune, int output)
        {
            if (output > HighestOutput)
            {
                OptimalTune = tune.GetRange(0, tune.Count);
                HighestOutput = output;
            }
        }

    }
}
