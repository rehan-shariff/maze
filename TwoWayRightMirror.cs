namespace Maze
{
    public class TwoWayRightMirror : IMirror
    {
        public TwoWayRightMirror()
        {
        }

        public Coordinate AdvanceLaser(Coordinate roomPosition, Coordinate previousLaserPosition)
        {
            return new Coordinate(0, 0);
        }
    }
}