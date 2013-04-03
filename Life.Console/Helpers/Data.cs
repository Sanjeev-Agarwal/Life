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
            var objLifeGame = new Game(2, 4);
            objLifeGame.ToggleGridCell(0, 1);
            objLifeGame.ToggleGridCell(0, 2);
            objLifeGame.ToggleGridCell(0, 3);
            objLifeGame.ToggleGridCell(1, 0);
            objLifeGame.ToggleGridCell(1, 1);
            objLifeGame.ToggleGridCell(1, 2);
            objLifeGame.MaxGenerations = maxGenerations;
            return objLifeGame;
        }
        public static Game Boat(byte maxGenerations)
        {
            var objLifeGame = new Game(3, 3);
            objLifeGame.ToggleGridCell(0, 0);
            objLifeGame.ToggleGridCell(0, 1);
            objLifeGame.ToggleGridCell(1, 0);
            objLifeGame.ToggleGridCell(1, 2);
            objLifeGame.ToggleGridCell(2, 1);
            objLifeGame.MaxGenerations = maxGenerations;
            return objLifeGame;
        }
        public static Game Blinker(byte maxGenerations)
        {
            var objLifeGame = new Game(3, 3);
            objLifeGame.ToggleGridCell(0, 1);
            objLifeGame.ToggleGridCell(1, 1);
            objLifeGame.ToggleGridCell(2, 1);
            objLifeGame.MaxGenerations = maxGenerations;
            return objLifeGame;
        }    
    }
}
