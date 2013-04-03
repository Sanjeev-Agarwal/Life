using System;
using Life.API;
using Life.API.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Life.Test
{
    [TestClass]
    public class GameTest
    {
        #region "Postive tests"

        /// <summary>
        ///     A test for Game Constructor
        /// </summary>
        [TestMethod]
        public void GameConstructorPositiveTest()
        {
            //Arrange
            const int rows = 2;
            const int columns = 2;

            //Act
            var target = new Game(rows, columns);

            //Assert
            Assert.AreEqual(target.RowCount, 2);
            Assert.AreEqual(target.ColumnCount, 2);
        }


        /// <summary>
        ///     A test for ToggleGridCell
        /// </summary>
        [TestMethod]
        public void ToggleGridCellPositiveTest()
        {
            //Arrange
            const int rows = 2;
            const int columns = 3;
            const int x = 1;
            const int y = 2;

          
            //Act
            var target = new Game(rows, columns);
            target.ToggleGridCell(x, y);

            //Assert
            Assert.AreEqual(target.InputGrid[1, 2].IsAlive, true);
        }


        /// <summary>
        ///     A test for validating MaxGeneration value
        /// </summary>
        [TestMethod]
        public void MaxGenerationTest()
        {
            //Arrange
            const int rows = 2;
            const int columns = 2;

            //Act
            var target = new Game(rows, columns) {MaxGenerations = 2};

            //Assert
            Assert.AreEqual(target.MaxGenerations, 2);
        }

        /// <summary>
        ///     A default test for Init
        /// </summary>
        [TestMethod]
        public void InitDefaultValueTest()
        {
            //Arrange
            const int rows = 2;
            const int columns = 2;

            //Act
            var target = new Game(rows, columns);
            target.Init();

            //Assert
            Assert.AreEqual(target.InputGrid[0, 0].IsAlive, false);
            Assert.AreEqual(target.InputGrid[0, 1].IsAlive, false);
            Assert.AreEqual(target.InputGrid[1, 0].IsAlive, false);
            Assert.AreEqual(target.InputGrid[1, 1].IsAlive, false);
        }

        #endregion

        #region "Negative Tests"

        /// <summary>
        ///     A test for Game Constructor
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof (ArgumentOutOfRangeException), ExceptionHelper.ArgumentOutOfRangeExceptionForCell)]
        public void GameConstructorExceptionTest1()
        {
            const int rows = -1;
            const int columns = 0;
            var target = new Game(rows, columns);
        }

        /// <summary>
        ///     A test for Game Constructor
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof (ArgumentOutOfRangeException), ExceptionHelper.ArgumentOutOfRangeExceptionForCell)]
        public void GameConstructorExceptionTest2()
        {
            const int rows = 0;
            const int columns = -1;
            var target = new Game(rows, columns);
        }

        /// <summary>
        ///     A test for Game Constructor
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof (ArgumentOutOfRangeException), ExceptionHelper.ArgumentOutOfRangeExceptionForCell)]
        public void GameConstructorExceptionTest3()
        {
            const int rows = 0;
            const int columns = 0;
            var target = new Game(rows, columns);
        }

        /// <summary>
        ///     A test for ToggleGridCell
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof (ArgumentOutOfRangeException), ExceptionHelper.ArgumentOutOfBound)]
        public void ToggleGridCellExceptionTest1()
        {
            const int rows = 1;
            const int columns = 0;
            const int x = 0;
            const int y = 0;
          
            var target = new Game(rows, columns);
            target.ToggleGridCell(x, y);
        }

        /// <summary>
        ///     A test for ToggleGridCell
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof (ArgumentOutOfRangeException), ExceptionHelper.ArgumentOutOfBound)]
        public void ToggleGridCellExcecptinoTest2()
        {
            const int rows = 0;
            const int columns = 1;
            var target = new Game(rows, columns);
            const int x = 1;
            const int y = 1;
            target.ToggleGridCell(x, y);
        }

        /// <summary>
        ///     A test for ToggleGridCell
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof (ArgumentOutOfRangeException), ExceptionHelper.ArgumentOutOfBound)]
        public void ToggleGridCellExceptionTest2()
        {
            const int rows = 2;
            const int columns = 3;
            const int x = 3;
            const int y = 3;
            
            var target = new Game(rows, columns);
            target.ToggleGridCell(x, y);
        }

        #endregion

        #region "Pattern Tests"

        /// <summary>
        ///     A Block pattern test for Init
        /// </summary>
        [TestMethod]
        public void InitBlockPatternTest()
        {
            //Arrange
            const int rows = 2;
            const int columns = 2;

            //Act
            var target = new Game(rows, columns);
            target.ToggleGridCell(0, 0);
            target.ToggleGridCell(0, 1);
            target.ToggleGridCell(1, 0);
            target.ToggleGridCell(1, 1);
            target.MaxGenerations = 99;
            // This pattern remains unchanged for infinite generation, testing it for 99 generations
            target.Init();

            //Assert
            Assert.AreEqual(target.InputGrid[0, 0].IsAlive, true);
            Assert.AreEqual(target.InputGrid[0, 1].IsAlive, true);
            Assert.AreEqual(target.InputGrid[1, 0].IsAlive, true);
            Assert.AreEqual(target.InputGrid[1, 1].IsAlive, true);
        }

        /// <summary>
        ///     A boat pattern test for Init
        /// </summary>
        [TestMethod]
        public void InitBoatPatternTest()
        {
            //Arrange
            const int rows = 3;
            const int columns = 3;
           
            //Act
            var target = new Game(rows, columns);
            target.ToggleGridCell(0, 0);
            target.ToggleGridCell(0, 1);
            target.ToggleGridCell(1, 0);
            target.ToggleGridCell(1, 2);
            target.ToggleGridCell(2, 1);
            target.Init();

            //Assert
            Assert.AreEqual(target.InputGrid[0, 0].IsAlive, true);
            Assert.AreEqual(target.InputGrid[0, 1].IsAlive, true);
            Assert.AreEqual(target.InputGrid[1, 0].IsAlive, true);
            Assert.AreEqual(target.InputGrid[1, 2].IsAlive, true);
            Assert.AreEqual(target.InputGrid[1, 2].IsAlive, true);
            Assert.AreEqual(target.InputGrid[2, 1].IsAlive, true);
        }

        /// <summary>
        ///     A Blinker test for Init
        /// </summary>
        [TestMethod]
        public void InitBlinkerPatternTest()
        {
            //Arrange
            const int rows = 3;
            const int columns = 3;

            //Act
            var target = new Game(rows, columns);
            target.ToggleGridCell(0, 1);
            target.ToggleGridCell(1, 1);
            target.ToggleGridCell(2, 1);
            target.Init();

            //Assert
            Assert.AreEqual(target.InputGrid[1, 0].IsAlive, true);
            Assert.AreEqual(target.InputGrid[1, 1].IsAlive, true);
            Assert.AreEqual(target.InputGrid[1, 2].IsAlive, true);
        }


        /// <summary>
        ///     A Toad pattern 1 test for Init
        /// </summary>
        [TestMethod]
        public void InitToadPattern1Test()
        {
            //Arrange
            const int rows = 2;
            const int columns = 4;

            //Act
            var target = new Game(rows, columns);
            target.ToggleGridCell(0, 1);
            target.ToggleGridCell(0, 2);
            target.ToggleGridCell(0, 3);
            target.ToggleGridCell(1, 0);
            target.ToggleGridCell(1, 1);
            target.ToggleGridCell(1, 2);
            target.Init();

            //Assert
            Assert.AreEqual(target.InputGrid[0, 2].IsAlive, true);
            Assert.AreEqual(target.InputGrid[1, 0].IsAlive, true);
            Assert.AreEqual(target.InputGrid[1, 3].IsAlive, true);
            Assert.AreEqual(target.InputGrid[2, 0].IsAlive, true);
            Assert.AreEqual(target.InputGrid[2, 3].IsAlive, true);
            Assert.AreEqual(target.InputGrid[3, 1].IsAlive, true);
        }

        /// <summary>
        ///     A Toad pattern 2 test for Init
        /// </summary>
        [TestMethod]
        public void InitToadPattern2Test()
        {
            //Arrange
            const int rows = 4;
            const int columns = 2;
            var target = new Game(rows, columns);

            //Act
            target.ToggleGridCell(0, 0);
            target.ToggleGridCell(1, 0);
            target.ToggleGridCell(1, 1);
            target.ToggleGridCell(2, 0);
            target.ToggleGridCell(2, 1);
            target.ToggleGridCell(3, 1);
            target.Init();

            //Assert
            Assert.AreEqual(target.InputGrid[0, 1].IsAlive, true);
            Assert.AreEqual(target.InputGrid[0, 2].IsAlive, true);
            Assert.AreEqual(target.InputGrid[1, 0].IsAlive, true);
            Assert.AreEqual(target.InputGrid[2, 3].IsAlive, true);
            Assert.AreEqual(target.InputGrid[3, 1].IsAlive, true);
            Assert.AreEqual(target.InputGrid[3, 2].IsAlive, true);
        }

        #endregion
    }
}