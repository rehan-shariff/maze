namespace Maze
{
    public class NullMirror : IMirror
    {
        public Position AdvanceLaser(Position roomPosition, Position previousLaserPosition)
        {
            if (LaserDirectionChecker.IsLaserMovingUp(roomPosition, previousLaserPosition))
                return LaserMover.MoveUp(roomPosition);
            
            if (LaserDirectionChecker.IsLaserMovingDown(roomPosition, previousLaserPosition))
                return LaserMover.MoveDown(roomPosition);
            
            if (LaserDirectionChecker.IsLaserMovingRight(roomPosition, previousLaserPosition))
                return LaserMover.MoveRight(roomPosition);
            
            return LaserMover.MoveLeft(roomPosition);
        }
    }
}