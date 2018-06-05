using NUnit.Framework;
using Maze;

namespace Maze.UnitTests
{
    [TestFixture()]
    public class NullMirrorTests
    {
        private readonly NullMirror mirror;
        private readonly Coordinate roomPosition;

        public NullMirrorTests()
        {
            mirror = new NullMirror();
            roomPosition = new Coordinate(1, 1);
        }

        [Test()]
        public void GivenLaserIsMovingUpWhenAdvanceThenLaserMovesUp()
        {
            Coordinate previousLaserPosition = new Coordinate(0, 1);
            Coordinate expectedLaserPosition = new Coordinate(2, 1);

            Coordinate actualNextLaserPosition = mirror.AdvanceLaser(roomPosition, previousLaserPosition);

            Assert.AreEqual(expectedLaserPosition, actualNextLaserPosition);
        }

        [Test()]
        public void GivenLaserIsMovingDownWhenAdvanceThenLaserMovesDown()
        {
            Coordinate previousLaserPosition = new Coordinate(2, 1);
            Coordinate expectedLaserPosition = new Coordinate(0, 1);

            Coordinate actualNextLaserPosition = mirror.AdvanceLaser(roomPosition, previousLaserPosition);

            Assert.AreEqual(expectedLaserPosition, actualNextLaserPosition);
        }

        [Test()]
        public void GivenLaserIsMovingRightWhenAdvanceThenLaserMovesRight()
        {
            Coordinate previousLaserPosition = new Coordinate(1, 0);
            Coordinate expectedLaserPosition = new Coordinate(1, 2);

            Coordinate actualNextLaserPosition = mirror.AdvanceLaser(roomPosition, previousLaserPosition);

            Assert.AreEqual(expectedLaserPosition, actualNextLaserPosition);
        }

        [Test()]
        public void GivenLaserIsMovingLefttWhenAdvanceThenLaserMovesLeft()
        {
            Coordinate previousLaserPosition = new Coordinate(1, 2);
            Coordinate expectedLaserPosition = new Coordinate(1, 0);

            Coordinate actualNextLaserPosition = mirror.AdvanceLaser(roomPosition, previousLaserPosition);

            Assert.AreEqual(expectedLaserPosition, actualNextLaserPosition);
        }
    }
}
