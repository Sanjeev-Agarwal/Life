﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Life.API.Helpers;
using Life.API.Structs;

namespace Life.API
{
    public class Game
    {
        private readonly Grid _inputGrid;
        private readonly Grid _outputGrid;
        public Grid InputGrid { get { return _inputGrid; } }  // input grod
        public Grid OutputGrid { get { return _outputGrid; } } // output grid
        //There are two Task for the Game of Life 
        
        // 1. Task for changing all existing Cell Status        
        private Task _evaluateCellTask;
        
        // 2. Task for expanding output gird if respective rule satifies
        private Task _evaluateGridGrowthTask;

        // MaxGeneration is used to restrict generations of grid changes
        public byte MaxGenerations = 1; //set deafult as 1

        // Get number of rows in grid
        public int RowCount { get { return InputGrid.RowCount; } }
        
        // Get or Set number of columns in grid
        public int ColumnCount { get { return InputGrid.ColumnCount; } }


        /// <summary>
        /// Create input and output grids by using rows and column count and initialize reachable cells.
        /// Reachable Cells are cells which can be traversed from inner grid cells or outer grid cells i.e. virtual cells used for expanding grid
        /// </summary>
        /// <param name="rows"></param>
        /// <param name="columns"></param>
        public Game(int rows, int columns)
        {
            if (rows <= 0 || columns <= 0) throw new ArgumentOutOfRangeException(ExceptionHelper.ArgumentOutOfRangeExceptionForCell);
            _inputGrid = new Grid(rows, columns);
            _outputGrid = new Grid(rows, columns);
            RuleHelper.InitializeReachableCells();
        }

        /// <summary>
        /// Toggle state of input grid cells from live to dead or vice-verca
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void ToggleGridCell(int x, int y)
        {
            if (_inputGrid.RowCount <= x || _inputGrid.ColumnCount <= y) throw new ArgumentOutOfRangeException(ExceptionHelper.ArgumentOutOfBound);
            _inputGrid.ToggleCell(x, y);

        }

        /// <summary>
        /// Initialize the Game of lide
        /// </summary>
        public void Init()
        {
            Start();
        }
        /// <summary>
        /// Start Game of Life
        /// </summary>
        private void Start()
        {
            int currentGeneration = 0;
            GridHelper.Display(_inputGrid);
            do
            {
                currentGeneration++;
                // Process current generation for next generation
                ProcessGeneration();

                Console.WriteLine("Generation: " + currentGeneration);
                // Display the input grid
                GridHelper.Display(_inputGrid);
                // increment generation count                
            } while (currentGeneration < MaxGenerations);
        }
        /// <summary>
        /// Process current generation for next generation
        /// </summary>
        private void ProcessGeneration()
        {
            SetNextGeneration();
            Tick();
            FlipGridState();
        }

        /// <summary>
        /// Handles tasks for setting next generation
        /// </summary>
        private void SetNextGeneration()
        {
            // Generate next state of the Grid if last generate state process is completed
            if ((_evaluateCellTask == null) || (_evaluateCellTask != null && _evaluateCellTask.IsCompleted))
            {
                _evaluateCellTask = ChangeCellsState();
                
                // ensure that Output grid existing cells are updated. 
                //Otherwise it may result in unpredictable result in output grid if row or column is added in parallel
                _evaluateCellTask.Wait();
            }
            if ((_evaluateGridGrowthTask == null) || (_evaluateGridGrowthTask != null && _evaluateGridGrowthTask.IsCompleted))
            {
                _evaluateGridGrowthTask = ChangeGridState();
            }
        }
        /// <summary>
        /// Tick ensures that previous generation taks are completed
        /// </summary>
        private void Tick()
        {
            if (_evaluateGridGrowthTask != null)
            {
                _evaluateGridGrowthTask.Wait();
            }
        }

        /// <summary>
        /// Set output grid to input grid by Deep Copy output grid into input grid
        /// </summary>
        private void FlipGridState()
        {
            GridHelper.Copy(_outputGrid, _inputGrid);
            _outputGrid.ReInitialize();
        }

        /// <summary>
        /// Change state of all input cells into output cells Simultaneously using Parallel For
        /// </summary>
        /// <returns>returns EvaluateCellTask</returns>
        private Task ChangeCellsState()
        {
            return Task.Factory.StartNew(() =>
            Parallel.For(0, _inputGrid.RowCount, x =>
            {
                Parallel.For(0, _inputGrid.ColumnCount, y =>
                {
                    Rule.ChangeCellsState(_inputGrid, _outputGrid, new CellCoordinates(x, y));
                });
            }));
        }
        /// <summary>
        /// Change state of grid if required
        /// </summary>
        /// <returns>returns EvaluateGridGrowthTask</returns>
        private Task ChangeGridState()
        {
            return Task.Factory.StartNew(() => Rule.ChangeGridState(_inputGrid, _outputGrid));
        }
    }
}
