using System.Collections.Generic;
using Advent_of_Code.SharedLibrary;
using System.Threading.Tasks.Dataflow;
using System.Threading.Tasks;
using Serilog;
using System.Linq;
using System.Reflection;
using System;

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
            int amplifierCount = tune.Count;
            List<BufferBlock<long>> buffers = new List<BufferBlock<long>>();
            List<FeedbackAmplifier> amplifiers = new List<FeedbackAmplifier>();

            Log.Debug("Initalising Buffers");
            for (int i = 0; i < amplifierCount; i++)
            {
                buffers.Add(new BufferBlock<long>());
            }

            Log.Debug("Initalising Amplifiers");
            for (int i = 0; i < amplifierCount; i++)
            {
                var inputBuffer = i == 0 ? buffers[amplifierCount - 1] : buffers[i - 1]; // Input to the first should be the output from the last. 
                var outputBuffer = buffers[i];
                var programCopy = _program.GetRange(0, _program.Count);
                amplifiers.Add(new FeedbackAmplifier(programCopy, inputBuffer, outputBuffer));
            }

            Log.Debug("Setting tune");
            for (int i = 0; i < amplifierCount; i++)
            {
                var tuneElement= i == 0 ? tune[amplifierCount - 1] : tune[i - 1]; // Input to the first should be the output from the last. 
                buffers[i].Post(tuneElement);
            }

            Log.Debug("Priming amplifier 0 with input");
            amplifiers[0].InputBuffer.Post(0);


            Log.Debug("Running amplifiers");
            amplifiers.ForEach(x => x.Run());

            Log.Debug("Waiting for any task to complete");
            var tasks = amplifiers.Select(x => x.Task);
            Task.WhenAll(tasks).Wait();
            Log.Debug("All tasks completed");

            Log.Debug("Cancelling remaining tasks"); // Not currently required, but keeing because it took a while to 
            amplifiers.ForEach(x => x.Cancel());

            return amplifiers[0].InputBuffer.Receive();
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
