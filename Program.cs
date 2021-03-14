using System;
using System.Collections.Generic;

namespace Nim
{
    public class Program
    {
        //The random number generator that is used throughout the entire program.
        public static Random rand = new Random();
        //List of potential AI names to randomize from.
        private static List<string> sampleAINames = new List<string> { "Mr. Robot", "Tom Robotsen", "Tim Automatson", "Göran Robotmark", "Andreas Robotson", "Robot Rob" };

        public static void Main()
        {
            CustomizeConsole();
            Menu.PrintWelcomeMessage();
            RunGameLoop();
        }

        //Prints the menu and starts the game with an array of IPlayer as parameter.
        //This method is created to be able to be called from Game to start a new game.
        public static void RunGameLoop()
        {
            Menu.PrintStartMenu();
            new Game(GetPlayers());
        }

        //Creates the players for the game, either two human controlled players, one human and one computer, or two computers.
        //Returns an IPlayer array of those players.
        private static IPlayer[] GetPlayers()
        {
            IPlayer[] players = new IPlayer[2];
            switch (InputHandler.GetMenuChoice(3))
            {
                case 1:
                    players[0] = new Player(InputHandler.GetUserName("Enter Player 1's Name!"));
                    players[1] = new Player(InputHandler.GetUserName("Great! Now Enter Player 2's Name!"));
                    break;
                case 2:
                    players[0] = new Player(InputHandler.GetUserName("Enter Your Player Name"));
                    players[1] = new AI(sampleAINames[rand.Next(sampleAINames.Count)]);
                    break;
                case 3:
                    players[0] = new AI(sampleAINames[rand.Next(sampleAINames.Count)]);
                    players[1] = new AI(GetRandomUniqueAiName(players[0].name));
                    break;
            }
            return players;
        }

        //Finds a name from the sampleNames that is not the same as the parameter string.
        private static string GetRandomUniqueAiName(string name)
        {
            string nameAI2;
            do
            {
                nameAI2 = sampleAINames[rand.Next(sampleAINames.Count)];
            } while (nameAI2 == name);
            return nameAI2;
        }

        //Changes appearance of console.
        private static void CustomizeConsole()
        {
            Console.SetWindowSize(110, 35); // start size på console.
            Console.BackgroundColor = ConsoleColor.DarkMagenta; // färg på bakgrund.
            Console.ForegroundColor = ConsoleColor.White;  // färg på text.
            Console.Clear();
        }
    }
}
