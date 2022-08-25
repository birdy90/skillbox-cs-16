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
        
        private static void FirstThread()
        {
            var id = Thread.CurrentThread.ManagedThreadId;
            Console.WriteLine($"Thread #{id} started");
            while (_shouldContinue)
            {
                ShowMessage(id);
                Thread.Sleep(300);
            }
            Console.WriteLine($"Thread #{id} stopped");
        }

        private static void SecondThread()
        {
            var id = Thread.CurrentThread.ManagedThreadId;
            Console.WriteLine($"Thread #{id} started");
            while (_shouldContinue)
            {
                ShowMessage(id);
                Thread.Sleep(1050);
            }
            Console.WriteLine($"Thread #{id} stopped");
        }
        
        public static void Main(string[] args)
        {
            var thread1 = new Thread(FirstThread);
            var thread2 = new Thread(SecondThread);
            thread1.Start();
            thread2.Start();

            Console.WriteLine("Tasks are run, let's wait till they end...");

            Console.WriteLine("All async tasks finished");
            Console.ReadKey();
        }
    }
}