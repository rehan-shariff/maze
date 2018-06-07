namespace Maze
{
    public class MirrorFactory : IMirrorFactory
    {
        public IMirror CreateMirror(string mirrorOrientation = "")
        {
            switch(mirrorOrientation)
            {
                case "L":
                    return new TwoWayLeftMirror();
                case "R":
                    return new TwoWayRightMirror();
                case "RR":
                    return new OneWayRightReflectRightMirror();
                case "LL":
                    return new OneWayLeftReflectLeftMirror();
                case "RL":
                    return new OneWayRightReflectLeftMirror();
                case "LR":
                    return new OneWayLeftReflectRightMirror();
                default:
                    return new NullMirror();
            }
        }
    }
}