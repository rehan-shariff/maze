namespace Maze
{
    public class VerticalLaser : ILaser
    {
        public Position CalculatePreviousPosition(Position currentPosition)
        {
            if (currentPosition.Y == 0)
                return new Position(currentPosition.X, currentPosition.Y - 1);

            return new Position(currentPosition.X, currentPosition.Y + 1);
        }
    }
}