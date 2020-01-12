using System;
using System.Collections.Generic;
using System.Text;
using Advent_of_Code.SharedLibrary;

namespace Advent_of_Code.Day_07
{
    class AmplifierTuner
    {
        private readonly List<int> _program;

        public List<int> OptimalTune { get; private set; }
        public int HighestOutput { get; private set; }

        public AmplifierTuner(List<int> program)
        {
            _program = program;
        }

        public void Run()
        {
            IEnumerable<List<int>> permetations = Utilities.Permutate(new List<int> { 0, 1, 2, 3, 4 }, 5);

            foreach (var tune in permetations)
            {
                int input_output = 0;

                foreach (var phase in tune)
                {
                    input_output = GetAmplifierOutput(input_output, phase, _program.GetRange(0, _program.Count));
                }

                UpdateBestResult(tune, input_output);

            }
        }

        private int GetAmplifierOutput(int input, int phase, List<int> program)
        {
            Amplifier amp;
            amp = new Amplifier(input, phase, program);
            return amp.Run();
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
