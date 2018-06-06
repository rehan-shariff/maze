namespace Maze
{
    public class TwoWayLeftMirror : IMirror
    {
        public Coordinate AdvanceLaser(Coordinate roomPosition, Coordinate previousLaserPosition)
        {
            if (roomPosition.Y > previousLaserPosition.Y)
                return new Coordinate(roomPosition.X - 1, roomPosition.Y);
            
            if (roomPosition.Y < previousLaserPosition.Y)
                return new Coordinate(roomPosition.X + 1, roomPosition.Y);

            if (roomPosition.X > previousLaserPosition.X)
                return new Coordinate(roomPosition.X, roomPosition.Y - 1);

            return new Coordinate(roomPosition.X, roomPosition.Y + 1);
        }
    }
}