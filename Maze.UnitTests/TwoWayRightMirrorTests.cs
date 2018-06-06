using NUnit.Framework;
using Maze;

namespace Maze.UnitTests
{
    [TestFixture()]
    public class TwoWayRightMirrorTests
    {
        private readonly TwoWayRightMirror mirror = new TwoWayRightMirror();
        private readonly Position roomPosition = new Position(1, 1);

        [Test()]
        public void GivenLaserIsMovingUpWhenAdvanceThenLaserMovesRight()
        {
            var previousLaserPosition = new Position(1, 0);
            var expectedLaserPosition = new Position(2, 1);

            var actualNextLaserPosition = mirror.AdvanceLaser(roomPosition, previousLaserPosition);

            Assert.AreEqual(expectedLaserPosition, actualNextLaserPosition);
        }

        [Test()]
        public void GivenLaserIsMovingDownWhenAdvanceThenLaserMovesLeft()
        {
            var previousLaserPosition = new Position(1, 2);
            var expectedLaserPosition = new Position(0, 1);

            var actualNextLaserPosition = mirror.AdvanceLaser(roomPosition, previousLaserPosition);

            Assert.AreEqual(expectedLaserPosition, actualNextLaserPosition);
        }

        [Test()]
        public void GivenLaserIsMovingRightWhenAdvanceThenLaserMovesDown()
        {
            var previousLaserPosition = new Position(0, 1);
            var expectedLaserPosition = new Position(1, 0);

            var actualNextLaserPosition = mirror.AdvanceLaser(roomPosition, previousLaserPosition);

            Assert.AreEqual(expectedLaserPosition, actualNextLaserPosition);
        }

        [Test()]
        public void GivenLaserIsMovingLeftWhenAdvanceThenLaserMovesUp()
        {
            var previousLaserPosition = new Position(2, 1);
            var expectedLaserPosition = new Position(1, 2);

            var actualNextLaserPosition = mirror.AdvanceLaser(roomPosition, previousLaserPosition);

            Assert.AreEqual(expectedLaserPosition, actualNextLaserPosition);
        }
    }
}
