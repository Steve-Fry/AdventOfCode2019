using System.Collections.Generic;
using Advent_of_Code.SharedLibrary;
using System.Threading.Tasks.Dataflow;
using System.Threading.Tasks;
using Serilog;
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

        private List<BufferBlock<long>> GetEmptyBuffers(List<long> tune)
        {
            int amplifierCount = tune.Count;
            List<BufferBlock<long>> buffers = new List<BufferBlock<long>>();

            Log.Debug("Initalising Buffers");
            for (int i = 0; i < amplifierCount; i++)
            {
                buffers.Add(new BufferBlock<long>());
            }

            return buffers;
        }

        private List<FeedbackAmplifier> GetAmplifiers(List<long> tune, List<BufferBlock<long>> buffers)
        {
            Log.Debug("Initalising Amplifiers");
            int amplifierCount = tune.Count;
            List<FeedbackAmplifier> amplifiers = new List<FeedbackAmplifier>();

            for (int i = 0; i < amplifierCount; i++)
            {
                var inputBuffer = i == 0 ? buffers[amplifierCount - 1] : buffers[i - 1]; // Input to the first should be the output from the last. 
                var outputBuffer = buffers[i];
                var programCopy = _program.GetRange(0, _program.Count);
                amplifiers.Add(new FeedbackAmplifier(programCopy, inputBuffer, outputBuffer));
            }

            return amplifiers;
        }

        private void InitaliseAmplifierTune(List<long> tune, List<FeedbackAmplifier> amplifiers)
        {
            Log.Debug("Setting tune");
            for (int i = 0; i < amplifiers.Count; i++)
            {
                amplifiers[i].InputBuffer.Post(tune[i]);
            }
        }

        private void WriteAmplifierInput(List<FeedbackAmplifier> amplifiers)
        {
            Log.Debug("Priming amplifier 0 with input");
            amplifiers[0].InputBuffer.Post(0);
        }

        private void RunAmplifiers(List<FeedbackAmplifier> amplifiers)
        {
            Log.Debug("Running amplifiers");
            amplifiers.ForEach(x => x.Run());
        }

        private void WaitForAmplifierCompletion(List<FeedbackAmplifier> amplifiers)
        {
            Log.Debug("Waiting for any task to complete");
            var tasks = amplifiers.Select(x => x.Task);
            Task.WhenAll(tasks).Wait();
            Log.Debug("All tasks completed");
        }

        private long RunFeedbackAmplifier(List<long> tune)
        {
            List<BufferBlock<long>> buffers = GetEmptyBuffers(tune);
            List<FeedbackAmplifier> amplifiers = GetAmplifiers(tune, buffers);
            InitaliseAmplifierTune(tune, amplifiers);
            WriteAmplifierInput(amplifiers);
            RunAmplifiers(amplifiers);
            WaitForAmplifierCompletion(amplifiers);
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
