using System;
using System.Diagnostics;

namespace Circustrein.Controllers
{
    public class StopwatchController
    {
        public Stopwatch StopWatch = new();

        public void Start()
        {
            StopWatch.Start();
        }

        public void Stop()
        {
            StopWatch.Stop();
            TimeSpan ts = StopWatch.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);
            Console.WriteLine($"                                   elapsed time: {elapsedTime}");
        }
    }
}