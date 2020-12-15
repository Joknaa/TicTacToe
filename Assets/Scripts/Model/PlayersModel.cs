using UnityEngine;

namespace Model
{
    public class PlayersModel : MonoBehaviour
    {
        public GameObject[] players = new GameObject[2];
        
        
        public void AddMoves(int i, int j, int playerID)
        {
            players[playerID].GetComponent<PlayerModel>().AddMoves(i, j, playerID);
        }
        public void AddWins(int playerID)
        {
            players[playerID].GetComponent<PlayerModel>().AddWins();
        }
        
        public char[,] GetMoves(int playerID)
        {
            return players[playerID].GetComponent<PlayerModel>().GetMoves();
        }
        public int GetWins(int playerID)
        {
            return players[playerID].GetComponent<PlayerModel>().GetWins();
        }
        
        public int GetTotalMoves()
        {
            int TotalMoves = players[0].GetComponent<PlayerModel>().GetTotalMoves() +
                             players[1].GetComponent<PlayerModel>().GetTotalMoves();
            return TotalMoves;
        }
    }
}