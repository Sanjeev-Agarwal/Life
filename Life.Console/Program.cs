using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Life.API;
using Life.API.Enums;

namespace Life.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            //TODO: Get type from user
            const GamePattern gamePattern = GamePattern.Boat;
            //TODO: Get generation from user
            const byte maxGenerations = 5;
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
                case GamePattern.Custom:
                //TODO: Ask input from user, if wrong throw exception 
                 break;
                case GamePattern.Toad:
                 game = Helpers.Data.Toad(maxGenerations);
                 break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            if (game != null) game.Init();
            System.Console.ReadKey();
        }
    }
}
