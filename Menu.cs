using System;

namespace Nim
{
    public static class Menu
    {

        // This class only contains void methods that type out game info and menus to console.

        //Prints header.
        private static void PrintHeader(IPlayer[] players)
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Current score: " + players[0].name + " " + players[0].wins + " - " + players[1].name + " " + players[1].wins);
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("____________________________________________________________________________________________________");
            Console.WriteLine("                                              CURRENT PILES            ");
        }

        //Prints welcome message.
        public static void PrintWelcomeMessage()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Welcome to the game of NIM!");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\nThere are 3 piles with 5 sticks in each pile " +
                "\nplayers take turns removing a number of sticks from a specified pile" +
                "\nThe player who picks the last stick wins the game. " +
                "\n " +
                "\nTo play the game, first enter which pile you would like to draw sticks from. " +
                "\nThen enter how many sticks from that pile you would like to remove" +
                "\n" +
                "\nIf you'd like to exit the game you can enter QUIT at any time" + 
                "\nYou can also enter RESET at any time to reset the game and return to this start screen");
            Console.WriteLine("\n\n\nPress any button to Continue");
            Console.ReadKey();
        }

        //Prints start menu.
        public static void PrintStartMenu()
        {
            Console.Clear();
            Console.WriteLine("1: Play against a friend");
            Console.WriteLine("2: Play against the computer");
            Console.WriteLine("3: Let the AI duel");
        }

        //Prints every turn, and calls helper methods to do so.
        public static void PrintGame(IPlayer[] players, int[] board)
        {
            Console.Clear();
            PrintHeader(players);
            PrintBoard(board);
        }

        //Prints the winning players name. 
        public static void PrintEndGame(string winnerName)
        {
            Console.Clear();
            Console.WriteLine(winnerName.ToUpper() + " HAS WON THE GAME!\n\n\n" +
                "\nWould You Like to Play Again?\n" +
                "\n\n1: Same Players" + 
                "\n2: New Players");
        }

        //This prints a fancy looking board into the console.
        private static void PrintBoard(int[] board)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            for (int i = 0; i < 5; i++)
            {
                for (int k = 0; k < board.Length; k++)
                {
                    if (i == 2)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.Write("\t Pile " + (k + 1) + ":");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.Write("\t\t");
                    }
                    for (int j = 0; j < board[k]; j++)
                    {

                        if (i % 2 == 0)
                        {
                            Console.Write("|/| ");
                        }
                        else
                        {
                            Console.Write("|\\| ");
                        }
                    }
                }
                Console.WriteLine();
            }
        }

            
    }
}
