using NUnit.Framework;
using Maze;

namespace Maze.UnitTests
{
    [TestFixture()]
    public class TwoWayRightMirrorTests
    {
        private readonly TwoWayRightMirror mirror = new TwoWayRightMirror();
        private readonly Coordinate roomPosition = new Coordinate(1, 1);

        [Test()]
        public void GivenLaserIsMovingUpWhenAdvanceThenLaserMovesRight()
        {
            var previousLaserPosition = new Coordinate(1, 0);
            var expectedLaserPosition = new Coordinate(2, 1);

            var actualNextLaserPosition = mirror.AdvanceLaser(roomPosition, previousLaserPosition);

            Assert.AreEqual(expectedLaserPosition, actualNextLaserPosition);
        }

        [Test()]
        public void GivenLaserIsMovingDownWhenAdvanceThenLaserMovesLeft()
        {
            var previousLaserPosition = new Coordinate(1, 2);
            var expectedLaserPosition = new Coordinate(0, 1);

            var actualNextLaserPosition = mirror.AdvanceLaser(roomPosition, previousLaserPosition);

            Assert.AreEqual(expectedLaserPosition, actualNextLaserPosition);
        }

        [Test()]
        public void GivenLaserIsMovingRightWhenAdvanceThenLaserMovesUp()
        {
            var previousLaserPosition = new Coordinate(0, 1);
            var expectedLaserPosition = new Coordinate(1, 0);

            var actualNextLaserPosition = mirror.AdvanceLaser(roomPosition, previousLaserPosition);

            Assert.AreEqual(expectedLaserPosition, actualNextLaserPosition);
        }

        [Test()]
        public void GivenLaserIsMovingLeftWhenAdvanceThenLaserMovesDown()
        {
            var previousLaserPosition = new Coordinate(2, 1);
            var expectedLaserPosition = new Coordinate(1, 2);

            var actualNextLaserPosition = mirror.AdvanceLaser(roomPosition, previousLaserPosition);

            Assert.AreEqual(expectedLaserPosition, actualNextLaserPosition);
        }
    }
}
