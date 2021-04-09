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

        public Wagon(int id, List<Animal> animals)
        {
            Id = id;
            Animals = animals;
            Points = 0;
        }
    }
}
