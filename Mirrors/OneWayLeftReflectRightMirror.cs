namespace Maze
{
    public class OneWayLeftReflectRightMirror : IMirror
    {
        public OneWayLeftReflectRightMirror()
        {
        }

        public Coordinate AdvanceLaser(Coordinate roomPosition, Coordinate previousLaserPosition)
        {
            return new Coordinate(0, 0);
        }
    }
}