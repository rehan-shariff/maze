namespace Maze
{
    public class OneWayLeftReflectRightMirror : IMirror
    {
        public Position AdvanceLaser(Position roomPosition, Position previousLaserPosition)
        {
            if (LaserDirectionChecker.IsLaserMovingUp(roomPosition, previousLaserPosition) ||
                LaserDirectionChecker.IsLaserMovingLeft(roomPosition, previousLaserPosition))
                return LaserMover.MoveUp(roomPosition);

            return LaserMover.MoveRight(roomPosition);
        }
    }
}