using System.Collections.Generic;
using Logic.Controllers;
using Logic.Models;

namespace Logic
{
    public class Program
    {
        // made by Teun Spithoven
        private static void Main()
        {
            // stopwatch start
            StopwatchController stopwatchController = new();
            stopwatchController.Start();

            // managers aanroepen
            WagonController wagonController = new();
            TrainController trainController = new();
            
            // random dieren maken
            int animalsToMake = 10;
            List<Animal> animals = AnimalController.MakeRandomAnimals(animalsToMake);

            // wagons vullen met dieren
            List<Wagon> wagons = wagonController.WagonFiller(animals);

            // locomotief printen
            trainController.PrintWagons(wagons);
            trainController.PrintLocomotive();

            // Stopwatch stop
            stopwatchController.Stop();
        }
    }
}