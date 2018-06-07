namespace Maze
{
    public static class LaserFactory
    {
        public static ILaser CreateLaser(string laserOrientation)
        {
            switch(laserOrientation)
            {
                case "H":
                    return new HorizontalLaser();
                case "V":
                    return new VerticalLaser();
            }

            return new NullLaser();
        }
    }
}