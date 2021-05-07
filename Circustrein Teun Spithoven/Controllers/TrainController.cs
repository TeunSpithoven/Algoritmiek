using System;
using System.Collections.Generic;
using Circustrein_Teun_Spithoven.Models;

namespace Circustrein_Teun_Spithoven.Controllers
{
    public class TrainController
    {
        public void PrintLocomotive()
        {
            Console.WriteLine("                                           _____");
            Console.WriteLine("                                        ___ |[]|_n__n_I_c");
            Console.WriteLine("                                       |___||__|###|____}");
            Console.WriteLine("                                        O-O--O-O+++--O-O");
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

                foreach (var animal in wagon.Animals)
                {
                    // print de bijbehorende eetgewoonte
                    if (animal.IsCarnivore == true)
                        Console.WriteLine($"                                       |{Enum.IsCarnivore.Carnivore}|");

                    else
                        Console.WriteLine($"                                       |{Enum.IsCarnivore.Herbivore}|");

                    switch (animal.Size)
                    {
                        // print de bijbehorende grootte
                        case 0:
                            Console.WriteLine($"                                       |  {Enum.Sizes.Small}  |");
                            break;
                        case 1:
                            Console.WriteLine($"                                       | {Enum.Sizes.Medium}  |");
                            break;
                        default:
                            Console.WriteLine($"                                       |  {Enum.Sizes.Large}  |");
                            break;
                    }
                    Console.WriteLine($"                                       |         |");
                }

                if (wagon.Points < 10)
                    Console.WriteLine($"                                       ---0{wagon.Points}pts---");
                
                else
                    Console.WriteLine($"                                       ---{wagon.Points}pts---");
                
                Console.WriteLine("                                            |     ");
            }
        }
    }
}