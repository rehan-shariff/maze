namespace Maze
{
    public class OneWayLeftReflectLeftMirror : IMirror
    {
        public Coordinate AdvanceLaser(Coordinate roomPosition, Coordinate previousLaserPosition)
        {
            if (roomPosition.Y > previousLaserPosition.Y ||
                roomPosition.X < previousLaserPosition.X
               )
                return new Coordinate(roomPosition.X - 1, roomPosition.Y);

            return new Coordinate(roomPosition.X, roomPosition.Y - 1);
        }
    }
}