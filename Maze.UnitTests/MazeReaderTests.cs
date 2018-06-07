using NUnit.Framework;
using Maze;
using System.Collections.Generic;

namespace Maze.UnitTests
{
    [TestFixture()]
    public class MazeReaderTests
    {
        private MazeParams mazeParams;
        private FakeStreamReader fakeStreamReader;
        private MazeReader mazeFileReader;

        [SetUp()]
        public void SetUp()
        {
            mazeParams = new MazeParams();
        }

        [Test()]
        public void GivenNoMirrorsWhenReadThenMazeHasDimensionsAndLaserStartButNoMirrors()
        {
            fakeStreamReader = new FakeStreamReader(CreateQueueWithNoMirrors());
            mazeFileReader = new MazeReader(fakeStreamReader);

            mazeFileReader.Read(mazeParams);

            AssertDimensions();
            Assert.IsEmpty(mazeParams.Mirrors);
            AssertLaserStart();
        }

        [Test()]
        public void GivenSingleTwoSidedMirrorWhenReadThenMazeHasOneMirror()
        {
            fakeStreamReader = new FakeStreamReader(CreateQueueWithSingleTwoSidedMirror());
            mazeFileReader = new MazeReader(fakeStreamReader);

            mazeFileReader.Read(mazeParams);

            AssertDimensions();
            AssertSingleTwoSidedMirror();
            AssertLaserStart();
        }

        [Test()]
        public void GivenMultipleTwoSidedMirrorsWhenReadThenMazeHasMultipleMirrors()
        {
            fakeStreamReader = new FakeStreamReader(CreateQueueWithMultipleTwoSidedMirrors());
            mazeFileReader = new MazeReader(fakeStreamReader);

            mazeFileReader.Read(mazeParams);

            AssertDimensions();
            AssertMultipleTwoSidedMirrors();
            AssertLaserStart();
        }

        [Test()]
        public void GivenMultipleMirrorTypesWhenReadThenMazeHasMultipleMirrorTypes()
        {
            fakeStreamReader = new FakeStreamReader(CreateQueueWithMultipleMirrorTypes());
            mazeFileReader = new MazeReader(fakeStreamReader);

            mazeFileReader.Read(mazeParams);

            AssertDimensions();
            AssertMultipleMirrorTypes();
            AssertLaserStart();
        }

        private Queue<string> CreateQueueWithMazeDimensions()
        {
            var queue = new Queue<string>();
            queue.Enqueue("5,4");
            queue.Enqueue("-1");
            return queue;
        }

        private void AddLaserStartToQueue(Queue<string> queue)
        {
            queue.Enqueue("0,0H");
            queue.Enqueue("-1");
        }

        private Queue<string> CreateQueueWithNoMirrors()
        {
            var queue = CreateQueueWithMazeDimensions();
            queue.Enqueue("-1");
            AddLaserStartToQueue(queue);
            return queue;
        }

        private Queue<string> CreateQueueWithSingleTwoSidedMirror()
        {
            var queue = CreateQueueWithMazeDimensions();
            queue.Enqueue("3,2L");
            queue.Enqueue("-1");
            AddLaserStartToQueue(queue);
            return queue;
        }

        private Queue<string> CreateQueueWithMultipleTwoSidedMirrors()
        {
            var queue = CreateQueueWithMazeDimensions();
            queue.Enqueue("3,2L");
            queue.Enqueue("1,2R");
            queue.Enqueue("-1");
            AddLaserStartToQueue(queue);
            return queue;
        }

        private Queue<string> CreateQueueWithMultipleMirrorTypes()
        {
            var queue = CreateQueueWithMazeDimensions();
            queue.Enqueue("3,2L");
            queue.Enqueue("1,2RL");
            queue.Enqueue("-1");
            AddLaserStartToQueue(queue);
            return queue;   
        }

        private void AssertDimensions()
        {
            Assert.AreEqual(4, mazeParams.Length);
            Assert.AreEqual(5, mazeParams.Width);
        }

        private void AssertSingleTwoSidedMirror()
        {
            var expectedMirror = new MetaPosition(new Position(3, 2), "L");
            Assert.True(mazeParams.Mirrors.Contains(expectedMirror));
        }

        private void AssertMultipleTwoSidedMirrors()
        {
            var expectedMirror1 = new MetaPosition(new Position(3, 2), "L");
            var expectedMirror2 = new MetaPosition(new Position(1, 2), "R");
            Assert.True(mazeParams.Mirrors.Contains(expectedMirror1));
            Assert.True(mazeParams.Mirrors.Contains(expectedMirror2));
        }

        private void AssertMultipleMirrorTypes()
        {
            var expectedMirror1 = new MetaPosition(new Position(3, 2), "L");
            var expectedMirror2 = new MetaPosition(new Position(1, 2), "RL");
            Assert.True(mazeParams.Mirrors.Contains(expectedMirror1));
            Assert.True(mazeParams.Mirrors.Contains(expectedMirror2));
        }

        private void AssertLaserStart()
        {
            Assert.AreEqual(0, mazeParams.LaserStart.Position.X);
            Assert.AreEqual(0, mazeParams.LaserStart.Position.Y);
            Assert.AreEqual("H", mazeParams.LaserStart.MetaData);
        }
    }
}