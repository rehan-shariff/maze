namespace Maze
{
    public class TwoWayRightMirror : IMirror
    {
        public Coordinate AdvanceLaser(Coordinate roomPosition, Coordinate previousLaserPosition)
        {
            if (roomPosition.y > previousLaserPosition.y)
                return new Coordinate(roomPosition.x + 1, roomPosition.y);

            if (roomPosition.y < previousLaserPosition.y)
                return new Coordinate(roomPosition.x - 1, roomPosition.y);

            if (roomPosition.x > previousLaserPosition.x)
                return new Coordinate(roomPosition.x, roomPosition.y - 1);

            return new Coordinate(roomPosition.x, roomPosition.y + 1);
        }
    }
}