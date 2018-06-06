namespace Maze
{
    public class TwoWayLeftMirror : IMirror
    {
        public Position AdvanceLaser(Position roomPosition, Position previousLaserPosition)
        {
            if (LaserDirectionChecker.IsLaserMovingUp(roomPosition, previousLaserPosition))
                return LaserMover.MoveLeft(roomPosition);

            if (LaserDirectionChecker.IsLaserMovingDown(roomPosition, previousLaserPosition))
                return LaserMover.MoveRight(roomPosition);

            if (LaserDirectionChecker.IsLaserMovingRight(roomPosition, previousLaserPosition))
                return LaserMover.MoveDown(roomPosition);

            return LaserMover.MoveUp(roomPosition);
        }
    }
}