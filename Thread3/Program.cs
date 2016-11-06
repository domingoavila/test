using System;

using System.Threading;

namespace SemaphoreThreading
{

    class Program
    {
        static Thread[] threads = new Thread[20];
        static Semaphore sem = new Semaphore(1, 1);
        static Mutex mut = new Mutex();
        static Barrier barrier = new Barrier(10, b =>
         Console.WriteLine("--- All horse have reached the barrier ---"));

        private const int numIterations = 1;
        private const int numThreads = 10;

        static int actual = 0;

        static void Main(string[] args)
        {
            for (int i = 0; i < numThreads; i++)
            {
                //threads[i] = new Thread(Caja);
                threads[i] = new Thread(MyThreadProc);
                threads[i].Name = "thread_" + i;
                threads[i].Start();
                actual = i;
            }
            Console.Read();
            Print();
            Console.ReadKey();


        }
        static void Caja()
        {
            Console.WriteLine("{0} en Fila", Thread.CurrentThread.Name);

            sem.WaitOne();

            Console.WriteLine("{0} en atencion", Thread.CurrentThread.Name);

            Thread.Sleep(300);

            Console.WriteLine("{0} Saliendo", Thread.CurrentThread.Name);

            sem.Release();
            //Print();

        }

        static void Print()
        {
            for (int i = 0; i < 10; i++)
                if (threads[i].IsAlive)
                    Console.Write("1");
                else
                    Console.Write("0");
            Console.WriteLine("");
        }

        private static void MyThreadProc()
        {
            Console.WriteLine(Thread.CurrentThread.Name + " is at the start gate");
            barrier.SignalAndWait();

            for(int i = 0; i < numIterations; i++)
            {
                UseResource();
            }
            Print();
            barrier.SignalAndWait();

        }

        // This method represents a resource that must be synchronized
        // so that only one thread at a time can enter.
        private static void UseResource()
        {
            // Wait until it is safe to enter.
            mut.WaitOne();

            Console.WriteLine("{0} has entered the protected area", 
                Thread.CurrentThread.Name);

            // Place code to access non-reentrant resources here.

            // Simulate some work.
            Thread.Sleep(100);

            Console.WriteLine("{0} is leaving the protected area\r\n", 
                Thread.CurrentThread.Name);

            // Release the Mutex.
            mut.ReleaseMutex();
        }

    }
}