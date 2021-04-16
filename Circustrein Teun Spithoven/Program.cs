using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Circustrein_Teun_Spithoven
{
    public class Program
    {
        static void Main(string[] args)
        {
            // stopwatch start
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            // managers aanroepen
            AnimalMan animalMan = new AnimalMan();
            WagonMan wagonMan = new WagonMan();

            // lijst met beesten maken
            int animalsToMake = 6;
            List<Animal> Animals = new List<Animal>();
            Animals = animalMan.MakeAnimals(animalsToMake);

            // wagons vullen met de dierenlijst
            wagonMan.WagonFiller(Animals);
            
            Console.WriteLine("                                           _____");
            Console.WriteLine("                                        ___ |[]|_n__n_I_c");
            Console.WriteLine("                                       |___||__|###|____}");
            Console.WriteLine("                                        O-O--O-O+++--O-O");

            // stopwacht stop en print tijd
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);
            Console.WriteLine($"                                   elapsed time: {elapsedTime}");
        }
    }
}
