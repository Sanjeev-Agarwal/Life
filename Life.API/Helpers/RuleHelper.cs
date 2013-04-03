using System;
using System.Collections.Generic;
using Life.API.Enums;
using Life.API.Structs;

namespace Life.API.Helpers
{
    public static class RuleHelper
    {
        // Dictionary to hold list of reachable cells co-ordinates for specified cell type
        public static Dictionary<CellType, List<CellCoordinates>> ReachableCells;
        /// <summary>
        /// initialize all reachable cells in Dictionary(Key=> CellTypeEnum, Value => List of Reachable cell co-ordinates
        /// </summary>
        public static void InitializeReachableCells()
        {
            ReachableCells = new Dictionary<CellType, List<CellCoordinates>>();

            // Add Reachable adjacent cell co-ordinates for Top Left corner cell into Dictionary with TopLeftCorner CellTypeEnum as key
            var innerCell = CellType.TopLeftCorner;
            var topLeftCoOrdinateList = new List<CellCoordinates>
                {
                    new CellCoordinates(0, 1),
                    new CellCoordinates(1, 1),
                    new CellCoordinates(1, 0)
                };
            ReachableCells.Add(innerCell, topLeftCoOrdinateList);

            // Add Reachable adjacent cell co-ordinates for Top right corner cell into Dictionary with TopRightCorner CellTypeEnum as key
            innerCell = CellType.TopRightCorner;
            var topRightCoOrdinateList = new List<CellCoordinates>
                {
                    new CellCoordinates(1, 0),
                    new CellCoordinates(1, -1),
                    new CellCoordinates(0, -1)
                };
            ReachableCells.Add(innerCell, topRightCoOrdinateList);

            // Add Reachable adjacent cell co-ordinates for bottom left corner cell into Dictionary with BottomLeftCorner CellTypeEnum as key
            innerCell = CellType.BottomLeftCorner;
            var bottomLeftCoOrdinateList = new List<CellCoordinates>
                {
                    new CellCoordinates(-1, 0),
                    new CellCoordinates(-1, 1),
                    new CellCoordinates(0, 1)
                };
            ReachableCells.Add(innerCell, bottomLeftCoOrdinateList);

            // Add Reachable adjacent cell co-ordinates for bottom right corner cell into Dictionary with BottomRightCorner CellTypeEnum as key
            innerCell = CellType.BottomRightCorner;
            var bottomRightCoOrdinateList = new List<CellCoordinates>
                {
                    new CellCoordinates(0, -1),
                    new CellCoordinates(-1, -1),
                    new CellCoordinates(-1, 0)
                };
            ReachableCells.Add(innerCell, bottomRightCoOrdinateList);

            // Add Reachable adjacent cell co-ordinates for top side cell into Dictionary with BottomRightCorner TopSide as key
            innerCell = CellType.TopSide;
            var topSideCoOrdinateList = new List<CellCoordinates>
                {
                    new CellCoordinates(0, 1),
                    new CellCoordinates(1, 1),
                    new CellCoordinates(1, 0),
                    new CellCoordinates(1, -1),
                    new CellCoordinates(0, -1)
                };
            ReachableCells.Add(innerCell, topSideCoOrdinateList);

            // Add Reachable adjacent cell co-ordinates for bottom side cell into Dictionary with BottomRightCorner BottomSide as key
            innerCell = CellType.BottomSide;
            var bottomSideCoOrdinateList = new List<CellCoordinates>
                {
                    new CellCoordinates(0, -1),
                    new CellCoordinates(-1, -1),
                    new CellCoordinates(-1, 0),
                    new CellCoordinates(-1, 1),
                    new CellCoordinates(0, 1)
                };
            ReachableCells.Add(innerCell, bottomSideCoOrdinateList);

            // Add Reachable adjacent cell co-ordinates for left side cell into Dictionary with BottomRightCorner LeftSide as key
            innerCell = CellType.LeftSide;
            var leftSideCoOrdinateList = new List<CellCoordinates>
                {
                    new CellCoordinates(-1, 0),
                    new CellCoordinates(-1, 1),
                    new CellCoordinates(0, 1),
                    new CellCoordinates(1, 1),
                    new CellCoordinates(1, 0)
                };
            ReachableCells.Add(innerCell, leftSideCoOrdinateList);

            // Add Reachable adjacent cell co-ordinates for right side cell into Dictionary with BottomRightCorner RightSide as key
            innerCell = CellType.RightSide;
            var rightSideCoOrdinateList = new List<CellCoordinates>
                {
                    new CellCoordinates(1, 0),
                    new CellCoordinates(1, -1),
                    new CellCoordinates(0, -1),
                    new CellCoordinates(-1, -1),
                    new CellCoordinates(-1, 0)
                };
            ReachableCells.Add(innerCell, rightSideCoOrdinateList);

            // Add Reachable adjacent cell co-ordinates for Center cell into Dictionary with BottomRightCorner Center as key
            innerCell = CellType.Center;
            var centerCoOrdinateList = new List<CellCoordinates>
                {
                    new CellCoordinates(-1, 0),
                    new CellCoordinates(-1, 1),
                    new CellCoordinates(0, 1),
                    new CellCoordinates(1, 1),
                    new CellCoordinates(1, 0),
                    new CellCoordinates(1, -1),
                    new CellCoordinates(0, -1),
                    new CellCoordinates(-1, -1)
                };
            ReachableCells.Add(innerCell, centerCoOrdinateList);

            // Add Reachable adjacent cell co-ordinates for outer top side cell into Dictionary with BottomRightCorner OuterTopSide as key
            innerCell = CellType.OuterTopSide;
            var outerTopSideCoOrdinateList = new List<CellCoordinates>
                {
                    new CellCoordinates(1, -1),
                    new CellCoordinates(1, 0),
                    new CellCoordinates(1, 1)
                };
            ReachableCells.Add(innerCell, outerTopSideCoOrdinateList);

            // Add Reachable adjacent cell co-ordinates for outer right side cell into Dictionary with BottomRightCorner OuterRightSide as key
            innerCell = CellType.OuterRightSide;
            var outerRightSideCoOrdinateList = new List<CellCoordinates>
                {
                    new CellCoordinates(-1, -1),
                    new CellCoordinates(0, -1),
                    new CellCoordinates(1, -1)
                };
            ReachableCells.Add(innerCell, outerRightSideCoOrdinateList);

            // Add Reachable adjacent cell co-ordinates for outer bottom side cell into Dictionary with BottomRightCorner OuterBottomSide as key
            innerCell = CellType.OuterBottomSide;
            var outerBottomSideCoOrdinateList = new List<CellCoordinates>
                {
                    new CellCoordinates(-1, -1),
                    new CellCoordinates(-1, 0),
                    new CellCoordinates(-1, 1)
                };
            ReachableCells.Add(innerCell, outerBottomSideCoOrdinateList);

            // Add Reachable adjacent cell co-ordinates for outer left side cell into Dictionary with BottomRightCorner OuterLeftSide as key
            innerCell = CellType.OuterLeftSide;
            var outerLeftSideCoOrdinateList = new List<CellCoordinates>
                {
                    new CellCoordinates(-1, 1),
                    new CellCoordinates(0, 1),
                    new CellCoordinates(1, 1)
                };
            ReachableCells.Add(innerCell, outerLeftSideCoOrdinateList);

        }

