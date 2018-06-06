namespace Maze
{
    public static class LaserMover
    {
        public static Position MoveUp(Position roomPosition)
        {
            return new Position(roomPosition.X, roomPosition.Y + 1);
        }

        public static Position MoveDown(Position roomPosition)
        {
            return new Position(roomPosition.X, roomPosition.Y - 1);
        }

        public static Position MoveRight(Position roomPosition)
        {
            return new Position(roomPosition.X + 1, roomPosition.Y);
        }

        public static Position MoveLeft(Position roomPosition)
        {
            return new Position(roomPosition.X - 1, roomPosition.Y);
        }  
    }
}