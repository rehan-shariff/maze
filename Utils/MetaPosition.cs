namespace Maze
{
    public struct MetaPosition
    {
        public Position Position { get; }
        public string MetaData { get; }

        public MetaPosition(Position position, string metaData)
        {
            this.Position = position;
            this.MetaData = metaData;
        }
    }
}