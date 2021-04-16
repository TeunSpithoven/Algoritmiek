using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circustrein_Teun_Spithoven
{
    public class Animal
    {
        public int Id { get; private set; }
        public bool IsCarnivore { get; private set; }
        public int Size { get; private set; }
        public int Points { get; private set; }

        public Animal(int id)
        {
            Random r = new Random();
            int isCarnivoreInt = r.Next(2);
            bool isCarnivore = Convert.ToBoolean(isCarnivoreInt);
            IsCarnivore = isCarnivore;

            int randomSize = r.Next(3);
            Size = randomSize;

            if (randomSize == 0) { Points = 1;}
            if (randomSize == 1) { Points = 3; }
            if (randomSize == 2) { Points = 5; }

            Id = id;
        }

        public Animal()
        {
            Id = 69420;
            IsCarnivore = false;
            Size = 69420;
            Points = 69420;
        }

        public Animal(int id, bool isCarnivore, int size, int points)
        {
            Id = id;
            IsCarnivore = isCarnivore;
            Size = size;
            Points = points;
        }
    }
}
