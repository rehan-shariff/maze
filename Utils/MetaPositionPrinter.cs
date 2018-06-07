using System;

namespace Maze
{
    public static class MetaPositionStringFormatter
    {
        public static string Format(MetaPosition metaPosition)
        {
            return String.Format("({0},{1}){2}", 
                                 metaPosition.Position.X, 
                                 metaPosition.Position.Y, 
                                 metaPosition.MetaData);
        }
    }
}