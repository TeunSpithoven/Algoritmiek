using System;
using System.Diagnostics;

namespace Logic.Controllers
{
    public static class StopwatchController
    {
        public static Stopwatch StopWatch = new();

        public static void Start()
        {
            StopWatch.Start();
        }

        public static void Stop()
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