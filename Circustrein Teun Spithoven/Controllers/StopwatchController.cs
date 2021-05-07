using System;
using System.Diagnostics;

namespace Circustrein_Teun_Spithoven.Controllers
{
    public class StopwatchController
    {
        public Stopwatch stopWatch = new Stopwatch();

        public void Start()
        {
            stopWatch.Start();
        }

        public void Stop()
        {
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);
            Console.WriteLine($"                                   elapsed time: {elapsedTime}");
        }
    }
}