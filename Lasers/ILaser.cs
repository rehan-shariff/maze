namespace Maze
{
    public interface ILaser
    {
        Position CalculatePreviousPosition(Position currentPosition);
    }
}