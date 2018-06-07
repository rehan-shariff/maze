using NUnit.Framework;
using Maze;
using System.Collections.Generic;

namespace Maze.UnitTests
{
    [TestFixture()]
    public class MazeTests
    {
        [Test()]
        public void GivenParamsWhenMazeConstructedItCreatesCorrectNumberOfMirrors()
        {
            var mazeParams = new MazeParams()
            {
                Length = 5,
                Width = 4,
                Mirrors = new List<MetaPosition>()
                {
                    new MetaPosition(new Position(0,0), "L"),
                    new MetaPosition(new Position(0,0), "L"),
                    new MetaPosition(new Position(0,0), "L"),
                    new MetaPosition(new Position(0,0), "R"),
                    new MetaPosition(new Position(0,0), "R"),
                    new MetaPosition(new Position(0,0), "RL"),
                    new MetaPosition(new Position(0,0), "RR"),
                    new MetaPosition(new Position(0,0), "LL"),
                    new MetaPosition(new Position(0,0), "LR")
                }
            };
            var fakeMirrorFactory = new FakeMirrorFactory();

            var maze = new Maze(mazeParams, fakeMirrorFactory);

            AssertMirrorCount(mazeParams, fakeMirrorFactory);
            AssertSpecialMirrorCounts(fakeMirrorFactory);
        }

        [Test()]
        public void GivenOneRoomAndLaserStartsHorizontallyWhenShootLaserThenLaserEndsHorizontally()
        {
            var maze = CreateMaze(1, 
                                  1, 
                                  new List<MetaPosition>(), 
                                  new MetaPosition(new Position(0, 0), "H"));

            var actualLaserEnd = maze.ShootLaser();

            Assert.AreEqual(0, actualLaserEnd.Position.X);
            Assert.AreEqual(0, actualLaserEnd.Position.Y);
            Assert.AreEqual("H", actualLaserEnd.MetaData);
        }

        [Test()]
        public void GivenOneRoomAndLaserStarsVerticallyWhenShootLaserThenLaserEndsVertically()
        {
            var maze = CreateMaze(1,
                                  1,
                                  new List<MetaPosition>(),
                                  new MetaPosition(new Position(0, 0), "V"));

            var actualLaserEnd = maze.ShootLaser();

            Assert.AreEqual(0, actualLaserEnd.Position.X);
            Assert.AreEqual(0, actualLaserEnd.Position.Y);
            Assert.AreEqual("V", actualLaserEnd.MetaData);
        }

        [Test()]
        public void GivenOneRoomWithMirrorWhenShootLaserThenLaserEndIsCorrect()
        {
            var maze = CreateMaze(1,
                                  1,
                                  new List<MetaPosition>(){ new MetaPosition(new Position(0, 0), "L")},
                                  new MetaPosition(new Position(0, 0), "V"));

            var actualLaserEnd = maze.ShootLaser();

            Assert.AreEqual(0, actualLaserEnd.Position.X);
            Assert.AreEqual(0, actualLaserEnd.Position.Y);
            Assert.AreEqual("H", actualLaserEnd.MetaData);
        }

        [Test()]
        public void GivenMultipleRoomsWithMirrorsWhenShootLaserThenLaserEndIsCorrect()
        {
            var maze = CreateMaze(4,
                                  5,
                                  new List<MetaPosition>()
                                  {
                                     new MetaPosition(new Position(1,2), "RR"),
                                     new MetaPosition(new Position(3,2), "L"),
                                  },
                                  new MetaPosition(new Position(1, 0), "V"));

            var actualLaserEnd = maze.ShootLaser();

            Assert.AreEqual(3, actualLaserEnd.Position.X);
            Assert.AreEqual(0, actualLaserEnd.Position.Y);
            Assert.AreEqual("V", actualLaserEnd.MetaData);
        }

        [Test()]
        public void GivenLaserStartInTopRightCornerWhenShootLaserThenLaserEndIsCorrect()
        {
            var maze = CreateMaze(4,
                                  5,
                                  new List<MetaPosition>()
                                  {
                                     new MetaPosition(new Position(1,2), "RR"),
                                     new MetaPosition(new Position(3,2), "L"),
                                  },
                                  new MetaPosition(new Position(4, 3), "V"));

            var actualLaserEnd = maze.ShootLaser();

            Assert.AreEqual(4, actualLaserEnd.Position.X);
            Assert.AreEqual(0, actualLaserEnd.Position.Y);
            Assert.AreEqual("V", actualLaserEnd.MetaData);
        }

        private Maze CreateMaze(int length, int width, List<MetaPosition> mirrors, MetaPosition laserStart)
        {
            var mazeParams = new MazeParams()
            {
                Length = length,
                Width = width,
                Mirrors = mirrors,
                LaserStart = laserStart
            };
            var mirrorFactory = new MirrorFactory();
            return new Maze(mazeParams, mirrorFactory);
        }

        private void AssertMirrorCount(MazeParams mazeParams, FakeMirrorFactory factory)
        {
            var expectedNumberOfMirrors = mazeParams.Length * mazeParams.Width + mazeParams.Mirrors.Count;
            Assert.AreEqual(expectedNumberOfMirrors, factory.MirrorCount);
        }

        private void AssertSpecialMirrorCounts(FakeMirrorFactory factory)
        {
            Assert.AreEqual(3, factory.TwoWayLeftMirrorCount);
            Assert.AreEqual(2, factory.TwoWayRightMirrorCount);
            Assert.AreEqual(1, factory.OneWayRightReflectRightMirrorCount);
            Assert.AreEqual(1, factory.OneWayRightReflectLeftMirrorCount);
            Assert.AreEqual(1, factory.OneWayLeftReflectRightMirrorCount);
            Assert.AreEqual(1, factory.OneWayLeftReflectLeftMirrorCount);
        }
    }
}