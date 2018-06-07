namespace Maze
{
    public class NullLaser : ILaser
    {
        public Position CalculatePreviousPosition(Position currentPosition)
        {
            return new Position();
        }
    }
}