using Maze;
using System.Collections.Generic;

namespace Maze.UnitTests
{
    public class FakeStreamReader: IStreamReader
    {
        private readonly Queue<string> queue;

        public FakeStreamReader(Queue<string> readLineQueue)
        {
            queue = readLineQueue;
        }

        public string ReadLine()
        {
            if (queue.Count > 0)
                return queue.Dequeue();
            return null;
        }
    }
}