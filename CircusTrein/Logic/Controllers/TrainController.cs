using System;
using System.Collections.Generic;
using Circustrein.Models;

namespace Circustrein.Controllers
{
    public class TrainController
    {
        public void PrintLocomotive()
        {
            string space = "                                       ";
            Console.WriteLine(space + "    _____");
            Console.WriteLine(space + " ___ |[]|_n__n_I_c");
            Console.WriteLine(space + "|___||__|###|____}");
            Console.WriteLine(space + " O-O--O-O+++--O-O");
        }

        public void PrintWagons(List<Wagon> wagons)
        {
            foreach (var wagon in wagons)
            {
                switch (wagon.Id)
                {
                    case < 10:
                        Console.WriteLine($"                                       -----{wagon.Id}-----");
                        break;
                    case < 100:
                        Console.WriteLine($"                                       -----{wagon.Id}----");
                        break;
                    case < 1000:
                        Console.WriteLine($"                                       ----{wagon.Id}----");
                        break;
                    case < 10000:
                        Console.WriteLine($"                                       ----{wagon.Id}---");
                        break;
                    case < 100000:
                        Console.WriteLine($"                                       ---{wagon.Id}---");
                        break;
                }

                string infoSpace = "                                       ";
                foreach (var animal in wagon.Animals)
                {
                    // print de bijbehorende eetgewoonte
                    if (animal.IsCarnivore == true)
                        Console.WriteLine($"{infoSpace}|{Enum.IsCarnivore.Carnivore}|");

                    else
                        Console.WriteLine($"{infoSpace}|{Enum.IsCarnivore.Herbivore}|");

                    switch (animal.Size)
                    {
                        // print de bijbehorende grootte
                        case 0:
                            Console.WriteLine($"{infoSpace}|  {Enum.Sizes.Small}  |");
                            break;
                        case 1:
                            Console.WriteLine($"{infoSpace}| {Enum.Sizes.Medium}  |");
                            break;
                        case 2:
                            Console.WriteLine($"{infoSpace}|  {Enum.Sizes.Large}  |");
                            break;
                        default:
                            Console.WriteLine("Invalid Size!");
                            break;
                    }
                    Console.WriteLine($"{infoSpace}|         |");
                }

                if (wagon.Points < 10)
                    Console.WriteLine($"{infoSpace}---0{wagon.Points}pts---");

                else
                    Console.WriteLine($"{infoSpace}---{wagon.Points}pts---");
                
                Console.WriteLine("                                            |     ");
            }
        }
    }
}