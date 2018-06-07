using System;
using System.Collections.Generic;
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

        public void Read(MazeParams mazeParams)
        {
            ReadDimensions(mazeParams);
            ReadMirrors(mazeParams);
            ReadLaserStart(mazeParams);
        }

        private void ReadDimensions(MazeParams mazeParams)
        {
            try
            {
                var dimensions = streamReader.ReadLine().Split(',');
                mazeParams.Width = Int32.Parse(dimensions[0]);
                mazeParams.Length = Int32.Parse(dimensions[1]);
                ReadDummySectionEndDelimeter();
            }
            catch (SystemException)
            {
                Console.WriteLine("Exception while reading maze dimensions");
            }
        }

        private void ReadMirrors(MazeParams mazeParams)
        {
            string line;
            const string sectionEndDelimeter = "-1";

            mazeParams.Mirrors = new List<MetaPosition>();

            while (null != (line = streamReader.ReadLine()) &&
                   sectionEndDelimeter != line)
            {
                ReadMirror(line, mazeParams);
            }
        }

        private void ReadMirror(string line, MazeParams mazeParams)
        {
            var positionAndOrientationSplitter = new Regex("(?<=[0-9,])(?=[LR])");

            try
            {
                var mirror = ReadPositionAndOrientation(positionAndOrientationSplitter, line);
                mazeParams.Mirrors.Add(mirror);
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

        private void ReadLaserStart(MazeParams mazeParams)
        {
            var positionAndOrientationSplitter = new Regex("(?<=[0-9,])(?=[HV])");

            try
            {
                var line = streamReader.ReadLine();
                var laserStart = ReadPositionAndOrientation(positionAndOrientationSplitter, line);
                mazeParams.LaserStart = laserStart;
                ReadDummySectionEndDelimeter();
            }
            catch (SystemException)
            {
                Console.WriteLine("Exception while reading maze laser start");
            }
        }

        // Each section of the file ends with a "-1"
        // We need to read the line to move to the next section
        private void ReadDummySectionEndDelimeter()
        {
            streamReader.ReadLine();
        }
    }
}