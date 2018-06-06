namespace Maze
{
    public class OneWayLeftReflectLeftMirror : IMirror
    {
        public Position AdvanceLaser(Position roomPosition, Position previousLaserPosition)
        {
            if (roomPosition.Y > previousLaserPosition.Y ||
                roomPosition.X < previousLaserPosition.X
               )
                return new Position(roomPosition.X - 1, roomPosition.Y);

            return new Position(roomPosition.X, roomPosition.Y - 1);
        }
    }
}