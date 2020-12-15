﻿namespace Model
{
    public class PlayerOModel : IPlayerModel
    {
        private int Moves;
        private int Wins;
        
        public int GetMoves(){
            return Moves;
        }
        public int GetWins(){
            return Wins;
        }

        public void AddMoves(){
            Moves++;
        }
        public void AddWins(){
            Wins++;
        }
    }
}