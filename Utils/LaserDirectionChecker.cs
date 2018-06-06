namespace Maze
{
    public static class LaserDirectionChecker
    {
        public static bool IsLaserMovingUp(Position roomPosition, Position previousLaserPosition)
        {
            return (roomPosition.Y > previousLaserPosition.Y);
        }

        public static bool IsLaserMovingDown(Position roomPosition, Position previousLaserPosition)
        {
            return (roomPosition.Y < previousLaserPosition.Y);
        }

        public static bool IsLaserMovingRight(Position roomPosition, Position previousLaserPosition)
        {
            return (roomPosition.X > previousLaserPosition.X);
        }

        public static bool IsLaserMovingLeft(Position roomPosition, Position previousLaserPosition)
        {
            return (roomPosition.X < previousLaserPosition.X);
        }
    }
}