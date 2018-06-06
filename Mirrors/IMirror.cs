namespace Maze
{
    public interface IMirror
    {
        Position AdvanceLaser(Position roomPosition, Position previousLaserPosition);
    }
}