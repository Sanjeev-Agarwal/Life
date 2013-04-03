using System;
using System.Collections.Generic;
using System.Linq;
using Life.API.Enums;
using Life.API.Helpers;
using Life.API.Structs;

namespace Life.API
{
    public static class Rule
    {
        
        /// <summary>
        /// Change Cell state of specified co-ordinate using Ruls
        /// </summary>
        /// <param name="inputGrid"></param>
        /// <param name="outputGrid"></param>
        /// <param name="cellCoordinates"></param>
        public static void ChangeCellsState(Grid inputGrid, Grid outputGrid, CellCoordinates cellCoordinates)
        {
            var liveNeighbourCount = CountAliveNeighbours(inputGrid, cellCoordinates);
            lock (outputGrid)
            {
                if (HasAliveInNextState(inputGrid[cellCoordinates.X, cellCoordinates.Y], liveNeighbourCount))
                {
                    //set output grid's cell to live only if it is in alive status in next generation
                    outputGrid[cellCoordinates.X, cellCoordinates.Y].IsAlive = true;
                }

            }

        }

        /// <summary>
        /// Count live adjacent cells for specified cell co-ordinates
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="cellCoordinates"></param>
        /// <returns>returns number of live neighbours</returns>
        private static int CountAliveNeighbours(Grid grid, CellCoordinates cellCoordinates)
        {
            // Get the Cell type of current cell
            CellType enumInnerCell = RuleHelper.GetCellType(grid, cellCoordinates);

            List<CellCoordinates> reachableCells;
            
            // populate reachable cells from current cell for easier traversing
            RuleHelper.ReachableCells.TryGetValue(enumInnerCell, out reachableCells);
            
            if (reachableCells != null && reachableCells.Count == 0) throw new ArgumentNullException(ExceptionHelper.ArgumentNullExceptionForUnreachableCoordinates);
            return reachableCells.Sum(coOrds => HasAliveNeighbour(grid, cellCoordinates, coOrds));
        }


        /// <summary>
        /// Check if the adjacent cell is alive or not
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="baseCoordinates"></param>
        /// <param name="offSetCoordinates"></param>
        /// <returns>returns 1 if live otherwise 0</returns>
        private static int HasAliveNeighbour(Grid grid, CellCoordinates baseCoordinates, CellCoordinates offSetCoordinates)
        {
            var live = 0; // set default as 0
            var x = baseCoordinates.X + offSetCoordinates.X; // get x axis of neighbour
            var y = baseCoordinates.Y + offSetCoordinates.Y; // get y axis of neighbour
            
            // check the computed bound is within range of grid, if it is not within bounds live is 0 as default
            if ((x >= 0 && x < grid.RowCount) && y >= 0 && y < grid.ColumnCount)
            {
                // if reachable neighbour cell is alive then set live to 1 otherwise 0
                live = grid[x, y].IsAlive ? 1 : 0;
            }

            return live;
        }

        /// <summary>
        /// Evaluate Cell state in next generation
        /// </summary>
        /// <param name="cell"></param>
        /// <param name="liveNeighbourCount"></param>
        /// <returns>returns true if alive otherwise false</returns>
        private static Boolean HasAliveInNextState(Cell cell, int liveNeighbourCount)
        {
            var alive = false;
            if (cell.IsAlive)
            {
                if (liveNeighbourCount == 2 || liveNeighbourCount == 3) // if cell is alive and 2 or 3 ajacent cells are alive then set it to alive in next generation
                {
                    alive = true;
                }
            }
            else if (liveNeighbourCount == 3) // if cell is dead and 3 adjacent cells are alive then set it to alive in next generation
            {
                alive = true;
            }
            return alive;
        }

        /// <summary>
        /// Change state of grid if required to grow on any side
        /// </summary>
        /// <param name="inputGrid"></param>
        /// <param name="outputGrid"></param>
        public static void ChangeGridState(Grid inputGrid, Grid outputGrid)
        {
            CheckRowGrowth(inputGrid, outputGrid, -1);
            CheckRowGrowth(inputGrid, outputGrid, inputGrid.RowCount);
            CheckColumnGrowth(inputGrid, outputGrid, -1);
            CheckColumnGrowth(inputGrid, outputGrid, inputGrid.ColumnCount);
        }

        /// <summary>
        /// Check if rule satisfies to expand column 
        /// </summary>
        /// <param name="inputGrid"></param>
        /// <param name="outputGrid"></param>
        /// <param name="colId"></param>
        private static void CheckColumnGrowth(Grid inputGrid, Grid outputGrid, int colId)
        {
            //Create a whole new column in the beginning or end if rule is satified for any of the cell
            var columnCreatedFlag = false;

            // start with the index 1  until 1 less than last index as index 0 and last index cannot have 3 live adjacent cell in any case
            // This index 0 and last index must be included if rule is changed in future; dead can alive with 2 live adjacent cells
            for (var i = 1; i < inputGrid.RowCount - 1; i++)
            {
                if (CountAliveNeighbours(inputGrid, new CellCoordinates(i, colId)) == 3)
                {
                    if (columnCreatedFlag == false)
                    {
                        for (var k = 0; k < outputGrid.RowCount; k++)
                        {
                            var newDeadCell = new Cell(false);  // Fill all cells with false
                            if (colId == -1)
                            {
                                outputGrid[k].InsertCell(0, newDeadCell, outputGrid.ColumnCount);
                            }
                            else
                            {
                                outputGrid[k].AddCell(newDeadCell);
                            }
                        }
                        // increment column count to 1
                        outputGrid.ColumnCount += 1;
                        columnCreatedFlag = true;
                    }
                    var yAxis = (colId == -1) ? 0 : outputGrid.ColumnCount - 1;
                    outputGrid[i, yAxis].IsAlive = true;
                }
            }
        }

        /// <summary>
        /// Check if rule satisfies to expand row
        /// </summary>
        /// <param name="inputGrid"></param>
        /// <param name="outputGrid"></param>
        /// <param name="rowId"></param>
        private static void CheckRowGrowth(Grid inputGrid, Grid outputGrid, int rowId)
        {
            //Create a whole new row in the beginning or end if rule is satified for any of the cell
            var rowCreatedFlag = false;
            
            // start with the index 1  until 1 less than last index as index 0 and last index cannot have 3 live adjacent cell in any case
            // This index 0 and last index must be included if rule is changed in future; dead can alive with 2 live adjacent cells
            for (var j = 1; j < inputGrid.ColumnCount - 1; j++)
            {
                if (CountAliveNeighbours(inputGrid, new CellCoordinates(rowId, j)) == 3)
                {
                    if (rowCreatedFlag == false)
                    {
                        var newRow = new Row();
                        for (var k = 0; k < outputGrid.ColumnCount; k++)
                        {
                            // Fill all cells with false
                            var newDeadCell = new Cell(false);
                            newRow.AddCell(newDeadCell);
                        }
                        if (rowId == -1)
                        {
                            outputGrid.InsertRow(0, newRow);
                        }
                        else
                        {
                            outputGrid.AddRow(newRow);
                        }
                        rowCreatedFlag = true;
                    }
                    var xAxis = (rowId == -1) ? 0 : outputGrid.RowCount - 1;
                    outputGrid[xAxis, j].IsAlive = true;
                }
            }
        }

    }

}
