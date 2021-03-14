namespace Nim
{
    public interface IPlayer
    {
        //Allows us to create a list of IPlayers that can be either AI or Player
        string name { get; }

        int wins { get; set; }

        int[] MakeMove(int[] board);
    }
}
