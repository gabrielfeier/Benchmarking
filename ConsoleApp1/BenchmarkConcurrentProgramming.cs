using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    [MemoryDiagnoser]
    public class BenchmarkConcurrentProgramming
    {
        private const int Loop = 5;

        [Benchmark]
        public void UsingMutex()
        {
            LoopAction(() =>
            {
                var random = new Random();
                var orderKey = random.Next(1000, 9999).ToString();

                var task1 = Task.Run(() =>
                {
                    //var mutex = new Mutex(true, orderKey);
                    ////Console.WriteLine("Passou do WaitOne");
                    //mutex.ReleaseMutex();
                    ////Console.WriteLine("Liberou mutex");
                    //Thread.Sleep(500);
                    VerifyMutex(orderKey);
                });

                task1.Wait();
                var task2 = Task.Run(() =>
                {
                    //var mutex = Mutex.OpenExisting(orderKey);
                    ////Console.WriteLine("Entrou WaitOne");

                    //mutex.WaitOne();

                    ////Console.WriteLine("Passou do WaitOne - 2");

                    //mutex.Dispose();
                    VerifyMutex(orderKey);
                });
                task2.Wait();
            });
        }

        [Benchmark]
        public void UsingConcurrentDictionary()
        {
            var dictionary = new ConcurrentDictionary<string, object>();
            LoopAction(() =>
            {
                var random = new Random();
                var orderKey = random.Next(1000, 9999).ToString();

                

                var key = dictionary.GetOrAdd(orderKey, new object());

                var task1 = Task.Run(() =>
                {
                    lock (key)
                    {
                        Thread.Sleep(50);
                    }
                });
                task1.Wait();

                var task2 = Task.Run(() =>
                {
                    lock (key)
                    {
                        
                    }
                });
                task2.Wait();
            });
        }

        [Benchmark]
        public void UsingManualResetEvent()
        {
            var dictionary = new ConcurrentDictionary<string, ManualResetEvent>();
            LoopAction(() =>
            {
                var random = new Random();
                var orderKey = random.Next(1000, 9999).ToString();



                var task1 = Task.Run(() =>
                {
                    var key = dictionary.GetOrAdd(orderKey, new ManualResetEvent(false));
                    //Console.WriteLine("lock1 bloqueado");
                    //Console.WriteLine("Estou no lock1");
                    //Console.WriteLine("lock1 liberado");
                    key.Set();
                });

                task1.Wait();

                var task2 = Task.Run(() =>
                {
                    var key = dictionary.GetOrAdd(orderKey, new ManualResetEvent(false));
                    //Console.WriteLine("lock2 bloqueado");
                    key.WaitOne();
                    //Console.WriteLine("Estou no lock2");
                    //Console.WriteLine("lock2 liberado");		
                });

                Task.WaitAll(task2);
            });
        }

        public Mutex VerifyMutex(string orderKey)
        {
            var mutex = Mutex.TryOpenExisting(orderKey, out var m);

            if (!mutex)
            {
                m = new Mutex(true, orderKey);
                ReleaseMutex(m);
            }
            else
            {
                m.WaitOne();
            }

            m.Dispose();

            return m;
        }


        public void ReleaseMutex(Mutex mutex)
        {
            mutex.ReleaseMutex();
        }

        public void LoopAction(Action action)
        {
            for (var i = 0; i < Loop; i++)
            {
                action();
            }
        }
    }
}
