namespace Logic.Models
{
    public class ViewAnimal
    {
        public int Id { get; private set; }
        public bool IsCarnivore { get; private set; }
        public int Size { get; private set; }
        public int Points { get; private set; }

        public ViewAnimal(int id, bool isCarnivore, int size, int points)
        {
            Id = id;
            IsCarnivore = isCarnivore;
            Size = size;
            Points = points;
        }
    }
}
