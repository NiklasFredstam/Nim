using System.Linq;

namespace Nim
{
    public class Game
    {
        //Instanciate object fields for Game
        private IPlayer[] players;
        private int[] board = new int[] {5,5,5 };
        private int firstTurn;
        private int playerTurn;

        //Constructor called to start and run game.
        public Game(IPlayer[] players)
        {
            this.players = players;
            firstTurn = Program.rand.Next(2);
            PlayGame();
        }

        //Overload for constructor to play game with info from precious game
        public Game(IPlayer[] players, int firstTurn)
        {
            this.players = players;
            this.firstTurn = firstTurn + 1;
            PlayGame();
        }

        //Main game loop that calls individual IPlayer 
        private void PlayGame()
        {
            playerTurn = firstTurn;
            while(board.Sum() != 0)
            {
                Menu.PrintGame(players, board);
                board = players[playerTurn % 2].MakeMove(board);
                if(board.Sum() != 0)
                    playerTurn += 1;
            }
            players[playerTurn % 2].wins += 1;
            Menu.PrintEndGame(players[playerTurn % 2].name);
            AskForNewGame();
        }

        //Asks for new game and either goes back to RunGameLoop() or simply creates a new Game instance
        private void AskForNewGame()
        {
            switch(InputHandler.GetMenuChoice(2))
            {
                case 1:
                    new Game(players, firstTurn);
                    break;
                case 2:
                    Program.RunGameLoop();
                    break;
            }
        }
    }
}
