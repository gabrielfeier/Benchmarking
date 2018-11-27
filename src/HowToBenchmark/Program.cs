using System;
using BenchmarkDotNet.Running;

namespace HowToBenchmark
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<BenchmarkHexStringToByteArray>();
            Console.ReadLine();
        }
    }
}
