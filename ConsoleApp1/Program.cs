using System;
using System.Threading;
using System.Threading.Tasks;
using BenchmarkDotNet.Running;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //new BenchmarkConcurrentProgramming().UsingMutex();
            
            BenchmarkRunner.Run<BenchmarkConcurrentProgramming>();
            Console.ReadLine();
        }
    }
}
