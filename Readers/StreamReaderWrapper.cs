using System.IO;

namespace Maze
{
    public class StreamReaderWrapper : IStreamReader
    {
        private readonly StreamReader reader;

        public StreamReaderWrapper(string filePath)
        {
            reader = new StreamReader(filePath);
        }

        public string ReadLine()
        {
            return reader.ReadLine();
        }
    }
}