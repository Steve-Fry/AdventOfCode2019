using System.Collections.Generic;
using Advent_of_Code.SharedLibrary;
using System.Linq;

namespace Advent_of_Code.Day_07
{
    class AmplifierTuner
    {
        private readonly List<long> _program;

        public List<long> OptimalTune { get; private set; }
        public long HighestOutput { get; private set; }

        public AmplifierTuner(List<long> program)
        {
            _program = program;
        }

        public AmplifierTuner(List<int> program)
        {
            _program = program.Select(x => (long)x).ToList() ;
        }

        public void Run()
        {
            IEnumerable<List<long>> permetations = Utilities.Permutate(new List<long> { 0, 1, 2, 3, 4 }, 5);

            foreach (var tune in permetations)
            {
                long input_output = 0;

                foreach (var phase in tune)
                {
                    input_output = GetAmplifierOutput(input_output, phase, _program.GetRange(0, _program.Count));
                }

                UpdateBestResult(tune, input_output);

            }
        }

        private long GetAmplifierOutput(long input, long phase, List<long> program)
        {
            Amplifier amp;
            amp = new Amplifier(input, phase, program);
            return amp.Run();
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
