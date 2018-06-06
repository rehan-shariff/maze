namespace Maze
{
    public class TwoWayLeftMirror : IMirror
    {
        public Position AdvanceLaser(Position roomPosition, Position previousLaserPosition)
        {
            if (roomPosition.Y > previousLaserPosition.Y)
                return new Position(roomPosition.X - 1, roomPosition.Y);
            
            if (roomPosition.Y < previousLaserPosition.Y)
                return new Position(roomPosition.X + 1, roomPosition.Y);

            if (roomPosition.X > previousLaserPosition.X)
                return new Position(roomPosition.X, roomPosition.Y - 1);

            return new Position(roomPosition.X, roomPosition.Y + 1);
        }
    }
}