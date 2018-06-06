using NUnit.Framework;
using Maze;
using System.Collections.Generic;

namespace Maze.UnitTests
{
    [TestFixture()]
    public class MazeReaderTests
    {
        private MazeSetup mazeSetup;
        private FakeStreamReader fakeStreamReader;
        private MazeReader mazeFileReader;

        [SetUp()]
        public void SetUp()
        {
            mazeSetup = new MazeSetup();
        }

        [Test()]
        public void GivenNoMirrorsWhenReadThenMazeHasDimensionsAndLaserStartButNoMirrors()
        {
            fakeStreamReader = new FakeStreamReader(CreateQueueWithNoMirrors());
            mazeFileReader = new MazeReader(fakeStreamReader);

            mazeFileReader.Read(mazeSetup);

            AssertDimensions();
            Assert.IsEmpty(mazeSetup.Mirrors);
            AssertLaserStart();
        }

        [Test()]
        public void GivenSingleTwoSidedMirrorWhenReadThenMazeHasOneMirror()
        {
            fakeStreamReader = new FakeStreamReader(CreateQueueWithSingleTwoSidedMirror());
            mazeFileReader = new MazeReader(fakeStreamReader);

            mazeFileReader.Read(mazeSetup);

            AssertDimensions();
            AssertSingleTwoSidedMirror();
            AssertLaserStart();
        }

        [Test()]
        public void GivenMultipleTwoSidedMirrorsWhenReadThenMazeHasMultipleMirrors()
        {
            fakeStreamReader = new FakeStreamReader(CreateQueueWithMultipleTwoSidedMirrors());
            mazeFileReader = new MazeReader(fakeStreamReader);

            mazeFileReader.Read(mazeSetup);

            AssertDimensions();
            AssertMultipleTwoSidedMirrors();
            AssertLaserStart();
        }

        [Test()]
        public void GivenMultipleMirrorTypesWhenReadThenMazeHasMultipleMirrorTypes()
        {
            fakeStreamReader = new FakeStreamReader(CreateQueueWithMultipleMirrorTypes());
            mazeFileReader = new MazeReader(fakeStreamReader);

            mazeFileReader.Read(mazeSetup);

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
            const int expectedLength = 4;
            const int expectedWidth = 5;
            Assert.AreEqual(expectedLength, mazeSetup.Length);
            Assert.AreEqual(expectedWidth, mazeSetup.Width);
        }

        private void AssertSingleTwoSidedMirror()
        {
            var expectedMirror = new MetaPosition(new Position(3, 2), "L");
            Assert.True(mazeSetup.Mirrors.Contains(expectedMirror));
        }

        private void AssertMultipleTwoSidedMirrors()
        {
            var expectedMirror1 = new MetaPosition(new Position(3, 2), "L");
            var expectedMirror2 = new MetaPosition(new Position(1, 2), "R");
            Assert.True(mazeSetup.Mirrors.Contains(expectedMirror1));
            Assert.True(mazeSetup.Mirrors.Contains(expectedMirror2));
        }

        private void AssertMultipleMirrorTypes()
        {
            var expectedMirror1 = new MetaPosition(new Position(3, 2), "L");
            var expectedMirror2 = new MetaPosition(new Position(1, 2), "RL");
            Assert.True(mazeSetup.Mirrors.Contains(expectedMirror1));
            Assert.True(mazeSetup.Mirrors.Contains(expectedMirror2));
        }

        private void AssertLaserStart()
        {
            const int expectedLaserStartPositionX = 0;
            const int expectedLaserStartPositionY = 0;
            const string expectedLaserStartOrientation = "H";
            Assert.AreEqual(expectedLaserStartPositionX, mazeSetup.LaserStart.Position.X);
            Assert.AreEqual(expectedLaserStartPositionY, mazeSetup.LaserStart.Position.Y);
            Assert.AreEqual(expectedLaserStartOrientation, mazeSetup.LaserStart.MetaData);
        }
    }
}