using System;
using System.Collections.Generic;
using Life.API;
using Life.API.Enums;
using Life.API.Helpers;
using Life.Console.Helpers;
namespace Life.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Cell[] cells = null;

            // Ask the user for initial state
            System.Console.WriteLine("\t\tWelcome to the Game of life.\n");
            
            PrintWelcomeAndInstructions();

            var gamePattern = GetValidPatternFromUser();
            //set to default generations
            byte maxGenerations = 10;
            Game game = null;
            switch (gamePattern)
            {
                case GamePattern.Block:
                    game = Helpers.Data.Block(maxGenerations);
                    break;
                case GamePattern.Boat:
                    game = Helpers.Data.Boat(maxGenerations);
                    break;
                case GamePattern.Blinker:
                    game = Helpers.Data.Blinker(maxGenerations);
                    break;
                case GamePattern.Toad:
                    game = Helpers.Data.Toad(maxGenerations);
                    break;
                case GamePattern.Custom:
                    PrintMaxGenerationsInputAndInstructions();
                    maxGenerations = GetMaxGenerations();
                    game = GetGridSize();
                    game.MaxGenerations = maxGenerations;
                    game = GetLiveCells(game);
                    break;
                default:
                    System.Console.WriteLine(
                        "\n\n\n\n\nInvalid input!\n\n");
                    break;
            }

            if (game != null) game.Init();
            System.Console.ReadKey();

        }

        private static Game GetLiveCells(Game game)
        {
            PrintCustomLiveCellCoordinatesInputAndInstructions();
            var input = System.Console.ReadLine();
            while (true)
            {
                try
                {
                    
                    var cells = new List<Cell>();

                    if (string.IsNullOrWhiteSpace(input))
                    {
                        throw new Exception(ExceptionHelper.InvalidInput);
                    }
                   
                    var cellsinstringformat = input.Split('|');
                    
                    if (cellsinstringformat.Length == 0)
                    {
                        throw new Exception(ExceptionHelper.InvalidInput);
                    }

                    foreach (var t in cellsinstringformat)
                    {
                        var cellCoordinates = t.Split(',');
                        if (cellCoordinates.Length != 2) throw new Exception(ExceptionHelper.InvalidInput);
                        game.ToggleGridCell(Int32.Parse(cellCoordinates[0]), Int32.Parse(cellCoordinates[1]));
                    }
                    break;
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine(
                        "\n\n\n\n\nInvalid input!\n");
                    System.Console.WriteLine("Specify the live cells in the following format.");
                    System.Console.WriteLine("<rownum>,<colnum> | <rownum>,<columnnum>\n");
                    System.Console.WriteLine("Example - 0,0| 2,2 - Means that the cells in the specific rownumber and the column number are alive.\n");
                    input = System.Console.ReadLine();
                }
            }

            return game;
        }

      
        private static Game GetGridSize()
        {
            PrintGridSizeInputAndInstructions();
            var input = System.Console.ReadLine();
            Game game;
            while (true)
            {
                try
                {
                    var gridSize = input.Split(',');
                    if (gridSize.Length != 2) throw new Exception();
                    var rows = Int32.Parse(gridSize[0]);
                    var cols = Int32.Parse(gridSize[1]); 
                    game = new Game(rows, cols);
                    break;
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine(
                        "\n\n\n\n\nInvalid input!\n");
                    System.Console.WriteLine("Please enter the initial values for a X by Y Grid of Cells in <rownum>,<colnum> format.\n");
                    System.Console.WriteLine("For example '2,4' or '3,3' are valid values");
                    input = System.Console.ReadLine();
                }
            }

            return game;
        }

        private static byte GetMaxGenerations()
        {
            string input = System.Console.ReadLine();
            byte maxGenerations;
            while (true)
            {
                try
                {
                    Byte.TryParse(input, out  maxGenerations);
                    if (maxGenerations == 0) throw new Exception();
                    break;
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine(
                        "\n\n\n\n\nInvalid input! enter generation value between 1 to 255.\n\n");
                    input = System.Console.ReadLine();
                }
            }

            return maxGenerations;
        }
        private static GamePattern ParsePattern(string input)
        {
            GamePattern pattern;

            try
            {
                Enum.TryParse(input, out pattern);
                if (!string.IsNullOrEmpty(Enum.GetName(pattern.GetType(), pattern)))
                    return pattern;

                throw new Exception(ExceptionHelper.InvalidInput);
            }
            catch (Exception)
            {
                throw new Exception();
            }

            return pattern;
        }
        private static GamePattern GetValidPatternFromUser()
        {
            var pattern = GamePattern.Custom;
            string userinput = System.Console.ReadLine();
            if (string.IsNullOrWhiteSpace(userinput))
            {
                //Allow user to enter his pattern
                return pattern;
            }
            while (true)
            {
                try
                {
                    pattern = ParsePattern(userinput);
                    break;
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine(
                        "\n\n\n\n\nInvalid input! Please read the instructions below and try again.\n\n");
                    PrintWelcomeAndInstructions();
                    userinput = System.Console.ReadLine();
                }
            }

            return pattern;
        }

        private static void PrintWelcomeAndInstructions()
        {
            System.Console.WriteLine("Please enter the pattern type value for Game.\n");
            System.Console.WriteLine(" 0: Custom (User Pattern)\n 1: Block\n 2: Boat pattern\n 3: Blinker pattern\n 4: Toad pattern.\n");
            System.Console.WriteLine("If you press enter without entering value (or enter 0) then it will ask for your pattern input.");
            System.Console.WriteLine("If values is valid and not 0 then it will generate predefined pattern.");
            System.Console.WriteLine("Default pattern evolves the cells 10 times.");
            System.Console.WriteLine("Press ENTER after entering the values. Waiting...");
        }

        private static void PrintMaxGenerationsInputAndInstructions()
        {
            System.Console.WriteLine("_______________________________________________________________________________.\n");
            System.Console.WriteLine("Enter generations number to evolves the cells valid value between 1 to 255.");
            System.Console.WriteLine("Press ENTER after entering the values. Waiting...");
        }

        private static void PrintGridSizeInputAndInstructions()
        {
            System.Console.WriteLine("_______________________________________________________________________________.\n");
            System.Console.WriteLine("Please enter the initial values for a X by Y Grid of Cells in <rownum>,<colnum> format.\n");
            System.Console.WriteLine("For example '2,4' or '3,3' are valid values");
            System.Console.WriteLine("Press ENTER after entering the values. Waiting...");
        }

        private static void PrintCustomLiveCellCoordinatesInputAndInstructions()
        {
            System.Console.WriteLine("_______________________________________________________________________________.\n");
            System.Console.WriteLine("You need to only specify the cells that are originally alive.\n");
            System.Console.WriteLine("Specify the live cells in the following format.");
            System.Console.WriteLine("<rownum>,<colnum> | <rownum>,<columnnum>\n");
            System.Console.WriteLine("Example - 0,0| 2,2 - Means that the cells in the specific rownumber and the column number are alive.\n");
            System.Console.WriteLine("Press ENTER after entering the values. Waiting...");
        }

        
    }
}
