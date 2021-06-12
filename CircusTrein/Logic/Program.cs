using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Logic.Controllers;
using Logic.Models;

namespace Logic
{
    public class Program
    {
        // made by Teun Spithoven
        public static void Main()
        {
            StopwatchController.Start();

            // Make random animals
            List<Animal> animals = Animal.MakeRandomAnimals(10);

            // Fill the wagons with animals
            List<Wagon> wagons = Train.WagonFiller(animals);

            // print the train
            Train.PrintWagons(wagons);
            Train.PrintLocomotive();

            StopwatchController.Stop();
        }
    }
}