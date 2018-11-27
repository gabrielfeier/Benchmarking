using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class TestClass
    {
        private const int Loop = 50;

        public void UsingMutex()
        {
            LoopAction(() =>
            {
                var random = new Random();
                var orderKey = random.Next(1000, 9999).ToString();

                var task1 = Task.Run(() =>
                {
                    var mutex = new Mutex(true, orderKey);
                    //Console.WriteLine("Passou do WaitOne");
                    mutex.ReleaseMutex();
                    //Console.WriteLine("Liberou mutex");
                    Thread.Sleep(50);
                });

                task1.Wait();
                var task2 = Task.Run(() =>
                {
                    var mutex = Mutex.OpenExisting(orderKey);
                    //Console.WriteLine("Entrou WaitOne");

                    mutex.WaitOne();

                    //Console.WriteLine("Passou do WaitOne - 2");

                    mutex.Dispose();
                });
                task2.Wait();
            });
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
