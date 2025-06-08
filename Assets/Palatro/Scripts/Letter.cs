namespace Palatro
{
    public readonly struct Letter
    {
        public readonly string Shape;
        public readonly int Points;

        public Letter(string shape, int points)
        {
            Shape = shape;
            Points = points;
        }
    }
}