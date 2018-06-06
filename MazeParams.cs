using System.Collections.Generic;

namespace Maze
{
    public class MazeParams
    {
        public int Length { get; set; }
        public int Width { get; set; }
        public List<MetaPosition> Mirrors { get; }
        public MetaPosition LaserStart { get; set; }

        public MazeParams()
        {
            Mirrors = new List<MetaPosition>();
        }
    }
}