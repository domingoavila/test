using System;
using System.Threading;
namespace SemaphoreThreading
{
    class Program
    {
        static void Main(string[] args)
        {
        for (int i = 0; i < 10; i++)
            {
                threads[i] = new Thread(C_sharpcorner);
                threads[i].Name = "thread_" + i;
                threads[i].Start();
            }
           Console.Read();

        }

       static Thread[] threads = new Thread[10];
        static Semaphore sem = new Semaphore(3, 3);
        static void C_sharpcorner()
        {
            Console.WriteLine("{0} en Fila", Thread.CurrentThread.Name);
            sem.WaitOne();
            Console.WriteLine("{0} en atencion", Thread.CurrentThread.Name);
            Thread.Sleep(300);
            Console.WriteLine("{0} Saliendo", Thread.CurrentThread.Name);
            sem.Release();
        }
 
    }
}


