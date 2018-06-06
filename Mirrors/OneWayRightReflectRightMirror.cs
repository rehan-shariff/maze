namespace Maze
{
    public class OneWayRightReflectRightMirror : IMirror
    {
        public Position AdvanceLaser(Position roomPosition, Position previousLaserPosition)
        {
            if (LaserDirectionChecker.IsLaserMovingUp(roomPosition, previousLaserPosition) ||
                LaserDirectionChecker.IsLaserMovingRight(roomPosition, previousLaserPosition))
                return LaserMover.MoveRight(roomPosition);

            return LaserMover.MoveDown(roomPosition);
        }
    }
}