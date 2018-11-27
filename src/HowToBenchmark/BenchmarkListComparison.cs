using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;

namespace HowToBenchmark
{
    [MemoryDiagnoser]
    public class BenchmarkListComparison
    {
        private static readonly IEnumerable<int> List1 = new List<int>
        {
            1,
            3,
            32,
            565,
            4,
            98,
            494889,
            498,
            98498,
            4949,
            98464,
            654,
            65468,
            13,
            126466
        };

        private static readonly IEnumerable<int> List2 = new List<int>
        {
            1,
            3,
            32,
            565,
            4,
            98,
            494889,
            498,
            98498,
            4949,
            98464,
            654,
            65468,
            13,
            126466
        };
        
        [Benchmark]
        public static bool ScrambledEquals()
        {
            var cnt = new Dictionary<int, int>();
            foreach (var s in List1)
            {
                if (cnt.ContainsKey(s))
                {
                    cnt[s]++;
                }
                else
                {
                    cnt.Add(s, 1);
                }
            }
            foreach (var s in List2)
            {
                if (cnt.ContainsKey(s))
                {
                    cnt[s]--;
                }
                else
                {
                    return false;
                }
            }
            return cnt.Values.All(c => c == 0);
        }

        [Benchmark]
        public bool EnumerableSolution()
        {
            return List1.OrderBy(t => t).SequenceEqual(List2.OrderBy(t => t));
        }      
    }
}