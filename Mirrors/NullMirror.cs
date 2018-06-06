namespace Maze
{
    public class NullMirror : IMirror
    {
        public Position AdvanceLaser(Position roomPosition, Position previousLaserPosition)
        {
            if (roomPosition.Y > previousLaserPosition.Y)
                return new Position(roomPosition.X, roomPosition.Y + 1);
            
            if (roomPosition.Y < previousLaserPosition.Y)
                return new Position(roomPosition.X, roomPosition.Y - 1);
            
            if (roomPosition.X > previousLaserPosition.X)
                return new Position(roomPosition.X + 1, roomPosition.Y);
            
            return new Position(roomPosition.X - 1, roomPosition.Y);
        }
    }
}