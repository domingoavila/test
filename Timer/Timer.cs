using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

namespace Timer
{
    class Timer
    {
        public static void Main()
        {
            int key=0;
            System.Timers.Timer aTimer = new System.Timers.Timer(2000);
            //aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            aTimer.Elapsed += (sender, args) => OnTimedEvent(sender, args);
            aTimer.Interval = 1000;
            aTimer.Enabled = false;

            Console.WriteLine("Press \'q\' to quit \'s\' to start the sample.");
            while ((key=Console.Read()) != 's' || (key!='q'))
            {
                if (key=='s')
                    aTimer.Enabled = true;

                if (key == 'q')
                    break;
            }
        }

        // Specify what you want to happen when the Elapsed event is raised.
        private static void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            Console.WriteLine("Hello World! {0}",e.SignalTime);
        }
    }
}
