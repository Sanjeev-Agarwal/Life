using System;

namespace Life.API
{
    public class Cell
    {
        public Cell(Boolean isAlive)
        {
            IsAlive = isAlive;
        }

        public Boolean IsAlive { get; set; }

        /// <summary>
        ///     ToString implementation of cell
        /// </summary>
        /// <returns>retuns string representation of cell</returns>
        public override string ToString()
        {
            return (IsAlive ? " A " : " - ");
        }
    }
}