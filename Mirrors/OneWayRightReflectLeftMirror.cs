namespace Maze
{
    public class OneWayRightReflectLeftMirror : IMirror
    {
        public Position AdvanceLaser(Position roomPosition, Position previousLaserPosition)
        {
            if (LaserDirectionChecker.IsLaserMovingUp(roomPosition, previousLaserPosition) ||
                LaserDirectionChecker.IsLaserMovingRight(roomPosition, previousLaserPosition))
                return LaserMover.MoveUp(roomPosition);
            
            return LaserMover.MoveLeft(roomPosition);
        }
    }
}