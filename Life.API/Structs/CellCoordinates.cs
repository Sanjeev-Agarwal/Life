
namespace Life.API.Structs
{
    /// <summary>
    /// structure to hold x and y indices of grid cell
    /// </summary>
    public struct CellCoordinates
    {
        public int X;
        public int Y;
        public CellCoordinates(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
