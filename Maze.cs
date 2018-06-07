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
            SetupRoomsWithDefaultMirrors(mazeParams, mirrorFactory);
            SetupRoomWithSpecialMirrors(mazeParams, mirrorFactory);
        }

        void SetupRoomsWithDefaultMirrors(MazeParams mazeParams, IMirrorFactory mirrorFactory)
        {
            for (var x = 0; x < mazeParams.Width; x++)
            {
                for (var y = 0; y < mazeParams.Length; y++)
                {
                    rooms[x,y] = mirrorFactory.CreateMirror();
                }
            }
        }

        void SetupRoomWithSpecialMirrors(MazeParams mazeParams, IMirrorFactory mirrorFactory)
        {
            mazeParams.Mirrors.ForEach(mirror =>
            {
                rooms[mirror.Position.X, mirror.Position.Y] = mirrorFactory.CreateMirror(mirror.MetaData);
            });
        }
    }
}