namespace Maze
{
    public class OneWayLeftReflectLeftMirror : IMirror
    {
        public Position AdvanceLaser(Position roomPosition, Position previousLaserPosition)
        {
            if (LaserDirectionChecker.IsLaserMovingUp(roomPosition, previousLaserPosition) ||
                LaserDirectionChecker.IsLaserMovingLeft(roomPosition, previousLaserPosition))
                return LaserMover.MoveLeft(roomPosition);

             return LaserMover.MoveDown(roomPosition);
        }
    }
}