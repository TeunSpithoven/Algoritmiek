using System.Collections.Generic;

namespace Circustrein.Models
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
