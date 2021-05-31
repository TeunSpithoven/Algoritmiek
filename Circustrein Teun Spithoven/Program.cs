using System.Collections.Generic;
using Circustrein.Controllers;
using Circustrein.Models;

namespace Circustrein
{
    public class Program
    {
        // made by Teun Spithoven
        private static void Main(string[] args)
        {
            // stopwatch start
            StopwatchController stopwatchController = new();
            stopwatchController.Start();

            // managers aanroepen
            AnimalController animalController = new();
            WagonController wagonController = new();
            TrainController trainController = new();
            
            // random dieren maken
            int animalsToMake = 10;
            List<Animal> animals = animalController.MakeRandomAnimals(animalsToMake);

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