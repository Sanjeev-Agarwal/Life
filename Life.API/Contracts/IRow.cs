namespace Life.API.Contracts
{
    public interface IRow
    {
        /// <summary    >
        /// Add a cell into the row
        /// </summary>
        /// <param name="cell"></param>
        void AddCell(Cell cell);

        /// <summary>
        /// Insert a cell into specified index position
        /// </summary>
        /// <param name="index"></param>
        /// <param name="cell"></param>
        /// <param name="columnCount"></param>
        void InsertCell(int index, Cell cell, int columnCount);
    }
}