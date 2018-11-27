using BenchmarkDotNet.Attributes;

namespace ConsoleApp1
{
    [MemoryDiagnoser]
    public class BenchmarkString
    {
        [Benchmark]
        public string StringConcatenation()
        {
            var one = "ae";
            var two = "-";
            var three = "ea";

            var test = one;
            test += two;
            test += three;

            return test;
        }

        [Benchmark]
        public string StringInterpolation()
        {
            var one = "ae";
            var two = "-";
            var three = "ea";

            var test = $"{one}{two}{three}";

            return test;
        }
    }
}