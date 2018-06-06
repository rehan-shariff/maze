using System;
using System.Text.RegularExpressions;

namespace Maze
{
    public class MazeReader
    {
        private readonly IStreamReader streamReader;

        public MazeReader(IStreamReader reader)
        {
            streamReader = reader;
        }

        public void Read(MazeSetup mazeSetup)
        {
            ReadDimensions(mazeSetup);
            ReadMirrors(mazeSetup);
            ReadLaserStart(mazeSetup);
        }

        private void ReadDimensions(MazeSetup mazeSetup)
        {
            try
            {
                var dimensions = streamReader.ReadLine().Split(',');
                mazeSetup.Width = Int32.Parse(dimensions[0]);
                mazeSetup.Length = Int32.Parse(dimensions[1]);
                ReadDummySectionEndDelimeter();
            }
            catch (SystemException)
            {
                Console.WriteLine("Exception while reading maze dimensions");
            }
        }

        private void ReadMirrors(MazeSetup mazeSetup)
        {
            string line;
            const string sectionEndDelimeter = "-1";

            while (null != (line = streamReader.ReadLine()) &&
                   sectionEndDelimeter != line)
            {
                ReadMirror(line, mazeSetup);
            }
        }

        private void ReadMirror(string line, MazeSetup mazeSetup)
        {
            var positionAndOrientationSplitter = new Regex("(?<=[0-9,])(?=[LR])");

            try
            {
                var mirror = ReadPositionAndOrientation(positionAndOrientationSplitter, line);
                mazeSetup.Mirrors.Add(mirror);
            }
            catch (SystemException)
            {
                Console.WriteLine("Exception while reading maze mirror");
            }
        }

        private MetaPosition ReadPositionAndOrientation(Regex splittingCriteria, string line)
        {
            string[] positionAndOrientation = splittingCriteria.Split(line, 2);
            string[] position = positionAndOrientation[0].Split(',');
            string orientation = positionAndOrientation[1];
            int positionX = Int32.Parse(position[0]);
            int positionY = Int32.Parse(position[1]);
            return new MetaPosition(new Position(positionX, positionY), orientation);
        }

        private void ReadLaserStart(MazeSetup mazeSetup)
        {
            var positionAndOrientationSplitter = new Regex("(?<=[0-9,])(?=[HV])");

            try
            {
                var line = streamReader.ReadLine();
                var laserStart = ReadPositionAndOrientation(positionAndOrientationSplitter, line);
                mazeSetup.LaserStart = laserStart;
                ReadDummySectionEndDelimeter();
            }
            catch (SystemException)
            {
                Console.WriteLine("Exception while reading maze laser start");
            }
        }

        // Each section ends with a "-1". We need to read the line to move to the next section.
        private void ReadDummySectionEndDelimeter()
        {
            streamReader.ReadLine();
        }
    }
}