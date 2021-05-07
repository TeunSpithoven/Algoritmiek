using System;
using System.Collections.Generic;
using Circustrein_Teun_Spithoven.Controllers;
using Circustrein_Teun_Spithoven.Models;

namespace Circustrein_Teun_Spithoven
{
    public class Program
    {
        private static void Main(string[] args)
        {
            // stopwatch start
            StopwatchController stopwatchMan = new StopwatchController();
            stopwatchMan.Start();

            // managers aanroepen
            AnimalController animalController = new AnimalController();
            WagonController wagonController = new WagonController();
            TrainController trainController = new TrainController();
            
            // lijst met beesten maken
            int animalsToMake = 4;
            List<Animal> animals = animalController.MakeRandomAnimals(animalsToMake);

            // wagons vullen met de dierenlijst
            List<Wagon> wagons = new();
            wagons = wagonController.WagonFiller(animals);

            // locomotief printen
            trainController.PrintWagons(wagons);
            trainController.PrintLocomotive();

            // stopwacht stop en print tijd
            stopwatchMan.Stop();
        }
    }
}