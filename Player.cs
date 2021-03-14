namespace Nim
{
    public class Player : IPlayer
    {
        public string name { get; private set; }
        public int wins { get; set; } = 0;

        public Player(string name)
        {
            this.name = name;
        } 

        //Returns the board affected by the player move entered through the InputHandler.GetPlayerMove() method.
        public int[] MakeMove(int[] board)
        {
            int[] move = InputHandler.GetPlayerMove(board, name);
            board[move[0] - 1] = board[move[0] - 1] - move[1];
            return board;
        }

    }
}
