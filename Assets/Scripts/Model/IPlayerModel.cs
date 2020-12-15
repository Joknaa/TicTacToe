namespace Model
{
    public interface IPlayerModel
    { 
        int GetMoves();
        int GetWins();

        void AddMoves();
        void AddWins();
    }
}