using NUnit.Framework;
using Maze;
namespace Maze.UnitTests
{
    [TestFixture()]
    public class OneWayLeftReflectRightMirrorTests
    {
        private readonly OneWayLeftReflectRightMirror mirror = new OneWayLeftReflectRightMirror();
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
        public void GivenLaserIsMovingDownWhenAdvanceThenLaserMovesRight()
        {
            var previousLaserPosition = new Position(1, 2);
            var expectedLaserPosition = new Position(2, 1);

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
        public void GivenLaserIsMovingLeftWhenAdvanceThenLaserMovesUp()
        {
            var previousLaserPosition = new Position(2, 1);
            var expectedLaserPosition = new Position(1, 2);

            var actualNextLaserPosition = mirror.AdvanceLaser(roomPosition, previousLaserPosition);

            Assert.AreEqual(expectedLaserPosition, actualNextLaserPosition);
        }
    }
}