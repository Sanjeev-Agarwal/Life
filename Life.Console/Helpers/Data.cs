using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Life.API;

namespace Life.Console.Helpers
{
    static class Data
    {
        public static Game Block(byte maxGenerations)
        {
            // Simple Pattern
            var objLifeGame = new Game(4, 4);
            objLifeGame.ToggleGridCell(1, 1);
            objLifeGame.ToggleGridCell(1, 2);
            objLifeGame.ToggleGridCell(2, 1);
            objLifeGame.ToggleGridCell(2, 2);
            objLifeGame.ToggleGridCell(2, 3);
            objLifeGame.ToggleGridCell(3, 3);
            objLifeGame.MaxGenerations = maxGenerations;
            return objLifeGame;
        }
        public static Game Toad(byte maxGenerations)
        {
            // Simple Pattern
            var objLifeGame = new Game(4, 4);
            objLifeGame.ToggleGridCell(1, 1);
            objLifeGame.ToggleGridCell(1, 2);
            objLifeGame.ToggleGridCell(2, 1);
            objLifeGame.ToggleGridCell(2, 2);
            objLifeGame.ToggleGridCell(2, 3);
            objLifeGame.ToggleGridCell(3, 3);
            objLifeGame.MaxGenerations = maxGenerations;
            return objLifeGame;
        }
        public static Game Boat(byte maxGenerations)
        {
            // Simple Pattern
            var objLifeGame = new Game(4, 4);
            objLifeGame.ToggleGridCell(1, 1);
            objLifeGame.ToggleGridCell(1, 2);
            objLifeGame.ToggleGridCell(2, 1);
            objLifeGame.ToggleGridCell(2, 2);
            objLifeGame.ToggleGridCell(2, 3);
            objLifeGame.ToggleGridCell(3, 3);
            objLifeGame.MaxGenerations = maxGenerations;
            return objLifeGame;
        }
        public static Game Blinker(byte maxGenerations)
        {
            // Simple Pattern
            var objLifeGame = new Game(4, 4);
            objLifeGame.ToggleGridCell(1, 1);
            objLifeGame.ToggleGridCell(1, 2);
            objLifeGame.ToggleGridCell(2, 1);
            objLifeGame.ToggleGridCell(2, 2);
            objLifeGame.ToggleGridCell(2, 3);
            objLifeGame.ToggleGridCell(3, 3);
            objLifeGame.MaxGenerations = maxGenerations;
            return objLifeGame;
        }    
    }
}
