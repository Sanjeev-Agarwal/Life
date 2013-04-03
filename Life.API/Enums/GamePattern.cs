
namespace Life.API.Enums
{
    /// <summary>
    /// Cell types are unique types of cell in grid of any size
    /// Every cell type has distinct reachable djacent cells which can be traversed
    /// </summary>
    public enum GamePattern
    {
        Custom,
        Block,
        Boat,
        Blinker,
        Toad
    }
}
