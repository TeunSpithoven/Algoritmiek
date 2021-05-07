namespace Circustrein_Teun_Spithoven.Models
{
    public class Animal
    {
        public int Id { get; private set; }
        public bool IsCarnivore { get; private set; }
        public int Size { get; private set; }
        public int Points { get; private set; }

        public Animal(int id, bool isCarnivore, int size, int points)
        {
            Id = id;
            IsCarnivore = isCarnivore;
            Size = size;
            Points = points;
        }
    }
}
