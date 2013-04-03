using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Life.API.Helpers;

namespace Life.API
{
    public class Row
    {
        
        //list of cells
        public List<Cell> Cells { get; set; }

        /// <summary>
        /// indexer to get cell using index
        /// </summary>
        /// <param name="y"></param>
        /// <returns>returns cell</returns>
        public Cell this[int y]
        {
            get { if (Cells.Count >= y) throw new ArgumentOutOfRangeException(ExceptionHelper.ArgumentOutOfBound); return Cells[y]; }
            set { if (Cells.Count >= y) throw new ArgumentOutOfRangeException(ExceptionHelper.ArgumentOutOfBound); Cells[y] = value; }
        }
        /// <summary>
        /// initialize list of cells
        /// </summary>
        public Row()
        {
            Cells = new List<Cell>();
        }
        /// <summary    >
        /// Add a cell into the row
        /// </summary>
        /// <param name="cell"></param>
        public void AddCell(Cell cell)
        {
            Cells.Add(cell);
        }
        /// <summary>
        /// Insert a cell into specified index position
        /// </summary>
        /// <param name="index"></param>
        /// <param name="cell"></param>
        /// <param name="columnCount"></param>
        public void InsertCell(int index, Cell cell, int columnCount)
        {
            if (index < 0 || index >= columnCount) throw new ArgumentOutOfRangeException(ExceptionHelper.ArgumentNullExceptionForUnreachableCoordinates);
            Cells.Insert(index, cell);
        }

    }
}