        /// <summary>
        /// Get the co-ordinates with respectt to grid and return the Cell type enum
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="coOrdinates"></param>
        /// <returns>returns CellTypeEnum</returns>
        public static CellType GetCellType(Grid grid, CellCoordinates coOrdinates)
        {
            if ((coOrdinates.X < -1 || coOrdinates.X > grid.RowCount) || (coOrdinates.Y < -1 || coOrdinates.Y > grid.ColumnCount))
            {
                throw new ArgumentOutOfRangeException(ExceptionHelper.ArgumentNullExceptionForUnreachableCoordinates);
            }
            var enumCellType = CellType.None;
            if (coOrdinates.X == 0 && coOrdinates.Y == 0)
                enumCellType = CellType.TopLeftCorner;
            else if (coOrdinates.X == 0 && coOrdinates.Y == grid.ColumnCount - 1)
                enumCellType = CellType.TopRightCorner;
            else if (coOrdinates.X == grid.RowCount - 1 && coOrdinates.Y == 0)
                enumCellType = CellType.BottomLeftCorner;
            else if (coOrdinates.X == grid.RowCount - 1 && coOrdinates.Y == grid.ColumnCount - 1)
                enumCellType = CellType.BottomRightCorner;
            else if (coOrdinates.X == 0 && (coOrdinates.Y > 0 && coOrdinates.Y < grid.ColumnCount - 1))
                enumCellType = CellType.TopSide;
            else if (coOrdinates.X == grid.RowCount - 1 && (coOrdinates.Y > 0 && coOrdinates.Y < grid.ColumnCount - 1))
                enumCellType = CellType.BottomSide;
            else if ((coOrdinates.X > 0 && coOrdinates.X < grid.RowCount - 1) && coOrdinates.Y == 0)
                enumCellType = CellType.LeftSide;
            else if ((coOrdinates.X > 0 && coOrdinates.X < grid.RowCount - 1) && coOrdinates.Y == grid.ColumnCount - 1)
                enumCellType = CellType.RightSide;
            else if ((coOrdinates.X > 0 && coOrdinates.X < grid.RowCount - 1) && (coOrdinates.Y > 0 && coOrdinates.Y < grid.ColumnCount - 1))
                enumCellType = CellType.Center;
            else if (coOrdinates.X == -1 && (coOrdinates.Y > 0 && coOrdinates.Y < grid.ColumnCount - 1))
                enumCellType = CellType.OuterTopSide;
            else if ((coOrdinates.X > 0 && coOrdinates.X < grid.RowCount - 1) && coOrdinates.Y == grid.ColumnCount)
                enumCellType = CellType.OuterRightSide;
            else if (coOrdinates.X == grid.RowCount && (coOrdinates.Y > 0 && coOrdinates.Y < grid.ColumnCount - 1))
                enumCellType = CellType.OuterBottomSide;
            else if ((coOrdinates.X > 0 && coOrdinates.X < grid.RowCount - 1) && coOrdinates.Y == -1)
                enumCellType = CellType.OuterLeftSide;
            return enumCellType;
        }

    }
}
