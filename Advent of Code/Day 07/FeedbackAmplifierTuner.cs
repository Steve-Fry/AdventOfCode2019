using System.Collections.Generic;
using Advent_of_Code.SharedLibrary;
using System.Linq;

namespace Advent_of_Code.Day_07
{
    class FeedbackAmplifierTuner
    {
        private readonly List<int> _program;

        public List<long> OptimalTune { get; private set; }
        public long HighestOutput { get; private set; }

        public FeedbackAmplifierTuner(List<int> program)
        {
            _program = program;
        }

        public void Run()
        {
            IEnumerable<List<long>> permetations = Utilities.Permutate(new List<long> { 5, 6, 7, 8, 9 }, 5);

            foreach (var tune in permetations)
            {
                long input_output;

                input_output = RunFeedbackAmplifier(tune);

                UpdateBestResult(tune, input_output);

            }
        }

        private long RunFeedbackAmplifier(List<long> tune)
        {
            Queue<long> amplifierAOutputQueue = new Queue<long>();
            Queue<long> amplifierBOutputQueue = new Queue<long>();
            Queue<long> amplifierCOutputQueue = new Queue<long>();
            Queue<long> amplifierDOutputQueue = new Queue<long>();
            Queue<long> amplifierEOutputQueue = new Queue<long>();

            FeedbackAmplifier amplifierA = new FeedbackAmplifier(_program.GetRange(0, _program.Count), amplifierEOutputQueue, amplifierAOutputQueue);
            FeedbackAmplifier amplifierB = new FeedbackAmplifier(_program.GetRange(0, _program.Count), amplifierAOutputQueue, amplifierBOutputQueue);
            FeedbackAmplifier amplifierC = new FeedbackAmplifier(_program.GetRange(0, _program.Count), amplifierBOutputQueue, amplifierCOutputQueue);
            FeedbackAmplifier amplifierD = new FeedbackAmplifier(_program.GetRange(0, _program.Count), amplifierCOutputQueue, amplifierDOutputQueue);
            FeedbackAmplifier amplifierE = new FeedbackAmplifier(_program.GetRange(0, _program.Count), amplifierDOutputQueue, amplifierEOutputQueue);

            List<FeedbackAmplifier> amplifiers = new List<FeedbackAmplifier>
            {
                amplifierA,
                amplifierB,
                amplifierC,
                amplifierD,
                amplifierE
            };

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

        private void UpdateBestResult(List<long> tune, long output)
        {
            if (output > HighestOutput)
            {
                OptimalTune = tune.GetRange(0, tune.Count);
                HighestOutput = output;
            }
        }
    }
}
