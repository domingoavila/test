using System;
using System.Threading;

class TimerExampleState
{
    public int counter = 0;
    public Timer tmr;
}

class App
{
    public static void Main()
    {
        Worker workerObject = new Worker();
        Thread workerThread = new Thread(workerObject.DoWork);
        workerThread.Start();
        TimerExampleState s = new TimerExampleState();
        TimerCallback timerDelegate = new TimerCallback(CheckStatus);
        Timer timer = new Timer(timerDelegate, s, 0, 1);
        s.tmr = timer;

        while (true)
        {
            Console.Write("1");
        }
        Console.ReadKey();
    }
    // The following method is called by the timer's delegate.

    static void CheckStatus(Object state)
    {
        while (true)
        {
            Console.Write("0");
        }
        /*
        TimerExampleState s = (TimerExampleState)state;
        s.counter++;
        Console.WriteLine("{0} Checking Status {1} Thread {2}", DateTime.Now.TimeOfDay, s.counter, Thread.CurrentThread.ManagedThreadId);
        if (s.counter == 5)
        {
            // Shorten the period. Wait 10 seconds to restart the timer.
            (s.tmr).Change(1000, 100);
            Console.WriteLine("changed...");
        }
        if (s.counter == 10)
        {
            Console.WriteLine("disposing of timer...");
            s.tmr.Dispose();
            s.tmr = null;
        }
         */
    }

}


public class Worker
{
    // This method will be called when the thread is started. 
    public void DoWork()
    {
        while (!_shouldStop)
        {
            //Console.WriteLine("worker thread: working...");
            Console.Write("2");
        }
        Console.WriteLine("worker thread: terminating gracefully.");
    }
    public void RequestStop()
    {
        _shouldStop = true;
    }
    // Volatile is used as hint to the compiler that this data 
    // member will be accessed by multiple threads. 
    private volatile bool _shouldStop;
}
