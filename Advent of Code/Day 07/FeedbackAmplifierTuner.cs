using System.Collections.Generic;
using Advent_of_Code.SharedLibrary;
using System.Threading.Tasks.Dataflow;
using System.Threading.Tasks;

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

            BufferBlock<long> amplifierAOutputBuffer = new BufferBlock<long>();
            BufferBlock<long> amplifierBOutputBuffer = new BufferBlock<long>();
            BufferBlock<long> amplifierCOutputBuffer = new BufferBlock<long>();
            BufferBlock<long> amplifierDOutputBuffer = new BufferBlock<long>();
            BufferBlock<long> amplifierEOutputBuffer = new BufferBlock<long>();

            FeedbackAmplifier amplifierA = new FeedbackAmplifier(_program.GetRange(0, _program.Count), amplifierEOutputBuffer, amplifierAOutputBuffer);
            FeedbackAmplifier amplifierB = new FeedbackAmplifier(_program.GetRange(0, _program.Count), amplifierAOutputBuffer, amplifierBOutputBuffer);
            FeedbackAmplifier amplifierC = new FeedbackAmplifier(_program.GetRange(0, _program.Count), amplifierBOutputBuffer, amplifierCOutputBuffer);
            FeedbackAmplifier amplifierD = new FeedbackAmplifier(_program.GetRange(0, _program.Count), amplifierCOutputBuffer, amplifierDOutputBuffer);
            FeedbackAmplifier amplifierE = new FeedbackAmplifier(_program.GetRange(0, _program.Count), amplifierDOutputBuffer, amplifierEOutputBuffer);

            List<FeedbackAmplifier> amplifiers = new List<FeedbackAmplifier>
            {
                amplifierA,
                amplifierB,
                amplifierC,
                amplifierD,
                amplifierE
            };

            amplifierAOutputBuffer.Post(tune[1]);
            amplifierBOutputBuffer.Post(tune[2]);
            amplifierCOutputBuffer.Post(tune[3]);
            amplifierDOutputBuffer.Post(tune[4]);
            amplifierEOutputBuffer.Post(tune[0]);

            amplifierEOutputBuffer.Post(0);

            Task ampATask = Task.Run(() => { amplifierA.Run(); });
            Task ampBTask = Task.Run(() => { amplifierB.Run(); });
            Task ampCTask = Task.Run(() => { amplifierC.Run(); });
            Task ampDTask = Task.Run(() => { amplifierD.Run(); });
            Task ampETask = Task.Run(() => { amplifierE.Run(); });

            List<Task> tasks = new List<Task>() { ampATask, ampBTask, ampCTask, ampDTask, ampETask };
            Task.WhenAny(tasks).Wait();

            return amplifierA.InputBuffer.Receive();
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
