namespace Maze
{
    public interface IMirror
    {
        Coordinate AdvanceLaser(Coordinate roomPosition, Coordinate previousLaserPosition);
    }
}