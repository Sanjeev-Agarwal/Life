using Life.API;
using Life.API.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
namespace Life.Test
{
    [TestClass]
    public class GridTest
    {
        #region "Postive tests"
        /// <summary>
        ///A test for Game Constructor
        ///</summary>
        [TestMethod()]
        public void GridConstructorPositiveTest()
        {
            //Arrange
            const int rows = 2;
            const int columns = 2;

            //Act
            var target = new Grid(rows, columns);

            //Assert
            Assert.AreEqual(target.RowCount, 2);
            Assert.AreEqual(target.ColumnCount, 2);
        }
        #endregion

        #region "Negative tests"
        /// <summary>
        ///A test for Game Constructor
        ///</summary>
        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException), ExceptionHelper.ArgumentOutOfRangeExceptionForCell)]
        public void GridConstructorExceptionTest1()
        {
            const int rows = -1;
            const int columns = 0;
            var target = new Grid(rows, columns);

        }
        #endregion


    }
}