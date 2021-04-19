using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circustrein_Teun_Spithoven
{
    public class Wagon
    {
        public int Id { get; private set; }
        public List<Animal> Animals { get; private set; }
        public int Points { get; set; }

        public Wagon(int id)
        {
            Id = id;
            List<Animal> animals = new List<Animal>();
            Animals = animals;
            Points = 0;
        }
    }
}
