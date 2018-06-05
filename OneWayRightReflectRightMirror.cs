namespace Maze
{
    public class OneWayRightReflectRightMirror : IMirror
    {
        public OneWayRightReflectRightMirror()
        {
        }

        public Coordinate AdvanceLaser(Coordinate roomPosition, Coordinate previousLaserPosition)
        {
            return new Coordinate(0, 0);
        }
    }
}