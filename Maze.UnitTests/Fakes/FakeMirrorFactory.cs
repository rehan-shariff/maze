using Maze;

namespace Maze.UnitTests
{
    public class FakeMirrorFactory : IMirrorFactory
    {
        public int MirrorCount { get; private set; } = 0;
        public int TwoWayLeftMirrorCount { get; private set; } = 0;
        public int TwoWayRightMirrorCount { get; private set; } = 0;
        public int OneWayLeftReflectLeftMirrorCount { get; private set; } = 0;
        public int OneWayLeftReflectRightMirrorCount { get; private set; } = 0;
        public int OneWayRightReflectLeftMirrorCount { get; private set; } = 0;
        public int OneWayRightReflectRightMirrorCount { get; private set; } = 0;

        public IMirror CreateMirror(string mirrorType)
        {
            UpdateMirrorCounts(mirrorType);
            return new NullMirror();
        }

        private void UpdateMirrorCounts(string mirrorType)
        {
            switch (mirrorType)
            {
                case "L":
                    TwoWayLeftMirrorCount += 1;
                    break;
                case "R":
                    TwoWayRightMirrorCount += 1;
                    break;
                case "RR":
                    OneWayRightReflectRightMirrorCount += 1;
                    break;
                case "LL":
                    OneWayLeftReflectLeftMirrorCount += 1;
                    break;
                case "RL":
                    OneWayRightReflectLeftMirrorCount += 1;
                    break;
                case "LR":
                    OneWayLeftReflectRightMirrorCount += 1;
                    break;
            }

            MirrorCount += 1;
        }
    }
}