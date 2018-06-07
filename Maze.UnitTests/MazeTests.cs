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

        private void AssertMirrorCount(MazeParams mazeParams, FakeMirrorFactory factory)
        {
            var expectedNumberOfMirrors = mazeParams.Length * mazeParams.Width + mazeParams.Mirrors.Count;
            Assert.AreEqual(expectedNumberOfMirrors, factory.MirrorCount);
        }

        private void AssertSpecialMirrorCounts(FakeMirrorFactory factory)
        {
            const int expectedNumberOfTwoWayLeftMirrors = 3;
            const int expectedNumberOfTwoWayRightMirrors = 2;
            const int expectedNumberOfOneWayTypeMirrors = 1;
            Assert.AreEqual(expectedNumberOfTwoWayLeftMirrors, factory.TwoWayLeftMirrorCount);
            Assert.AreEqual(expectedNumberOfTwoWayRightMirrors, factory.TwoWayRightMirrorCount);
            Assert.AreEqual(expectedNumberOfOneWayTypeMirrors, factory.OneWayRightReflectRightMirrorCount);
            Assert.AreEqual(expectedNumberOfOneWayTypeMirrors, factory.OneWayRightReflectLeftMirrorCount);
            Assert.AreEqual(expectedNumberOfOneWayTypeMirrors, factory.OneWayLeftReflectRightMirrorCount);
            Assert.AreEqual(expectedNumberOfOneWayTypeMirrors, factory.OneWayLeftReflectLeftMirrorCount);
        }
    }
}