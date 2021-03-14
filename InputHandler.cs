using System;

namespace Nim
{
    public static class InputHandler
    {
        //this class is called to check for faulty input and always returns a valid one.
        //It also always checks for the keywords 'quit' or return.
        public static string GetUserName(string instructions)
        {
            while (true)
            {
                Console.WriteLine(instructions);
                string input = Console.ReadLine();
                CheckForQuitOrReset(input);
                if(input.Trim().Length != 0)
                {
                    return input;
                }
            }
        }

        //Gets player move in the format: X Y
        //Where Y is less than or equal to the X pile's remaining sticks
        //Returns an int[] which contains 2 values, X and Y.
        public static int[] GetPlayerMove(int[] currentBoard, string playerName)
        {
            Console.WriteLine(playerName + " Enter Your Move!");
            while(true)
            {
                
                string input = Console.ReadLine().Trim();
                CheckForQuitOrReset(input);
                if(input.Length == 3)
                {
                    
                    if (Int32.TryParse(input[0].ToString(), out int res1) &&
                    Int32.TryParse(input[2].ToString(), out int res2) &&
                    res1 != 0 &&
                    res2 != 0 &&
                    currentBoard[res1 - 1] >= res2)
                    {
                        return new int[2] {res1 , res2};
                    }
                }
                Console.WriteLine("\nEnter Your Move in the Format (1 4)" +
                    "\nWhere 1 corresponds to the pile and 4 to the amount of sticks you'd like to do draw from the pile");
            }
        }

        //Takes a number of choices in the menu and always returns a value between one and the total options
        public static int GetMenuChoice(int menuChoices)
        {
            while(true)
            {
                string input = Console.ReadLine();
                CheckForQuitOrReset(input);
                if(Int32.TryParse(input, out int choice) && choice <= menuChoices && choice >= 1)
                {
                    return choice;
                }
            }
        }

        //Helper method used by all methods in this class to check for keywords 'quit' and 'reset'
        private static void CheckForQuitOrReset(string input)
        {
            if(input.ToLower() == "quit")
            {
                Environment.Exit(0);
            } else if(input.ToLower() == "reset")
            {
                Program.Main();
                Environment.Exit(0);
            }
        }
    }
}
