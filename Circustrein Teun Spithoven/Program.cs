using System;
using System.Collections.Generic;

namespace Circustrein_Teun_Spithoven
{
    public class Program
    {
        private static void Main(string[] args)
        {
            // stopwatch start
            StopwatchMan stopwatchMan = new StopwatchMan();
            stopwatchMan.Start();

            // managers aanroepen
            AnimalMan animalMan = new AnimalMan();
            WagonMan wagonMan = new WagonMan();
            TrainMan train = new TrainMan();
            
            // lijst met beesten maken
            int animalsToMake = 4;
            List<Animal> animals = animalMan.MakeAnimals(animalsToMake);

            // wagons vullen met de dierenlijst
            wagonMan.WagonFiller(animals);

            // locomotief printen
            train.PrintLocomotive();

            // stopwacht stop en print tijd
            stopwatchMan.Stop();
        }
    }
}