namespace Maze
{
    public class NullMirror : IMirror
    {
        public Coordinate AdvanceLaser(Coordinate roomPosition, Coordinate previousLaserPosition)
        {
            if (roomPosition.Y > previousLaserPosition.Y)
                return new Coordinate(roomPosition.X, roomPosition.Y + 1);
            
            if (roomPosition.Y < previousLaserPosition.Y)
                return new Coordinate(roomPosition.X, roomPosition.Y - 1);
            
            if (roomPosition.X > previousLaserPosition.X)
                return new Coordinate(roomPosition.X + 1, roomPosition.Y);
            
            return new Coordinate(roomPosition.X - 1, roomPosition.Y);
        }
    }
}