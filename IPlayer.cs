namespace Nim
{
    public interface IPlayer
    {
        //AI or Player
        string name { get; }

        int wins { get; set; }

        int[] MakeMove(int[] board);
    }
}
