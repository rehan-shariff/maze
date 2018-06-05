namespace Maze
{
    public class OneWayLeftReflectRightMirror : IMirror
    {
        public Coordinate AdvanceLaser(Coordinate roomPosition, Coordinate previousLaserPosition)
        {
            if (roomPosition.y > previousLaserPosition.y ||
                roomPosition.x < previousLaserPosition.x)
                return new Coordinate(roomPosition.x, roomPosition.y + 1);

            return new Coordinate(roomPosition.x + 1, roomPosition.y);
        }
    }
}