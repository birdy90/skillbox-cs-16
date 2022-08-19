using System;
using System.Threading;
using System.Threading.Tasks;

namespace skillbox_cs_14
{
    internal class Program
    {
        private static bool _shouldContinue = true;

        private static int _counter = 10;
        
        private static void ShowMessage(object threadId)
        {
            Console.WriteLine($"Message from thread #{threadId}");
            _counter -= 1;
            if (_counter == 0)
            {
                _shouldContinue = false;
            }
        }
        
        private static async void FirstThread()
        {
            Console.WriteLine($"Thread #{Task.CurrentId} started");
            while (_shouldContinue)
            {
                ShowMessage(Task.CurrentId);
                Thread.Sleep(300);
                // await Task.Delay(300);
            }
            Console.WriteLine($"Thread #{Task.CurrentId} stopped");
        }

        private static async void SecondThread()
        {
            Console.WriteLine($"Thread #{Task.CurrentId} started");
            while (_shouldContinue)
            {
                ShowMessage(Task.CurrentId);
                Thread.Sleep(1050);
                // await Task.Delay(1050);
            }
            Console.WriteLine($"Thread #{Task.CurrentId} stopped");
        }
        
        public static void Main(string[] args)
        {
            var task1 = Task.Run(FirstThread);
            var task2 = Task.Run(SecondThread);

            Console.WriteLine("Tasks are run, let's wait till they end...");
            
            Task.WaitAll(task1, task2);

            Console.WriteLine("All async tasks finished");
            Console.ReadKey();
        }
    }
}