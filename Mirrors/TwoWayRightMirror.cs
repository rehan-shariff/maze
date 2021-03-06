﻿namespace Maze
{
    public class TwoWayRightMirror : IMirror
    {
        public Position AdvanceLaser(Position roomPosition, Position previousLaserPosition)
        {
            if (LaserDirectionChecker.IsLaserMovingUp(roomPosition, previousLaserPosition))
                return LaserMover.MoveRight(roomPosition);
            
            if (LaserDirectionChecker.IsLaserMovingDown(roomPosition, previousLaserPosition))
                return LaserMover.MoveLeft(roomPosition);
            
            if (LaserDirectionChecker.IsLaserMovingRight(roomPosition, previousLaserPosition))
                return LaserMover.MoveUp(roomPosition);
            
            return LaserMover.MoveDown(roomPosition);
        }
    }
}