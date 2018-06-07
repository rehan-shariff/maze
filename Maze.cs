using System;
using System.Linq;

namespace Maze
{
    public class Maze
    {
        private IMirror[,] rooms;
        private readonly MazeParams mazeParams;

        public Maze(MazeParams mazeParams, IMirrorFactory mirrorFactory)
        {
            this.mazeParams = mazeParams;
            rooms = new IMirror[mazeParams.Width, mazeParams.Length];
            SetupRoomsWithDefaultMirrors(mirrorFactory);
            SetupRoomWithSpecialMirrors(mirrorFactory);
        }

        public MetaPosition ShootLaser()
        {
            var startPosition = mazeParams.LaserStart.Position;
            var previousPosition = CalculatePreviousPosition(); 
            Position nextPosition;

            do
            {
                nextPosition = rooms[startPosition.X, startPosition.Y]
                                  .AdvanceLaser(startPosition, previousPosition);
                previousPosition = startPosition;
                startPosition = nextPosition;
            }
            while (IsLaserInMaze(nextPosition));

            return CalculateExitMetaPosition(nextPosition, previousPosition);
        }

        void SetupRoomsWithDefaultMirrors(IMirrorFactory mirrorFactory)
        {
            for (var x = 0; x < mazeParams.Width; x++)
            {
                for (var y = 0; y < mazeParams.Length; y++)
                {
                    rooms[x,y] = mirrorFactory.CreateMirror();
                }
            }
        }

        void SetupRoomWithSpecialMirrors(IMirrorFactory mirrorFactory)
        {
            mazeParams.Mirrors.ForEach(mirror =>
            {
                rooms[mirror.Position.X, mirror.Position.Y] = mirrorFactory.CreateMirror(mirror.MetaData);
            });
        }

        private Position CalculatePreviousPosition()
        {
            var laser = LaserFactory.CreateLaser(mazeParams.LaserStart.MetaData);
            return laser.CalculatePreviousPosition(mazeParams.LaserStart.Position);
        }

        private bool IsLaserInMaze(Position position)
        {
            return (position.X >= 0 &&
                    position.Y >= 0 &&
                    position.X < mazeParams.Width &&
                    position.Y < mazeParams.Length);
        }

        private MetaPosition CalculateExitMetaPosition(Position finalPosition, Position previousPosition)
        {
            if (finalPosition.X < previousPosition.X)
                return new MetaPosition(new Position(finalPosition.X + 1, finalPosition.Y), "H");
     
            if (finalPosition.X > previousPosition.X)
                return new MetaPosition(new Position(finalPosition.X - 1, finalPosition.Y), "H");

            if (finalPosition.Y < previousPosition.Y)
                return new MetaPosition(new Position(finalPosition.X, finalPosition.Y + 1), "V");

            return new MetaPosition(new Position(finalPosition.X, finalPosition.Y - 1), "V");
        }
    }
}