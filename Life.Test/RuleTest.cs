using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Life.API;
using Life.API.Enums;
using Life.API.Structs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Life.API.Helpers;
namespace Life.Test
{
    [TestClass]
    public class RuleTest
    {
        [TestMethod]
        public void CellLocationPostiveTest()
        {
            //Arrange
            const int rows = 2;
            const int columns = 2;

            //Act
            var target = new Grid(rows, columns);
            var cellTopLeft = RuleHelper.GetCellType(target, new CellCoordinates(0, 0));
            var cellTopRight = RuleHelper.GetCellType(target, new CellCoordinates(0, 1));
            var cellBottomLeft = RuleHelper.GetCellType(target, new CellCoordinates(1, 0));
            var cellBottomRight = RuleHelper.GetCellType(target, new CellCoordinates(1, 1));
           
            //Assert
            Assert.AreEqual(cellTopLeft, CellType.TopLeftCorner);
            Assert.AreEqual(cellTopRight, CellType.TopRightCorner);
            Assert.AreEqual(cellBottomLeft, CellType.BottomLeftCorner);
            Assert.AreEqual(cellBottomRight, CellType.BottomRightCorner);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), ExceptionHelper.ArgumentNullExceptionForUnreachableCoordinates)]
        public void CellLocationExceptionTest()
        {
            //Arrange
            const int rows = 2;
            const int columns = 2;

            //Act
            var target = new Grid(rows, columns);
            var cellTopLeft = RuleHelper.GetCellType(target, new CellCoordinates(-2, 0));
        }
    }
}
