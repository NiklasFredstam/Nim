using System;

namespace Nim
{
    public class AI : IPlayer
    {
        public string name {get; set; }

        public int wins { get; set; } = 0;


        public AI(string name)
        {
            this.name = name;
        }

        // Super simple AI. Which performs randomly, unless it can win in one move.
        public int[] MakeMove(int[] board)
        {
            int whichpile;
            int howmanysticks;
            bool cond = true;
            while (cond)
            {
                //Checks if it can win in one move.
                if ((board[0] == 0 && board[1] == 0) || (board[0] == 0 && board[2] == 0) || (board[1] == 0 && board[2] == 0))
                {
                    for (int i = 0; i < board.Length; i++)
                    {
                        if (board[i] != 0)
                        {
                            Console.WriteLine(name + " " + (i + 1) + " " + board[i]);
                            board[i] = board[i] - board[i];
                            cond = false;
                        }
                    }
                }
                //Else performs a random move.
                else
                {
                    whichpile = Program.rand.Next(0, 3);
                    if (board[whichpile] != 0)
                    {
                        howmanysticks = Program.rand.Next(1, board[whichpile] + 1);
                        board[whichpile] = board[whichpile] - howmanysticks;
                        Console.WriteLine(name + " " + (whichpile + 1) + " " + howmanysticks);
                        cond = false;
                    }
                }
            }
            //Short pause for player to be able to see the AI's move.
            System.Threading.Thread.Sleep(3000);
            return board;
        }
    }
}
