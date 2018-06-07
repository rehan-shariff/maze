namespace Maze
{
    public interface IMirrorFactory
    {
        IMirror CreateMirror(string mirrorType = "");
    }
}