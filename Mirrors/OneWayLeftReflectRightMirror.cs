namespace Maze
{
    public class OneWayLeftReflectRightMirror : IMirror
    {
        public Position AdvanceLaser(Position roomPosition, Position previousLaserPosition)
        {
            if (roomPosition.Y > previousLaserPosition.Y ||
                roomPosition.X < previousLaserPosition.X)
                return new Position(roomPosition.X, roomPosition.Y + 1);

            return new Position(roomPosition.X + 1, roomPosition.Y);
        }
    }
}