namespace Life.API.Contracts
{
    public interface IGrid
    {
        /// <summary>
        /// Toggle state of input grid cells from its current state; live to dead or vice-verca
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>        
        void ToggleCell(int x, int y);

        /// <summary>
        /// Inserts a new row in the grid at specified index
        /// </summary>
        /// <param name="index"></param>
        /// <param name="row"></param>
        void InsertRow(int index, Row row);

        /// <summary>
        /// Add a new row in grid at the end in row list
        /// </summary>
        /// <param name="row"></param>
        void AddRow(Row row);
    }
}