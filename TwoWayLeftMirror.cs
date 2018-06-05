namespace Maze
{
    public class TwoWayLeftMirror : IMirror
    {
        public TwoWayLeftMirror()
        {
        }

        public Coordinate AdvanceLaser(Coordinate roomPosition, Coordinate previousLaserPosition)
        {
            return new Coordinate(0, 0);
        }
    }
}