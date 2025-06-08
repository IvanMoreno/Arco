namespace Palatro
{
    public class Letter
    {
        public string Shape { get; }
        public int Points { get; }

        public Letter(string shape, int points)
        {
            Shape = shape;
            Points = points;
        }
    }
}