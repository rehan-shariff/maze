namespace Maze
{
    public class NullMirror : IMirror
    {
        public Coordinate AdvanceLaser(Coordinate roomPosition, Coordinate previousLaserPosition)
        {
            if (roomPosition.y > previousLaserPosition.y)
                return new Coordinate(roomPosition.x, roomPosition.y + 1);
            
            if (roomPosition.y < previousLaserPosition.y)
                return new Coordinate(roomPosition.x, roomPosition.y - 1);
            
            if (roomPosition.x > previousLaserPosition.x)
                return new Coordinate(roomPosition.x + 1, roomPosition.y);

            return new Coordinate(roomPosition.x - 1, roomPosition.y);
        }
    }
}