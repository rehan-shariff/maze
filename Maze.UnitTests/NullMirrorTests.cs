using NUnit.Framework;
using Maze;

namespace Maze.UnitTests
{
    [TestFixture()]
    public class NullMirrorTests
    {
        private readonly NullMirror mirror = new NullMirror();
        private readonly Position roomPosition = new Position(1, 1);

        [Test()]
        public void GivenLaserIsMovingUpWhenAdvanceThenLaserMovesUp()
        {
            var previousLaserPosition = new Position(1, 0);
            var expectedLaserPosition = new Position(1, 2);

            var actualNextLaserPosition = mirror.AdvanceLaser(roomPosition, previousLaserPosition);

            Assert.AreEqual(expectedLaserPosition, actualNextLaserPosition);
        }

        [Test()]
        public void GivenLaserIsMovingDownWhenAdvanceThenLaserMovesDown()
        {
            var previousLaserPosition = new Position(1, 2);
            var expectedLaserPosition = new Position(1, 0);

            var actualNextLaserPosition = mirror.AdvanceLaser(roomPosition, previousLaserPosition);

            Assert.AreEqual(expectedLaserPosition, actualNextLaserPosition);
        }

        [Test()]
        public void GivenLaserIsMovingRightWhenAdvanceThenLaserMovesRight()
        {
            var previousLaserPosition = new Position(0, 1);
            var expectedLaserPosition = new Position(2, 1);

            var actualNextLaserPosition = mirror.AdvanceLaser(roomPosition, previousLaserPosition);

            Assert.AreEqual(expectedLaserPosition, actualNextLaserPosition);
        }

        [Test()]
        public void GivenLaserIsMovingLefttWhenAdvanceThenLaserMovesLeft()
        {
            var previousLaserPosition = new Position(2, 1);
            var expectedLaserPosition = new Position(0, 1);

            var actualNextLaserPosition = mirror.AdvanceLaser(roomPosition, previousLaserPosition);

            Assert.AreEqual(expectedLaserPosition, actualNextLaserPosition);
        }
    }
}