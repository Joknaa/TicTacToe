using UnityEngine;

namespace Model
{
    public class PlayerXModel : MonoBehaviour
    {
        private int Moves = 0;
        private int Wins = 0;
        
        public void AddMoves()
        {
            Moves++;
        }
        public void AddWins()
        {
            Wins++;
        }
        
        public int GetMoves()
        {
            return Moves;
        }
        public int GetWins()
        {
            return Wins;
        }
    }
}