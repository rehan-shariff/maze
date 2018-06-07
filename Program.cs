using System;

namespace Maze
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            if(args.Length != 1)
            {
                Console.WriteLine("The proper usage is: Maze.exe input_file_path/file_name.txt");
                return;
            }

            RunMaze(args[0]);
        }

        private static void RunMaze(string filePath)
        {
            var mazeReader = new MazeReader(new StreamReaderWrapper(filePath));
            var mazeParams = new MazeParams();
            mazeReader.Read(mazeParams);
            var maze = new Maze(mazeParams, new MirrorFactory());
            var endLaserPosition = maze.ShootLaser();
            Print(mazeParams, endLaserPosition);
        }

        private static void Print(MazeParams mazeParams, MetaPosition endPosition)
        {
            Console.WriteLine("(X,Y) = ({0},{1})", mazeParams.Width, mazeParams.Length);
            Console.WriteLine("start: {0}", MetaPositionStringFormatter.Format(mazeParams.LaserStart));
            Console.WriteLine("end: {0}", MetaPositionStringFormatter.Format(endPosition));     
        }
    }
}