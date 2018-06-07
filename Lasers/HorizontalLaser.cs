namespace Maze
{
    public class HorizontalLaser : ILaser
    {
        public Position CalculatePreviousPosition(Position currentPosition)
        {
            if (currentPosition.X == 0)
                return new Position(currentPosition.X - 1, currentPosition.Y);

            return new Position(currentPosition.X + 1, currentPosition.Y);
        }
    }
}