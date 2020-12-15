using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

namespace Model
{
    public class PlayerModel : MonoBehaviour
    {
        public char[,] moves = {{' ', ' ', ' '}, {' ', ' ', ' '}, {' ', ' ', ' '}};
        public int TotalMovesPlayed = 0;

    private int Wins = 0;
        
        public void AddMoves(int i, int j, int playerID){
            TotalMovesPlayed++;
            moves[i,j] = playerID == 0 ? 'X' : 'O';
        }
        public void AddWins(){
            Wins++;
        }
        
        public char[,] GetMoves(){
            return moves;
        }
        public int GetWins(){
            return Wins;
        }
        
        public int GetTotalMoves(){
            return TotalMovesPlayed;
        }
    }
}