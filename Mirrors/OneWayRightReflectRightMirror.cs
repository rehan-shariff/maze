﻿namespace Maze
{
    public class OneWayRightReflectRightMirror : IMirror
    {
        public Coordinate AdvanceLaser(Coordinate roomPosition, Coordinate previousLaserPosition)
        {
            return new Coordinate(0, 0);
        }
    }
}