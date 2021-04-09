using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circustrein_Teun_Spithoven
{
    public class WagonMan
    {
        private int _id = 1;
        public Wagon NewWagon()
        {
            List<Animal> animals = new List<Animal>();
            Wagon returnWagon = new Wagon(_id, animals);
            _id++;
            return returnWagon;
        }

        public bool DoesAnotherAnimalFit(int wagonPoints, int animalPoints)
        {
            if (wagonPoints + animalPoints <= 10)
            {
                return true;
            }

            return false;
        }
    }
}
