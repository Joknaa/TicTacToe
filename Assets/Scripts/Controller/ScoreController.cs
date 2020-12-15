using Model;
using UnityEngine;

namespace Controller
{
    public class ScoreController : MonoBehaviour
    {
        public GameStateEnum currentGameState = GameStateEnum.Playing;
        private const int playerXID = 0;
        private const int playerOID = 1;
        private char[,] xMoves;
        private char[,] oMoves;
        private int xWins;
        private int oWins;
        private int TotalMovesPlayed;
        
        public GameStateEnum CheckCurrentGameState(GameObject playersModel, PlayerEnum currentPlayer)
        {
            CountMoves(playersModel);
            CountWins(playersModel);
            
            xWins = playersModel.GetComponent<PlayersModel>().GetWins(playerXID);
            oWins = playersModel.GetComponent<PlayersModel>().GetWins(playerOID);
            TotalMovesPlayed = playersModel.GetComponent<PlayersModel>().GetTotalMoves();
            
            if (xWins == 0 && oWins > 0){           currentGameState = GameStateEnum.OWin;
            } else if(xWins >  0 && oWins == 0){    currentGameState = GameStateEnum.XWin;
            } else if(xWins == 0 && oWins == 0){
                if(TotalMovesPlayed < 9){          currentGameState = GameStateEnum.Playing;
                } else if (TotalMovesPlayed == 9){ currentGameState = GameStateEnum.Draw;
                }
            }
            return currentGameState;
        }
        
        void CountMoves (GameObject playersModel)
        {
            xMoves = playersModel.GetComponent<PlayersModel>().GetMoves(playerXID);
            oMoves = playersModel.GetComponent<PlayersModel>().GetMoves(playerOID);
        }

        void CountWins(GameObject playersModel)
        {
            for (int i = 0; i < 3; i++) { // Verticals
                if (xMoves[i,0] + xMoves[i,1] + xMoves[i,2] == 264)
                    playersModel.GetComponent<PlayersModel>().AddWins(playerXID);
                if (oMoves[i,0] + oMoves[i,1] + oMoves[i,2] == 237) 
                    playersModel.GetComponent<PlayersModel>().AddWins(playerOID);
            }

            for (int i = 0; i < 3; i++) { // Horizontals
                if (xMoves[0,i] + xMoves[1,i] + xMoves[2,i] == 264)
                    playersModel.GetComponent<PlayersModel>().AddWins(playerXID);
                if (oMoves[0,i] + oMoves[1,i] + oMoves[2,i] == 237) 
                    playersModel.GetComponent<PlayersModel>().AddWins(playerOID);
            }

            // Diagonals
            if (xMoves[0,0] + xMoves[1,1] + xMoves[2,2] == 264) playersModel.GetComponent<PlayersModel>().AddWins(playerXID);
            if (oMoves[0,0] + oMoves[1,1] + oMoves[2,2] == 237) playersModel.GetComponent<PlayersModel>().AddWins(playerOID);
            if (xMoves[0,2] + xMoves[1,1] + xMoves[2,0] == 264) playersModel.GetComponent<PlayersModel>().AddWins(playerXID);
            if (oMoves[0,2] + oMoves[1,1] + oMoves[2,0] == 237) playersModel.GetComponent<PlayersModel>().AddWins(playerOID);
        }
    }
}
