namespace Maze
{
    public struct Coordinate
    {
        public int X { get; }
        public int Y { get; }

        public Coordinate(int xValue, int yValue)
        {
            X = xValue;
            Y = yValue;
        }
    }
}