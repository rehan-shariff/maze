namespace Maze
{
    public class TwoWayLeftMirror : IMirror
    {
        public Coordinate AdvanceLaser(Coordinate roomPosition, Coordinate previousLaserPosition)
        {
            return new Coordinate(0, 0);
        }
    }
}